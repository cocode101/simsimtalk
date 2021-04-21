using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Client
{
    public partial class Login : Form
    {
        MainForm form;
        Socket temp;
        NewAccount newAccount;
        bool islogFail = true;

        public Login(MainForm form)
        {
            InitializeComponent();

            Design.buttonStyle(btnLogin);
            Design.buttonStyle(btnNewAccount);

            this.form = form;
            newAccount = new NewAccount(this, form);
            Controls.Add(newAccount);
            txtID.SetHintText("아이디");
            txtPW.SetHintText("비밀번호", true);
        }
        //로그인 클릭
        private void btnLogin_Click(object sender, EventArgs e)
        {

            setSocket();

            string packet = "0|0|" +txtID.Text + "|" + txtPW.Text + "|";
            byte[] data = new byte[1024];
            data = Encoding.Default.GetBytes(packet);
            temp.Send(data);

            data = new byte[1024];
            int len = temp.Receive(data);
            packet = Encoding.Default.GetString(data);
            form.RevPacket(packet);
        }
        
        //로그인 완료시 소켓 연결 유지
        public Socket getSocket()
        {
            return temp;
        }
        
        //로그인 실패시 소켓초기화 및 폼 초기화
        public void loginFail()
        {
            MessageBox.Show("아이디 또는 비밀번호가 맞지 않습니다.");
            temp = null;
            txtPW.Clear();
        }
        //로그인 성공
        public void loginSucces(string uNum, string uName)
        {
            islogFail = false;
            Store.myInfo.setUserNum(int.Parse(uNum));
            Store.myInfo.setUserId(txtID.Text);
            Store.myInfo.setPwd(txtPW.Text);
            Store.myInfo.setName(uName);
        }

        //소켓 설정
        public Socket setSocket()
        {
            temp = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            //IPAddress ipAddr = IPAddress.Parse("210.119.12.75");
            IPAddress ipAddr = IPAddress.Parse("127.0.0.1");
            IPEndPoint ip = new IPEndPoint(ipAddr, 5000);
            temp = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            temp.Connect(ip);

            return temp;
        }
        //회원가입 클릭

        private void btnNewAccount_Click(object sender, EventArgs e)
        {
            newAccount.Show();
            panel1.Hide();
        }
        //회원가입 취소버튼 클릭
        public void cancleNewAcount()
        {
            panel1.Show();
            newAccount.Hide();
        }
        //회원가입 실패
        public void newAccountFail()
        {
            newAccount.newAccountFail();
        }
        //회원가입 성공
        public void newAccountSuccess()
        {
            MessageBox.Show("회원가입에 성공했습니다.");
            panel1.Show();
            newAccount.Hide();
        }
        //로그인폼 종료시 메인폼 종료
        private void Login_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (islogFail)
            {
                form.Close();
            }
        }

        
    }
    
}
