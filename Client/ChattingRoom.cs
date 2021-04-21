using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Client
{
    class ChattingRoom
    {
        private int chattingRoomNum;
        private List<Friend> MemberNums = new List<Friend>();
        private DateTime datetime;
        private List<Message> message = new List<Message>();
        private ChatRoom chatRoom;
        public ChatRoomLabel chatRoomLbl = new ChatRoomLabel();
        private string lastMessage;
        private bool isFirst = true;
        delegate void DG();
        MainForm main;

        public ChattingRoom(MainForm main, int rNum)
        {        
               
            this.chattingRoomNum = rNum;
            this.main = main;
            //this.datetime = DateTime.Now;
            chatRoomLbl.BackColor = System.Drawing.Color.AliceBlue;
            chatRoomLbl.Size = new System.Drawing.Size(300, 35);
            chatRoomLbl.Margin = new Padding(2, 2, 2, 2);
            chatRoomLbl.Click += (sender, e) =>
            {
                showRoom();
            };
        }

        public int getRoomNum() { return chattingRoomNum; }
        public List<Friend> getMembers() { return MemberNums; }
        public DateTime getDateTime() { return datetime; }
        public ChatRoom getChatRoom() { return chatRoom; }

        public void setRoomNum(int chattingRoomNum) { this.chattingRoomNum = chattingRoomNum; }
        public void setMembers(List<Friend> MemberNums) { this.MemberNums = MemberNums; }
        public void addMember(Friend friend) { MemberNums.Add(friend); }
        
        public void setDateTime(DateTime datetime) { this.datetime = datetime; }

        public void addMember()
        {
            if (chatRoom != null)
            {
                chatRoom.addMember();
            }
        }

        public void setLblText()
        {
            try
            {
                if (chatRoomLbl.InvokeRequired)
                {
                    DG d = new DG(setLblText);
                    main.Invoke(d);
                }
                else
                {
                    chatRoomLbl.Text = "";

                    for (int i = 0; i < MemberNums.Count; i++)
                    {
                        chatRoomLbl.Text += MemberNums[i].getfname();
                        if (i != MemberNums.Count - 1)
                        {
                            chatRoomLbl.Text += ", ";
                        }

                    }
                    chatRoomLbl.Text += "|";
                    chatRoomLbl.Text += lastMessage + "|" + datetime.ToString("MM월 dd일 HH:mm");
                }
            }
            catch 
            {
            }
            
        }

        public void showRoom()
        {
            chatRoom = new ChatRoom(main, chattingRoomNum, isFirst);
            chatRoom.Show();
            chatRoom.setRoom(message);
            isFirst = false;
        }

        public void setMessage(int uNum, string msg, DateTime time)
        {
            Message message = new Message(uNum, msg, time);
            chatRoom.setMsg(uNum, msg, time);
            this.message.Add(message);
            this.datetime = time;
            this.lastMessage = msg;
            setLblText();
        }
        public void setExistedMessage(int uNum, string msg, DateTime time)
        {
            chatRoom.setMsg(uNum, msg, time);
            this.datetime = time;
            this.lastMessage = msg;
            setLblText();
        }
        public void setRestMessage(int uNum, string msg, DateTime time)
        {
            Message message = new Message(uNum, msg, time);            
            this.message.Add(message);
            this.datetime = time;
            this.lastMessage = msg;
            //setLblText();
        }
        public List<Message> getMessage()
        {


            return message;
        }
    }
}
