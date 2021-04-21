using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server
{
    partial class ServerForClient
    {
        ConnectionState con;
        StringSplit stSplit = new StringSplit();
        //UserData user;
        public ServerForClient(ConnectionState con)
        {
            this.con = con;
        }

        public string logState(List<string> userInfo)
        {
            string result = null;
            UserData loginUser;
            switch (userInfo[1])
            {
                case "0"://로그인
                    loginUser = con.login(userInfo[2]);
                    if (loginUser != null)
                    {
                        if (loginUser.logState == false)//로그인이 안되어 있다면
                        {
                            if (login(loginUser.password, userInfo[3]) == 0)//비번이 맞다면
                            {
                                result = "0|0|1|" + loginUser.userNum + "|" + loginUser.nickName + "|";
                                //+ loginUser.nickName + "|" + loginUser.AllRoomNum + "|" + loginUser.AllFriNum + "|";
                                //DB 로그인으로 포시하는 메서드 생성
                                //con.logStateUpdate(loginUser.userNum,loginUser.logState);
                                if (con.logStateUpdate(loginUser.userNum, loginUser.logState) > 0)
                                {
                                    loginUser.logState = true;
                                }
                            }
                            else
                            {
                                result = "0|0|0||";
                            }
                        }
                        else
                        {
                            result = "0|0|0||";
                        }
                    }
                    else
                    {
                        result = "0|0|0||";
                    }
                    break;

                case "1"://회원가입
                    if (con.userCheck(userInfo[2])) // 아이디가 존재한다면
                    {
                        result = "0|1|0|중복된 아이디|";//중복시 3번째 split에 0을 기입
                    }
                    else if (con.joinNewUser(userInfo[2], userInfo[3], userInfo[4]) >= 0)
                    {
                        result = "0|1|1|" + userInfo[2] + " 가입완료| ";//가입되면 3번째 split에 1을 기입
                    }
                    break;

                //case "2"://ID찾기
                //    break;

                case "3"://비밀번호 찾기
                    result = "0|3|" + con.searchPassword(userInfo[2], userInfo[3]) + "|";
                    break;

                default:// 에러인 경우 작동 - 안씀
                    break;
            }
            return result;
        }
        private int login(string inputPassword, string password)
        {
            if (inputPassword == null)
            {
                return 1;
            }
            else if (inputPassword.Equals(password))
            {
                return 0;//로그인 승인 
            }
            else
            {
                return 1;//로그인 비승인 
            }
        }

        public string friendState(List<string> temp)
        {
            string tempString = null;//리턴을 위한 string
            switch (int.Parse(temp[1]))
            {
                case 0://친구 목록
                    tempString = "1|0|";
                    List<string> frindsList = con.callFriends(int.Parse(temp[2]));
                    if (frindsList[0].Equals(""))
                    {
                        tempString += "|";
                    }
                    else
                    {
                        foreach (string item in frindsList)
                        {
                            if (item.Equals(""))
                            {
                                tempString += "|";
                            }
                            else
                            {
                                tempString += item + "?" + con.getNickName(int.Parse(item)) + "/";
                            }
                        }
                    }

                    break;

               case 1:// 친구 추가
                    int userNum = con.addFriend(int.Parse(temp[2]), temp[3]);
                    if (userNum > 0)
                    {
                        tempString = "1|1|1|" + userNum + "|"+ con.getNickName(userNum)+"|";
                    }
                    else
                    {
                        tempString = "1|1|0||";
                    }

                    break;
            }
            return tempString;//받은 데이터 전송을 위한 리턴
        }


        public string chatState(List<string> temp)
        {
            string tempString = null;
            List<string> tempList = null;
            switch (int.Parse(temp[1])) 
            {
                case 0://채팅방 목록 2|0
                    tempList = con.roomNum(int.Parse(temp[2])); // 2|0|유저번호
                    tempString = "2|0|";
                    if (tempList[0].Equals(""))
                    {
                        tempString += "|";
                    }
                    else
                    {
                        foreach (string roomNum in tempList)
                        {
                            if (roomNum.Equals(""))
                            {
                                tempString += "|";
                            }
                            else
                            {
                                tempString += roomNum + "/";
                                
                               
                            }
                        }
                    }
                    break;
                case 1://채팅방 생성.. 2|1
                    string newRoomNo= con.newRoom(temp[2], temp[3]); // temp[2] = 유저번호, temp[3] = 친구목록
                    if (newRoomNo.Equals(""))
                    {
                        tempString = "2|1|0|";
                    }
                    else
                    {
                        tempString = "2|1|1|";
                        int roomNum = con.selectNewRoom(newRoomNo);
                        tempString += roomNum + "|";
                        con.updateNewRoom(roomNum,int.Parse(temp[2]));
                        foreach (string UserNum in stSplit.comaCut(temp[3])) 
                        {
                            if (!UserNum.Equals(""))
                            {
                                con.updateNewRoom(roomNum, int.Parse(UserNum));
                                tempString += UserNum + "?" + con.getNickName(int.Parse(UserNum)) + "/";
                            }
                        }  
                    }
                    break;
                case 2://채팅방 글 불러오기  2|2
                    tempString = "2|2|";
                    foreach (string item in con.chattingMessageReader(int.Parse(temp[2])))
                    {
                        tempString += item + "/";
                    }
                    break;
                case 3://채팅방 인원 추가 2|3
                    con.updateRoomMember(int.Parse(temp[2]), temp[3]);
                    tempString = "2|3|1|" + int.Parse(temp[2]) + "|";
                    foreach (string item in stSplit.comaCut(temp[3]))
                    {
                        if (item.Equals(""))
                        {
                            tempString += "|";
                            // tempString = "2|3|1|" + RoomNum + "|" + "추가멤버번호" + "|" + "추가멤버네임" + "|";
                        }
                        else
                        {
                            con.updateNewRoom(int.Parse(temp[2]), int.Parse(item));
                            tempString += item + "?" + con.getNickName(int.Parse(item)) + "/";
                        }
                    }
                   
                    break;
                case 4: // 채팅 메시지 전송 2|4 
                    if (con.chatMsgInsert(int.Parse(temp[2]), int.Parse(temp[3]), temp[4]) > 0) // 방번호|유저번호|메시지                    
                    {                                            
                        tempString = "2|4|1|" + temp[2] + "|" + temp[3] + "|" + temp[4] + "|" + 
                            con.chatTimesel(int.Parse(temp[3]), temp[4]) + "|" + con.selectChatMem(int.Parse(temp[2])) + "|";
                    }   
                   // 채팅 보낸 User가 참여하고 있는 RoomNum 찾는다.
                   //SocketByUser.TryGetValue(소켓을 통해서, UserNum을 얻는다) -> userNum -> roomNum
                    break;
                default:
                    break;
            }
            return tempString;
        }

        //*************************commit******************
        public string informState(List<string> userInfo)
        {
            string result = null;
            switch (int.Parse(userInfo[1]))
            {
                case 0: // 로그아웃
                    con.logStateUpdate(int.Parse(userInfo[2]),true);
                    result = "3|0|1|";
                    break;
                case 1: // 닉네임 변경
                    if(con.NickUpdate(int.Parse(userInfo[2]), userInfo[3]) > 0)
                    {
                        result = "3|1|1|" + userInfo[3] + "|";
                    }
                    else
                    {
                        result = "3|1|0|";
                    }
                    break;
                case 2: // 비밀번호 변경
                    if(con.PwdUpdate(int.Parse(userInfo[2]), userInfo[3], userInfo[4]) > 0)
                    {
                        result = "3|2|1|";
                    }
                    else
                    {
                        result = "3|2|0|";
                    }
                    break;
                case 3: //회원탈퇴
                    if (con.UserNULL(int.Parse(userInfo[2]), userInfo[3]) > 0)
                    {
                        result = "3|3|1|";
                    }
                    else
                    {
                        result = "3|3|0|";
                    }

                    break;
                default:
                    break;
            }
            return result;
        }
    }
}
