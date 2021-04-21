using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Server
{
    class ServerState
    {
        Socket server = null;
        Socket clientTemp = null;

        Thread thread;// 유저 대기 쓰레드
        Thread threadTemp;//로그인 처리용 쓰레드
        Thread clientThread;

        ConnectionState con;
        ServerForClient serForcli;
        ServerMain form;

        bool threadKey = true;
        int clientNum = 10;

        public static Dictionary<Socket, Thread> threadBySocket = new Dictionary<Socket, Thread>();
        public static Dictionary<int, Socket> socketByUser = new Dictionary<int, Socket>();

        StringSplit stSplit = new StringSplit();

        public ServerState(string IPAdd, int port, ServerMain form)
        {
            this.form = form;
            serverSet(IPAdd, port);
            thread = new Thread(new ThreadStart(serverstart));
            thread.Start();
        }

        public void conRecive(ConnectionState con)
        {
            this.con = con;
            serForcli = new ServerForClient(con);
        }// con 리시버 없으면 DB 활용 불가능

        private void serverSet(string IPAdd, int port)
        {
            IPEndPoint ip = new IPEndPoint(IPAddress.Any, port);
            server = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

            server.Bind(ip);
            server.Listen(clientNum);
        }//소켓 생성 및 초기 설정

        private void serverstart()//로그인시 확인하고 서버 투 클라이언트 내용 저장
        {
            while (threadKey)
            {
                form.AppendMessage("server 대기중");
                try//로그인 시도
                {
                    clientTemp = server.Accept();

                    threadTemp = new Thread(threadForLog);
                    threadTemp.Start(clientTemp);

                    form.clientCount();
                    form.AppendMessage("client 받음");
                }
                catch (Exception)//일치하지 않거나 실패하였을때
                {
                    // 서버 강종
                }
            }
        }//Thread 상태로 접속을 대기하고 유저의 상태 검사

        private void threadForLog(object clientTemp)//로그인 이전에 소켓 유지 구역(입력 코드: 로그인, 회원가입)
        {
            Socket cSocket = (Socket)clientTemp;
            string msg = "";
            byte[] data;

            data = new byte[1024];
            cSocket.Receive(data);
            msg = Encoding.Default.GetString(data);
            form.AppendMessage("recieve=" + msg);
            List<string> userInfo = stSplit.tempList(msg);
            msg = checkType(userInfo, cSocket);
            form.AppendMessage("send=" + msg);
            data = Encoding.Default.GetBytes(msg);
            cSocket.Send(data);
        }

        private string checkType(List<string> req, Socket cSocket)//받은 패킷 분석- 가장 큰부분만 분석해서 ServerForClient로 넘김 
        {
            string result = null;
            List<string> temp;
            switch (int.Parse(req[0]))
            {
                case 0://로그인
                    result = serForcli.logState(req);
                    temp = stSplit.tempList(result);
                    if (int.Parse(temp[1]) == 0)//로그인 처리
                    {
                        if (int.Parse(temp[2]) == 1)
                        {
                            clientThread = new Thread(threadClient);//유저 전용 작업 쓰레드 생성
                            clientThread.Start(int.Parse(temp[3]));
                            threadBySocket.Add(cSocket, clientThread);//소켓에 해당하는 쓰래드 저장
                            socketByUser.Add(int.Parse(temp[3]), cSocket);//유저에 해당하는 소켓 저장
                                                                          //로그인 후 표시 부분
                            form.AppendMessage(temp[3] + "/" + req[2] + "사용자 로그인");//서버측에 표시
                        }
                    }
                    else if (int.Parse(temp[1]) == 1)//회원가입 처리
                    {
                        if(int.Parse(temp[2]) == 1)
                        {
                            form.AppendMessage(temp[2] + "회원가입");
                            result = "0|1|1|";
                        }
                        else
                        {
                            result = "0|1|0|";
                        }
                      
                    }
                    break;

                case 1://친구
                    result = serForcli.friendState(req);
                    temp = stSplit.tempList(result);
                    if (int.Parse(temp[1]) == 0)//2|0 친구 목록
                    {
                        foreach (string item in stSplit.dataCut(temp[2]))
                        {
                            if (item.Equals(""))
                            {
                                result = "1|0|0||";
                            }
                            else
                            {
                                form.AppendMessage("친구 =" + item);
                                cSocket.Send(Encoding.Default.GetBytes("1|0|1|" + item + "|"));
                                Thread.Sleep(200);
                            }
                        }
                    }
                    else if (int.Parse(temp[1]) == 1)//친구 추가
                    {

                    }
                    break;

                case 2://채팅
                    result = serForcli.chatState(req);
                    temp = stSplit.tempList(result);

                    if (int.Parse(temp[1]) == 0)//2|0 채팅방 목록
                    {
                        foreach (string roomNum in stSplit.dataCut(temp[2])) // temp[2] : UserNum
                        {
                            if (roomNum.Equals(""))
                            {
                                result = "2|0|0||";
                            }
                            else
                            {
                                string tempString = "";
                                foreach (string userNum in con.chatMemberByRoomNum(int.Parse(roomNum)))
                                {
                                    if (userNum.Equals(""))
                                    {
                                        form.AppendMessage("roomNum=" + roomNum + ",users=" + tempString);
                                        cSocket.Send(Encoding.Default.GetBytes("2|0|1|" + roomNum + "|" + tempString + "|"));
                                        Thread.Sleep(200);
                                    }
                                    else
                                    {
                                        tempString += userNum + "?" + con.getNickName(int.Parse(userNum)) + "/";
                                    }
                                }
                            }
                        }                        
                    }
                    else if (int.Parse(temp[1]) == 1) //2|1 채팅방 생성
                    {
                        form.AppendMessage("방생성여부:" + temp[3]);
                    }
                    else if (int.Parse(temp[1]) == 2) //2|2 체팅메시지 전달 
                    {
                        if(temp[2].Equals("null"))
                        {
                            result = "2|2|0|"+ stSplit.dataCut(temp[3])[0] + ""; // 2|2|0|roomNum
                            break;
                        }
                        string chatstring = null;
                        string chatList = null;
                        List<string> temp2 = null;
                        foreach (string item in temp)
                        {                            
                            chatstring = item; // -> chatstring에 temp[3]번만 들어감                         
                        }

                        temp = stSplit.dataCut(chatstring); // -> / 자르기 ????/????/" "                          
                        foreach (string item2 in temp)
                        {
                            if (item2.Equals("")) // 마지막 null 일때
                            {
                                result = "2|2|0|" + temp2[0] + "|";
                            }
                            else
                            {                                
                                chatstring = item2;
                                temp2 = stSplit.listCut(chatstring); // -> ? 자르기

                                foreach (string item3 in temp2)
                                {                                    
                                    if (item3.Equals(""))
                                    {
                                        form.AppendMessage("2|2|1|" + chatList);
                                        cSocket.Send(Encoding.Default.GetBytes("2|2|1|" + chatList));
                                        Thread.Sleep(200);
                                        chatList = null;
                                    }
                                    else
                                    {                                        
                                        chatList += item3 + "|";
                                    }
                                }
                            }
                        }
                        result = "2|2|0|" + temp2[0] + "|";
                    }
                    else if (int.Parse(temp[1]) == 3)
                    {

                    }
                    else if (int.Parse(temp[1]) == 4) // 클라이언트가 채팅 메시지 보낼때!
                    {
                        List<string> chatMem = stSplit.comaCut(temp[7]); // 1 2 "";
                        string ExceptforMe = null;
                        Socket vSocket = null;
                        result = "2|4|1|" + temp[3] + "|" + temp[4] + "|" + temp[5] + "|" + temp[6] + "|";

                        foreach (string item in chatMem)                        
                        {
                            if(item.Equals(""))
                            {

                            }
                            else if (!item.Equals(temp[4])) // 자신만 빼고 나머지 로그인 여부 확인
                            {
                                ExceptforMe = item;
                                if(socketByUser.TryGetValue(int.Parse(ExceptforMe), out vSocket)==true)
                                {
                                    form.AppendMessage(ExceptforMe + "에게 " + temp[3]+ "방에서" + temp[4] +"로부터");      
                                    vSocket.Send(Encoding.Default.GetBytes(result));
                                } 
                            }
                        }                        
                    }
                    break;

                case 3://회원 정보
                    result = serForcli.informState(req);
                    temp = stSplit.tempList(result);
                    if (int.Parse(temp[1]) == 0)
                    { // 3|0 로그아웃 처리
                        form.AppendMessage(temp[3] + "사용자 로그아웃");//서버측에 표시
                    }
                    else if (int.Parse(temp[1]) == 1) // 3|1 닉네임 변경
                    {
                        if(int.Parse(temp[2]) == 1)
                        {
                            form.AppendMessage(req[2] + "닉네임 변경");
                            result = "3|1|1|" + temp[3] + "|";
                        } else
                        {
                            result = "3|1|0|";
                        }
                        
                    } else if (int.Parse(temp[1]) == 2) // 3|2 비밀번호 변경
                    {

                    } else if (int.Parse(temp[1]) == 3) // 3|3 회원탈퇴
                    {
                        if(int.Parse(temp[2]) == 1)
                        {
                            result = "3|3|1|";
                        } else if (int.Parse(temp[2]) == 0)
                        {
                            result = "3|3|0|";
                        }
                       
                    }
                    break;
                default:
                    result = "";
                    break;
            }
            return result;
        }

        private void threadClient(object UserNum)//로그인 된 유저용 쓰레드
        {
            int userNum = (int)UserNum;
            Socket cSocket;

            socketByUser.TryGetValue(userNum, out cSocket);//저장해놓은 소켓 찾기

            string msg = "";
            byte[] data = null;

            data = new byte[1024];
            //유저 종료시 문제 없이 종료 해야함
            List<string> req;
            while (true)
            {
                cSocket.Receive(data);
                msg = Encoding.Default.GetString(data);
                form.AppendMessage("recieve=" + msg);
                req = stSplit.tempList(msg);
               
                msg = checkType(req, cSocket);

                form.AppendMessage("send=" + msg);
                data = Encoding.Default.GetBytes(msg);
                try
                {
                    cSocket.Send(data);
                }
                catch (Exception)
                {
                  
                }

                if (msg == "3|0|1|")
                {
                    form.AppendMessage("user logout = " + UserNum);
                    break;
                }
                else
                {
                    //form.AppendMessage("강제종료");
                    //break;
                }
                data = new byte[1024];
            }           
            //clientThread.Abort();  // thread 종료    
            cSocket.Close();
            socketByUser.Remove(userNum);
            threadBySocket.Remove(cSocket); // 지정된 키가 있는 값 제거           
        }//문제 없이 로그인 된다면 ServerForClient에서 처리할수 있게 작업

        internal void serverStop()
        {
            threadKey = false;//클라이언트를 기다리는 쓰레드의 반복구문 종료

            if (clientTemp != null)
            {
                clientTemp.Close();
            }
            server.Close();
            thread.Join();//클라이언트 대기 쓰레드 안전종료(하고 있던 작업이 다 끝나면 종료)
            threadBySocket.Clear();//서버 종료를 위해 저장해놓은 유저 정보 청소
            form.clientCount();//접속 인원 초기화
            form.AppendMessage("server 종료");
        }//서버 종료 메서드
    }
}
