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
    public partial class ChangePwd : Form
    {
        /* 비밀번호 변경 */
        MainForm main;
        public ChangePwd(MainForm main)
        {
            this.main = main;
            InitializeComponent();
            Design.buttonStyle(button1);
        }
        public void changePassword()
        {
            Store.myInfo.setPwd(txtNewPwd.Text);
            MessageBox.Show("비밀번호가 변경되었습니다.");
            this.Close();
        }
        private void button1_Click(object sender, EventArgs e)
        { 
            /* 변경하기 버튼 */

            string myPwd = Store.myInfo.getPwd();
            if (myPwd != txtPastPwd.Text)
                MessageBox.Show("비밀번호가 틀립니다.");
            else
            {
                string newPwd = txtNewPwd.Text;
                int myNum = Store.myInfo.getUserNum();

                string packet = "3|2|" + myNum + "|" + myPwd + "|" + newPwd + "|";
                main.SendStr(packet);
            } 
            
            //MessageBox.Show("탈퇴되었습니다.");

/*
            if (myPwd== txtPastPwd.Text) // 현재 비밀번호와 일치하면..
            {
                if (txtNewPwd.Text == txtRePwd.Text)    // 새 비밀번호와 재입력이 일치하면 변경
                {
                    Store.myInfo.setPwd(txtNewPwd.Text);

                    foreach (User user in Store.userlist)
                    {
                        if (user.getUserNum() == Store.myInfo.getUserNum()) // 유저정보 변경
                        {
                            user.setPwd(txtNewPwd.Text);
                            MessageBox.Show("변경완료");
                            this.Close();
                            break;
                        }
                    }
                }
                else
                {
                    MessageBox.Show("재입력 비밀번호를 잘못입력하였습니다.");
                }
            }
            else
            {
                MessageBox.Show("비밀번호가 일치하지 않습니다.");
            }
  */          
            // my정보와 user정보 수정
            //string myPwd = Store.myInfo.getPwd(); // 현재 비밀번호
            //Store.myInfo.setPwd(textBox1.Text);

            //foreach (User user in Store.userlist)
            //{
            //    if (user.getuserId().CompareTo(myPwd) == 0)
            //    {
            //        user.setName(textBox1.Text);
            //        break;
            //    }
            //}
        }
    }
}
