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
    public partial class menu_option : UserControl
    {
        
        ChangeName cName;
        public ChangePwd cPwd;
        MainForm main;
        public Drop drop;
        
        public menu_option(MainForm main)
        {
            this.main = main;
            InitializeComponent();

            Design.buttonStyle(btnLogout);
            Design.buttonStyle(btnChangeName);
            Design.buttonStyle(btnChangePwd);
            Design.buttonStyle(btnDrop);
                
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            /* 로그아웃 버튼 */
            DialogResult result;

            result = MessageBox.Show("로그아웃 하시겠습니까?", "로그아웃", MessageBoxButtons.YesNo);
            if(result == DialogResult.Yes)
            {
                string packet = "3|0|" + Store.myInfo.getUserNum() + "|";
                main.SendStr(packet);

                main.isLogout = true;
                mainCloseMethod.mainFromChange(main); // 로그인화면으로..
                               
            }
        }

        private void btnChangeName_Click(object sender, EventArgs e)
        {
            /* 이름변경 버튼 */
            cName = new ChangeName(main);
            cName.Show();
        }

        private void btnChangePwd_Click(object sender, EventArgs e)
        {
            /* 비밀번호 변경 버튼 */
            cPwd = new ChangePwd(main);
            cPwd.Show();
        }

        private void btnDrop_Click(object sender, EventArgs e)
        {
            /* 회원탈퇴 버튼 */
            drop = new Drop(main);
            drop.Show();
            //Form dropUser = new Form();
            //dropUser.Width = 300;
            //dropUser.Height = 100;
            //dropUser.Text = "회원탈퇴";
            //dropUser.Show();

            //int w = dropUser.Width;
            //int h = dropUser.Height;

            //TextBox tb = new TextBox() { Width = (int)(w * 0.35), Location = new Point((int)(w * 0.25), (int)(h * 0.2)) };
            //dropUser.Controls.Add(tb);
            //Label lbl = new Label() { Text = "비밀번호", Location = new Point((int)(w * 0.05), (int)(h * 0.2)) };
            //dropUser.Controls.Add(lbl);
            //Button drop = new Button() { Text = "탈퇴하기", Location = new Point((int)((w * 0.25) + tb.Width + 10), (int)(h * 0.2)) };
            //dropUser.Controls.Add(drop);

        }
        

        //private void dropClick(Object sender, EventArgs e)
        //{


        //    DialogResult result;
        //    result = MessageBox.Show("탈퇴할래?", "회원탈퇴", MessageBoxButtons.OKCancel);

        //    if (result == DialogResult.OK)
        //    {
        //        //dropUser.tb
        //        //string packet = "3|3|" + Store.myInfo.getUserNum() + "|" | pwd + "|";
        //        //MainMenu.SendStr(packet);
        //        MessageBox.Show("탈퇴되었습니다.");
        //    }
        //}
    }
}
