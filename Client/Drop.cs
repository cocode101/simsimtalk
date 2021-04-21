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
    public partial class Drop : Form
    {
        MainForm main;
        public Drop(MainForm MainMenu)
        {
            this.main = MainMenu;
            InitializeComponent();

            int w = this.Width;
            int h = this.Height;
            TextBox tb = new TextBox() { Width = (int)(w * 0.35), Location = new Point((int)(w * 0.25), (int)(h * 0.2)), PasswordChar='*' };
            this.Controls.Add(tb);
            Label lbl = new Label() { Text = "비밀번호", Location = new Point((int)(w * 0.05), (int)(h * 0.2)) };
            this.Controls.Add(lbl);
            Button drop = new Button() { Text = "탈퇴하기", Location = new Point((int)((w * 0.25) + tb.Width + 10), (int)(h * 0.2)) };
            Design.buttonStyle(drop);
            this.Controls.Add(drop);
            
            // 탈퇴버튼 이벤트
            drop.Click += (sender, e) =>
            {
                string mypwd = Store.myInfo.getPwd();
                DialogResult result;
                if (tb.Text == mypwd)
                {
                    result = MessageBox.Show("탈퇴하겠습니까?", "확인", MessageBoxButtons.OKCancel);
                    if (result == DialogResult.OK)
                    {
                        string packet = "3|3|" + Store.myInfo.getUserNum() + "|" + mypwd + "|";
                        MainMenu.SendStr(packet);
                        //MessageBox.Show("탈퇴되었습니다.");
                        // 로그인창으로 돌아가게 만들기
                    }
                }
                else
                {
                    MessageBox.Show("정보가 일치하지 않습니다.");
                }
                //else
                //{
                //    MessageBox.Show("비밀번호가 틀렸습니다.");
                //}
            };
        }
        public void isDrop(bool isdrop)
        {
            if (isdrop)
            {
                MessageBox.Show("탈퇴되었습니다.");

                //this.Close();
                //main.Close();
                //mainCloseMethod.mainFromChange(main); // 로그인폼으로..
                
            }
            else
            {
                MessageBox.Show("실패하였습니다. 비밀번호를 다시 확인해주세요.");
            }
        }
    }
}
