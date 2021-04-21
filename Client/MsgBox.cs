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
    public partial class MsgBox : UserControl
    {
        List<Friend> MemberList;
        public MsgBox(int rNum, int num, string msg, DateTime time)
        {
            InitializeComponent();

            ChattingRoom chatRoom = Store.chatList.Single((x) => x.getRoomNum() == rNum);
            this.MemberList = chatRoom.getMembers();

            float msgBoxWidth = setSize(msg);

            label2.Parent = pictureBox1;            

            if (num == Store.myInfo.getUserNum())
            {
                sendMsg(msg, time, msgBoxWidth);
            }
            else
            {
                revMsg(num, msg, time, msgBoxWidth);
            }
        }   

        //메시지박스 크기 조정 
        private float setSize(string msg)
        {
            //최대 글자수 => 20글자 
            int msgWidth;
            if (msg.Length >= 20)
            {
                msgWidth = 20;
            }
            else
            {
                //문자열이 20글자 이하일 경우
                msgWidth = msg.Length % 20;
            }

            //30 = >글자가 하나도 없을때 width
            float msgBoxWidth = 30 + msgWidth * 8.0F;
            //msgPanel의 최대크기 설정
            if (msgBoxWidth > 140)
            {
                msgBoxWidth = 160F;
            }

            //문자열 라인에 따른 msgBox의 height설정
            int line = msg.Length / 21;
            if (line != 0)
            {
                if (msgWidth != 20)
                {
                    this.Size = new Size(this.Width, this.Height + (line + 1) * 15);
                }
                this.Size = new Size(this.Width, this.Height + (line) * 15);
            }
            else
            {
                this.Size = new Size(this.Width, this.Height + 7);
            }

            return msgBoxWidth;
        }

        private void sendMsg(string msg, DateTime time, float msgBoxWidth)
        {
            //tablelayout내부 컨트롤 초기화 및 재정렬
            tableLayoutPanel1.Controls.Clear();
            tableLayoutPanel1.Controls.Add(label1, 1, 0);
            tableLayoutPanel1.Controls.Add(panel1, 1, 1);
            tableLayoutPanel1.Controls.Add(label3, 0, 1);
            label1.Text = Store.myInfo.getName();
            label1.TextAlign = ContentAlignment.TopRight;
            label2.Padding = new Padding(5, 8, 0, 0);
            label2.textAppend(msg);
            label2.TextAlign = ContentAlignment.TopLeft;
            label3.Text = time.ToString("HH:mm");
            //글자 수에 따른 msgBox의 크기 설정
            tableLayoutPanel1.ColumnStyles.Clear();
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 300 - msgBoxWidth));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, msgBoxWidth));
            label3.TextAlign = ContentAlignment.TopRight;
            //이미지 변경
            pictureBox1.Image = global::Client.Properties.Resources.msg3333;
            //이미지 회전
            pictureBox1.Image.RotateFlip(RotateFlipType.Rotate180FlipY);
        }

        private void revMsg(int num, string msg, DateTime time, float msgBoxWidth)
        {
            Friend friend = MemberList.Single((x) => x.getfNum() == num);

            label1.Text = friend.getfname();
            label2.textAppend(msg);
            label3.Text = time.ToString("HH:mm");
            tableLayoutPanel1.ColumnStyles.Clear();
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, msgBoxWidth));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 300 - msgBoxWidth));
        }
        
    }
}
