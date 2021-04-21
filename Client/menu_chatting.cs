using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Client
{
    public partial class menu_chatting : UserControl
    {
        /* 메뉴 - 채팅 */
        MainForm main;
        AddChatRoom addChat;
        delegate void UpdateChattingRoomLabel();

        public menu_chatting(MainForm main)
        {
            InitializeComponent();
            this.main = main;
            Design.buttonStyle(btnAddRoom);
        }

        private void btnAddRoom_Click(object sender, EventArgs e)
        {   
            /* 채팅방 생성하기 버튼 */
            addChat = new AddChatRoom(main, this); // 채팅방 생성
            addChat.Show();
            
        }
        //public void pntRoomList() // 채팅방 출력
        //{
        //    List<ChattingRoom> rList = Store.chatList;

        //    lboxChattingRoom.Items.Clear();
        //    for (int i=0; i<rList.Count;i++)
        //    {   // 채팅방 고유번호로 출력 (출력형식 수정예정)
        //        int rNum = rList.ElementAt(i).getRoomNum(); 
        //        lboxChattingRoom.Items.Add(rNum);
        //    }
        //}

        //private void lboxChattingRoom_Click(object sender, EventArgs e)
        //{
        //    /* 채팅방 목록에서 방 클릭시 */

        //    //int rNumber = lboxChattingRoom.SelectedIndex;

        //    //ChatRoom room = new ChatRoom(main, rNumber);
        //    //room.Show();
        //    try
        //    {
        //        int rNumber = (int)lboxChattingRoom.SelectedItem;
        //        ChattingRoom chatRoom = Store.chatList.Single((x) => x.getRoomNum() == rNumber);
        //        chatRoom.showRoom();
        //    }
        //    catch (Exception)
        //    {
        //        MessageBox.Show("채팅방을 클릭해주세요.");
        //    }          
        //}       

        //채팅방 목록 갱신(스레드동기화)
        private void updateChatRoom()
        {
            try
            {
                if (flowLayoutPanel1.InvokeRequired)
                {
                    UpdateChattingRoomLabel d = new UpdateChattingRoomLabel(updateChatRoom);
                    Invoke(d);
                }
                else
                {
                    flowLayoutPanel1.Controls.Clear();
                    List<ChattingRoom> chatList = Store.chatList;

                    chatList.Sort((a, b) => b.getDateTime().CompareTo(a.getDateTime()));

                    foreach (ChattingRoom item in chatList)
                    {
                        item.setLblText();
                        flowLayoutPanel1.Controls.Add(item.chatRoomLbl);
                    }
                }
            }
            catch 
            {
            }
            
        }
           

        //채팅방 목록 갱신
        public void ChatList(string roomNum, string fndList, bool isLast)
        {
            //마지막 일 경우 
            if (isLast)
            {
                //pntRoomList();
                updateChatRoom();
                Store.msgList.Clear();
                return;
            }

            int rNum = int.Parse(roomNum);
            //존재하는 채팅방인지 검사
            foreach (ChattingRoom item in Store.chatList)
            {
                if (item.getRoomNum() == rNum)
                {
                    return;
                }
            }            

            string[] str = fndList.Split('/');
            ChattingRoom chattingRoom = new ChattingRoom(main, rNum);
            Store.chatList.Add(chattingRoom);
            foreach (string item in str)
            {
                if (item.Equals(""))
                {
                    break;
                }
                string[] fnd = item.Split('?');
                int uNum = int.Parse(fnd[0]);
                if (uNum != Store.myInfo.getUserNum())
                {
                    Friend friend;
                    try
                    {
                        friend = Store.friendList.Single((x) => x.getfNum() == uNum);
                    }
                    catch (InvalidOperationException)
                    {
                        friend = new Friend();
                        friend.setfNum(uNum);
                        friend.setfname(fnd[1]);
                    }
                    chattingRoom.addMember(friend);
                }
            }
            //미확인 메시지 검사
            for (int i = Store.msgList.Count - 1; i >= 0; i--)
            {
                Message message = Store.msgList.ElementAt(i);
                if (rNum.Equals(message.getRoomNum()))
                {
                    int msgUser = message.getId();
                    string msg = message.getMsg();
                    DateTime msgTime = message.getTime();
                    chattingRoom.setRestMessage(msgUser, msg, msgTime);
                }
            }
        }

        //채팅 멤버 추가
        public void AddChatMember(string rNum, string fndList)
        {
            
            int roomNumber = int.Parse(rNum);
            ChattingRoom chatRoom = Store.chatList.Single((x) => x.getRoomNum() == roomNumber);

            //if (isLast) // "0"수신하면 목록 갱신
            //{
            //    chatRoom.addMember();
            //    updateChatRoom();
            //    return;
            //}

            string[] fnd = fndList.Split('/');

            foreach (string item in fnd)
            {
                if (fnd.Equals(""))
                {
                    break;
                }
                
                string[] fndInfo = item.Split('?');

                if (fndInfo[0] == "") { /* 채팅방 멤버 출력 갱신되게..*/ } 
                else
                {
                    int uNum = int.Parse(fndInfo[0]);

                    Friend friend;
                    try
                    {
                        friend = Store.friendList.Single((x) => x.getfNum() == uNum);
                    }
                    catch (Exception)
                    {
                        friend = new Friend();
                        friend.setfNum(uNum);
                        friend.setfname(fndInfo[1]);
                    }
                    chatRoom.addMember(friend);
                }
                //int uNum = int.Parse(fndInfo[0]);

                //Friend friend;
                //try
                //{
                //    friend = Store.friendList.Single((x) => x.getfNum() == uNum);
                //}
                //catch (Exception)
                //{
                //    friend = new Friend();
                //    friend.setfNum(uNum);
                //    friend.setfname(fndInfo[1]);
                //}

                //chatRoom.addMember(friend);
            }
            chatRoom.addMember();
            updateChatRoom();
            return;

        }

        //새 채팅방 생성
        public void NewChat(string roomNumber)
        {
            int rNum = int.Parse(roomNumber);
            ChattingRoom chatRoom = new ChattingRoom(main, rNum);
            chatRoom.setMembers(addChat.getMemberList());
            Store.chatList.Add(chatRoom);
            //pntRoomList();
            updateChatRoom();
            addChat.Close();
        }

        //메시지 수신
        public void RevMessage(string rNum, string uNum, string msg, string time)
        {
            int roomNumber = int.Parse(rNum);
            int msgUser = int.Parse(uNum);
            DateTime msgTime = Convert.ToDateTime(time);

            try   //존재하는 채팅방일 경우
            {
                ChattingRoom chatRoom = Store.chatList.Single((x) => x.getRoomNum() == roomNumber);
                chatRoom.setMessage(msgUser, msg, msgTime);
                updateChatRoom();
            }
            catch (InvalidOperationException)                    //없는 채팅방일 경우
            {
                ReqChatList();
                Message message = new Message(roomNumber, msgUser, msg, msgTime);
                Store.msgList.Add(message);
                //chatRoom = new ChattingRoom(main, roomNumber);
                //chatRoom.setRoomNum(roomNumber);
                //Store.chatList.Add(chatRoom);
                //pntRoomList();
            }
            catch (NullReferenceException)                      //채팅방이 닫혀있을 경우
            {
                ChattingRoom chatRoom = Store.chatList.Single((x) => x.getRoomNum() == roomNumber);
                chatRoom.setRestMessage(msgUser, msg, msgTime);
                updateChatRoom();
            }
        }

        private void ReqChatList()  //채팅목록 갱신 요청
        {
            string packet = "2|0|" + Store.myInfo.getUserNum() + "|";
            main.SendStr(packet);
        }

        public void menu_chatting_Load(object sender, EventArgs e)
        {
            flowLayoutPanel1.Controls.Clear();
            Store.chatList = new List<ChattingRoom>();
            ReqChatList();
        }
        public void RevDataBaseMessage(string rNum, string uNum, string msg, string time, bool isLast)
        {
            int roomNumber = int.Parse(rNum);
            ChattingRoom chatRoom = Store.chatList.Single((x) => x.getRoomNum() == roomNumber);

            
            if (isLast)
            {
                List<Message> msgList = chatRoom.getMessage();
                msgList.Sort((a, b) => a.getTime().CompareTo(b.getTime()));
                for(int i=0; i<msgList.Count; i++)
                {
                    chatRoom.setExistedMessage(msgList[i].getId(), msgList[i].getMsg(), msgList[i].getTime());
                }
                //foreach (var item in msgList)
                //{
                    
                    //chatRoom.setMessage(item.getId(), item.getMsg(), item.getTime());
                //}
                updateChatRoom();
                return;
            }
            

            int msgUser = int.Parse(uNum);
            DateTime msgTime = Convert.ToDateTime(time);

                
            chatRoom.setRestMessage(msgUser, msg, msgTime);
            
        }
    }
}
