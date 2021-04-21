using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Client
{
    public partial class ChatRoom : Form
    {
        /* 채팅방 폼 */

        int rNumber;    // 방 고유번호
        MainForm main;
        ChatMember cMember;
        bool isFirst;
        delegate void revMsgCallback(int num, string msg, DateTime time);

        public ChatRoom(MainForm main ,int rNumber, bool isFirst)
        {
           

            this.rNumber = rNumber;
            InitializeComponent();
            this.main = main;
            this.isFirst = isFirst;
            Design.buttonStyle(btnFileList);
            Design.buttonStyle(btnFileSend);
            Design.buttonStyle(btnMember);
            //Design.buttonStyle(btnMsgSend);
            btnFileList.Hide();
            btnFileSend.Hide();

            textBox2.KeyPress += (sender, e) =>
            {
                if (textBox2.Text.Length > 300)
                {
                    MessageBox.Show("300자 이상 보낼 수 없습니다.");
                    e.Handled = true;
                }
            };    
        }

        //채팅방 폼 생성시 기존의 메시지 출력
        public void setRoom(List<Message> message)
        {
            for (int i = 0; i < message.Count; i++)
            {
                setMsg(message.ElementAt(i).getId(), message.ElementAt(i).getMsg(), message.ElementAt(i).getTime());
            }
        }
        //public void setRoom(List<Message> message)
        //{
        //    foreach (Message item in message)
        //    {
        //        setMsg(item.getId(), item.getMsg(), item.getTime());
        //    }
        //}

        //메시지 수신

        public void setMsg(int uNum, string msg, DateTime time)
        {
            RevMessage(uNum, msg, time);
        }

        private void btnMember_Click(object sender, EventArgs e)
        {
            /* 인원목록 버튼 */

            cMember = new ChatMember(main, this.rNumber);
            cMember.Show();
        }

        private void btnFileList_Click(object sender, EventArgs e)
        {
            /* 파일목록 버튼 */

            FileList fileList = new FileList(rNumber);
            fileList.Show();
        }

        private void btnFileSend_Click(object sender, EventArgs e)
        {
            /* 파일 전송 버튼 */

            //File file = new File();
            //file.setRoomNumber(rNumber);

            //OpenFileDialog openFileDialog = new OpenFileDialog();
            //openFileDialog.ShowDialog();

            //if(openFileDialog.FileName.Length > 0)
            //{
            //    List<string> path = file.getFilePath();
            //    path.Add(openFileDialog.FileName);
            //}
            //Store.file.Add(file);
        }

        private void btnMsgSend_Click(object sender, EventArgs e)
        {
            string msg = textBox2.Text;
            msg = msg.Replace("|", "a9siw4kr9");
            string packet = "2|4|" + rNumber + "|" + Store.myInfo.getUserNum() + "|" + msg + "|";
            main.SendStr(packet);
        }
        
        public void addMember()
        {
            cMember.addMember();
        }

        //수신 메시지 동기화
        public void RevMessage(int num, string msg, DateTime time)
        {
            try
            {
                if (flowLayoutPanel1.InvokeRequired)
                {
                    revMsgCallback d = new revMsgCallback(RevMessage);
                    Invoke(d, new object[] { num, msg, time });
                }
                else
                {

                    test msgBox = new test(this.rNumber, num, msg, time);
                    //MsgBox msgBox = new MsgBox(this.rNumber, num, msg, time);
                    flowLayoutPanel1.Controls.Add(msgBox);
                    msgBox.Focus();


                    textBox2.Clear();
                    textBox2.Focus();
                }
            }
            catch
            {
            }
        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '\r')
            {
                e.Handled = false;
                btnMsgSend_Click(sender, e);
            }
        }

        private void ChatRoom_Load(object sender, EventArgs e)
        {
            if (isFirst)
            {
                ChattingRoom chattingRoom = Store.chatList.Single((x) => x.getRoomNum() == this.rNumber);
               
                string packet = "2|2|" + this.rNumber + "|";
                main.SendStr(packet);

                flowLayoutPanel1.Controls.Clear();
            }
            
        }
    }
}
