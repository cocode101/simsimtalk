using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net.Sockets;

namespace Client
{
    public partial class menu_friend : UserControl
    {   
        /* 메뉴 - 친구 */

        //List<Friend> friendList = Store.friendList;
        MainForm main;
        AddFriend addFnd;

        delegate void DG();

        public menu_friend(MainForm main)
        {
            InitializeComponent();
            this.main = main;
            pntMyInfo();
            //label5.Visible = false;
            label5.Hide();
            label6.Hide();
        }
        
        private void BtnAddFriend_Click(object sender, EventArgs e)
        {   // 친구추가 버튼
            this.addFnd = new AddFriend(main, this);
            this.addFnd.Show();
        }

        public void menu_friend_Load(object sender, EventArgs e)
        {
            //LBoxFriend.Controls.Clear();
            Store.friendList = new List<Friend>();

            string packet = "1|0|" + Store.myInfo.getUserNum() + "|";   //친구 목록 갱신 요청
            main.SendStr(packet);
            //pntFriendList();
            //print();
        }
        public void pntFriendList() // 친구목록 출력
        {
            try
            {
                if (LBoxFriend.InvokeRequired)
                {
                    DG d = new DG(pntFriendList);
                    Invoke(d);
                }
                else
                {
                    LBoxFriend.Items.Clear();
                    foreach (Friend item in Store.friendList)
                    {
                        LBoxFriend.Items.Add(item.getfname());  // 친구 이름으로 출력
                                                                //MessageBox.Show(item.getfname());
                    }
                }
            }
            catch 
            {
            }
           
        }
        public void pntMyInfo() // 내 정보 출력
        {
            try
            {
                if (label3.InvokeRequired && label4.InvokeRequired)
                {
                    DG d = new DG(pntFriendList);
                    Invoke(d);
                }
                else
                {
                    label3.Text = Store.myInfo.getName();                // 이름
                    label4.Text = Store.myInfo.getuserId();              // 아이디
                    //label5.Text = Store.friendList.Count + "명";  // 친구 수
                }
            }
            catch
            {
            }            
        }

        //public void print()
        //{
        //    List<Friend> fList = Store.friendList;
        //    string id;
        //    string name;
        //    foreach (Friend friend in fList)
        //    {
        //        id = friend.getfId();
        //        name = friend.getfname();
        //        string[] str = { id, name };

        //        ListView lvItem = new ListView();
        //        //lvItem.text
        //        //lvFriendList.Items.Add(lbItem);
        //    }   
        //}

        //서버로부터 친구 목록 수신
        public void FriendList(string fndList, bool isLast)
        {
            //마지막 목록일 경우 친구 목록 출력
            if (isLast)
            {
                pntFriendList();
                pntMyInfo();
                return;
            }

            string[] fndInfo = fndList.Split('?');
            
            Friend friend = new Friend();
            friend.setfNum(int.Parse(fndInfo[0]));
            friend.setfname(fndInfo[1]);
            Store.friendList.Add(friend);            
        }

        //친구 추가 성공시 친구 목록에 추가
        public void FriendAddSuccess(string fNum, string fName)
        {
            Friend friend = new Friend();
            friend.setfname(fName);
            friend.setfNum(int.Parse(fNum));
            //friend.setfId(addFnd.getFid());
            Store.friendList.Add(friend);
            Store.sort(Store.friendList);
            this.addFnd.Close();
            pntFriendList();
            pntMyInfo();
            friend = null;
        }
    }
}
