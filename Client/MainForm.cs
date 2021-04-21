using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace Client
{
    public partial class MainForm : Form
    {
        Socket client;
        //bool isThreadRun = true;
        Thread thread = null;

        Login login;

        menu_friend fnd;
        menu_chatting chat;
        menu_option opt;

        List<User> userlist = Store.userlist;
        List<Friend> friendList = Store.friendList;

        public bool isLogout = false;
        public bool isUserDrop = false;
               
        public MainForm()
        {
            InitializeComponent();
            //initView();
            this.Resize += Form_Resize;
            login = new Login(this);
            login.ShowDialog();

            fnd = new menu_friend(this);
            chat = new menu_chatting(this);
            opt = new menu_option(this);
            panel2.Controls.Add(fnd);
            panel2.Controls.Add(chat);
            panel2.Controls.Add(opt);

            // 로그인 시, 기본화면은 친구창
            fnd.Visible = true;
            chat.Visible = false;
            opt.Visible = false;

            setBtnColor(btnFriend, pnlFriend);
            setBtnDefault(btnChatting, pnlChat);
            setBtnDefault(btnOption, pnlOpt);

            notifyIcon1.ContextMenuStrip = this.contextMenuStrip1;
            notifyIcon1.Visible = false;
            this.ShowInTaskbar = true;
        }

        // 메인폼 전환 시
        public MainForm(MainForm pastMain)
        {
            InitializeComponent();

            Program.ac.MainForm = this; // 메인폼 전환
            pastMain.Close();   // 이전메인폼 닫기

            //initView();
            login = new Login(this);
            login.ShowDialog();

            fnd = new menu_friend(this);
            chat = new menu_chatting(this);
            opt = new menu_option(this);
            panel2.Controls.Add(fnd);
            panel2.Controls.Add(chat);
            panel2.Controls.Add(opt);

            // 로그인 시, 기본화면은 친구창
            fnd.Visible = true;
            chat.Visible = false;
            opt.Visible = false;
            setBtnColor(btnFriend, pnlFriend);
            setBtnDefault(btnChatting, pnlChat);
            setBtnDefault(btnOption, pnlOpt);
        }
        private void initView()
        {
            login = new Login(this);
            login.ShowDialog();

            fnd = new menu_friend(this);
            chat = new menu_chatting(this);
            opt = new menu_option(this);
            panel2.Controls.Add(fnd);
            panel2.Controls.Add(chat);
            panel2.Controls.Add(opt);

            // 로그인 시, 기본화면은 친구창
            fnd.Visible = true;
            chat.Visible = false;
            opt.Visible = false;

            setBtnColor(btnFriend, pnlFriend);
            setBtnDefault(btnChatting, pnlChat);
            setBtnDefault(btnOption, pnlOpt);
        }

        // 서버로 패킷 전송
        public void SendStr(string packet)
        {
            byte[] data = new byte[1024];
            data = Encoding.Default.GetBytes(packet);
            client.Send(data);
        }
               

        // 서버로부터 패킷 수신 스레드
        public void DataReceive()
        {
            string packet;
            byte[] data; //= new byte[1024];
            //while (isThreadRun)
            while(true)
            {
                packet = null;
                data = new byte[1024];
                if (client.Connected == false)
                {
                    break;
                }
                try
                {
                    int len = client.Receive(data);
                    if (len == 0)
                    {
                        break;
                    }
                }
                catch (Exception)
                { }
                
                //lock (this)
                //{
                packet = Encoding.Default.GetString(data);
                RevPacket(packet);
                //}

            }            
        }

        ////스레드 종료
        //private void threadOff()
        //{
        //    isThreadRun = false;
        //    if (thread != null)
        //    {
        //        thread.Join();
        //    }
        //}

        //수신된 패킷 처리->각 메뉴별로 메소드 호출
        public void RevPacket(string packet)
        {
            //MessageBox.Show(packet);
            string[] str = packet.Split('|');
            switch (str[0])
            {
                case "0":   // 로그인
                    logMenu(str);
                    break;
                case "1":   // 친구
                    FriMenu(str);
                    break;
                case "2":   // 채팅
                    ChatMenu(str);
                    break;
                case "3":   // 설정
                    optMenu(str);
                    break;
            }
        }

        //로그인 폼 
        private void logMenu(string[] str)
        {
            switch (str[1])
            {
                case "0":  //로그인 
                    if (str[2].Equals("0"))                     //로그인 실패
                    {
                        login.loginFail();
                    }
                    else if (str[2].Equals("1"))                //로그인 성공
                    {
                        client = login.getSocket();
                        login.loginSucces(str[3], str[4]);
                        login.Close();
                        thread = new Thread(DataReceive);
                        thread.Start();
                    }
                    break;
                case "1":   //회원가입
                    if (str[2].Equals("0"))                     // 회원가입 실패
                    {
                        login.newAccountFail();
                    }
                    else if (str[2].Equals("1"))                // 회원가입 성공
                    {
                        login.newAccountSuccess();
                    }
                    break;
            }
        }

        //친구 메뉴
        private void FriMenu(string[] str)
        {
            switch (str[1])
            {
                case "0":   //친구 목록 갱신
                    if (str[2].Equals("0"))         //마지막 친구목록
                    {
                        Cursor = Cursors.Default;
                        fnd.FriendList(null, true);
                    }
                    else if (str[2].Equals("1"))    //친구목록
                    {
                        Cursor = Cursors.WaitCursor;
                        fnd.FriendList(str[3], false);
                    }
                    break;
                case "1":   //친구 추가
                    if (str[2].Equals("0"))         //친구 추가 실패
                    {
                        MessageBox.Show("존재하지 않는 ID이거나 추가된 친구입니다.");
                    }
                    else if (str[2].Equals("1"))    //친구 추가 성공
                    {
                        fnd.FriendAddSuccess(str[3], str[4]);
                        MessageBox.Show("추가되었습니다.");
                    }
                    break;
            }
        }

        //체팅 메뉴
        private void ChatMenu(string[] str)
        {
            switch (str[1])
            {
                case "0":   // 채팅방 목록 갱신
                    if (str[2].Equals("0"))         // 마지막 채팅방 목록
                    {   /* 2 | 0 | 0 | */
                        Cursor = Cursors.Default;
                        chat.ChatList(null, null, true);
                    }
                    else if (str[2].Equals("1"))    // 채팅방 목록
                    {   /* 2 | 0 | 0 | 방번호 | 친구목록 | */
                        Cursor = Cursors.WaitCursor;
                        chat.ChatList(str[3], str[4], false);
                    }
                    break;
                case "1":   // 채팅방 생성
                    if (str[2].Equals("0"))         // 채팅방 생성 실패
                    {   /* 2 | 1 | 0 | */
                        MessageBox.Show("채팅방을 생성할 수 없습니다");
                    }
                    else if (str[2].Equals("1"))    //채팅방 목록 생성 성공
                    {   /* 2 | 1 | 1 | 방번호 | */
                        chat.NewChat(str[3]);
                    }
                    break;
                case "2":   // 기존 메시지 수신
                    if (str[2].Equals("0"))         // 메시지 수신 실패 
                    {   /* 2 | 2 | 0 | 방번호 | */
                        Cursor = Cursors.Default;
                        chat.RevDataBaseMessage(str[3], null, null, null, true);
                    }
                    else if (str[2].Equals("1"))    // 메시지 수신 성공 
                    {   /* 2 | 2 | 1 | 방번호 | 유저번호 | 메시지 | 시간 | */
                        Cursor = Cursors.WaitCursor;
                        string msg = str[5].Replace("a9siw4kr9", "|");
                        chat.RevDataBaseMessage(str[3], str[4], msg, str[6],false);
                    }
                    break;
                case "3":   // 방 멤버 추가
                    if (str[2].Equals("0"))         // 멤버 추가 실패 
                    {   /* 2 | 3 | 0 | 방번호 | */
                        MessageBox.Show("멤버추가 실패");
                        //chat.AddChatMember(str[3], null, true);
                    }
                    else if (str[2].Equals("1"))    // 멤버 추가 성공
                    {   /* 2 | 3 | 1 | 방번호 | 유저번호?유저이름/유저번호?유저이름/ | */
                        chat.AddChatMember(str[3], str[4]);
                        
                    }
                    break;
                case "4":   // 신규 메시지 수신
                    if (str[2].Equals("0"))         // 메시지 수신 실패 
                    {   /* 2 | 2 | 0 | */
                        MessageBox.Show("서버 연결 상태 불량");
                    }
                    else if (str[2].Equals("1"))    // 메시지 수신 성공 
                    {   /* 2 | 2 | 1 | 방번호 | 유저번호 | 메시지 | 시간 | */
                        string msg = str[5].Replace("a9siw4kr9", "|");
                        chat.RevMessage(str[3], str[4], msg, str[6]);
                    }
                    break;
            }
        }
        private void optMenu(string[] str)
        {
            switch(str[1])
            {
                case "0":
                    if (str[2].Equals("0"))
                    {
                        MessageBox.Show("로그아웃 실패");
                    }
                    else if (str[2].Equals("1"))
                    {
                        client.Disconnect(true);
                        if (thread != null)
                        {
                            thread.Abort();
                        }
                    }
                    break;
                case "1":   // 닉네임 변경
                    {
                        if (str[2].Equals("0"))
                            MessageBox.Show("변경 실패하였습니다.");

                        else if(str[2].Equals("1"))
                        {
                            Store.myInfo.setName(str[3]); // my정보 수정
                            MessageBox.Show("이름이 변경되었습니다.");
                        }
                        break;
                    }
                case "2":   // 비밀번호 변경
                    if (str[2].Equals("0"))
                    {
                        MessageBox.Show("비밀번호가 맞지 않습니다.");
                    }
                    else if (str[2].Equals("1"))
                    {
                        opt.cPwd.changePassword();
                    }
                    break;
                case "3":   // 회원탈퇴
                    
                    if (str[2].Equals("0"))
                    {
                        opt.drop.isDrop(false);
                        MessageBox.Show("정보가 올바르지 않습니다.");
                    }
                    else if (str[2].Equals("1"))
                    {
                        opt.drop.isDrop(true);
                        isUserDrop = true;
                        this.Close();
                        //MessageBox.Show("탈퇴되었습니다.");
                    }
                    break;
            }
        }
        //폼종료시 소켓 접속 종료 및 스레드 종료
        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            //client.Close();
            //threadOff();
            //thread.Abort();

            if (!isUserDrop)
            {
                if (!isLogout)
                {
                    if (MessageBox.Show("종료 하시겠습니까?", "종료", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        string packet = "3|0|" + Store.myInfo.getUserNum() + "|";
                        this.SendStr(packet);

                        //mainCloseMethod.mainFromClose(this);
                        client.Disconnect(false);
                        thread.Abort();

                        //for (int i = 0; i < 100000; i++)
                        //{
                        //    if (client.Connected)
                        //    {
                        //        return;
                        //    }
                        //}

                        //e.Cancel = true;
                    }
                    else
                    {
                        e.Cancel = true;
                    }
                }
            }
                        
        }
        

        /* 버튼 디자인 */
        private void btnFriend_Click(object sender, EventArgs e)
        {
            // 친구메뉴 버튼

            setBtnColor(btnFriend, pnlFriend);
            setBtnDefault(btnChatting, pnlChat);
            setBtnDefault(btnOption, pnlOpt);

            fnd.Visible = true;
            chat.Visible = false;
            opt.Visible = false;

            fnd.menu_friend_Load(sender, e);
            fnd.pntMyInfo();
        }
        private void btnChatting_Click(object sender, EventArgs e)
        {
            // 대화메뉴 버튼

            setBtnColor(btnChatting, pnlChat);
            setBtnDefault(btnFriend, pnlFriend);
            setBtnDefault(btnOption, pnlOpt);

            fnd.Visible = false;
            chat.Visible = true;
            opt.Visible = false;

            chat.menu_chatting_Load(sender, e);
        }
        private void btnOption_Click(object sender, EventArgs e)
        {
            // 설정메뉴 버튼

            setBtnColor(btnOption, pnlOpt);
            setBtnDefault(btnFriend, pnlFriend);
            setBtnDefault(btnChatting, pnlChat);

            fnd.Visible = false;
            chat.Visible = false;
            opt.Visible = true;
        }
        private void setBtnColor(Button btn, Panel pnl)
        {
            // 버튼 색
            btn.ForeColor = Color.ForestGreen;
            btn.Font = new Font(btn.Font, FontStyle.Bold);

            pnl.BackColor = Color.YellowGreen;
        }
        private void setBtnDefault(Button btn, Panel pnl)
        {
            // 버튼 색(Default)

            //btn.BackColor = default(Color);
            btn.ForeColor = Color.DarkSeaGreen;
            //btn.ForeColor = default(Color);
            btn.Font = new Font(btn.Font, FontStyle.Bold);
            pnl.BackColor = Color.Gainsboro;
        }


        public void Form_Resize(object sender, EventArgs e)
        {
            if (FormWindowState.Minimized == this.WindowState)
            {
                notifyIcon1.Visible = true; // tray icon 표시
                this.Hide();
            }
            else if (FormWindowState.Normal == this.WindowState)
            {
                notifyIcon1.Visible = false;
                this.ShowInTaskbar = true; // 작업 표시줄 표시
            }
        }

        private void notifyIcon1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            this.Show();
            this.WindowState = FormWindowState.Normal;
        }

        private void ExitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
