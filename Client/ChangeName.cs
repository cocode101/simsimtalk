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
    public partial class ChangeName : Form
    {
        /* 이름 변경하기 */

        MainForm main;
        
        public ChangeName(MainForm main)
        {
            this.main = main;
            InitializeComponent();

            Design.buttonStyle(button1);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // my정보와 user정보 수정
            int myNum = Store.myInfo.getUserNum(); // 유저번호 가져오기
            string newName = txtName.Text;

            //Store.myInfo.setName(newName); // my정보 수정

            string packet = "3|1|" + myNum + "|" + newName + "|";
            main.SendStr(packet);
            //MessageBox.Show("이름이 변경되었습니다.");
            this.Close();

            

            //foreach (User user in Store.userlist)
            //{
            //    if(user.getUserNum().CompareTo(myNum) == 0)
            //    { // user정보 수정
            //        user.setName(txtName.Text);
            //        MessageBox.Show("변경되었습니다.");
            //        this.Close();
            //        break;
            //    }
            //}       
               
        }
    }
}
