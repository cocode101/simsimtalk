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
    public partial class AddChatRoom : Form
    {   
        /* 채팅방 생성 */
        //ChatRoom cRoom;
        List<Friend> friendList = Store.friendList;
        List<Friend> memberList = new List<Friend>();
        menu_chatting menu_chatting;
        MainForm main;

        public AddChatRoom(MainForm main, menu_chatting menu_chatting)
        {
           
            this.menu_chatting = menu_chatting;

            InitializeComponent();
            this.main = main;
            foreach(Friend item in friendList)
            {   // 친구목록 출력
                //checkedListBox1.Items.Add(item.getfId() + " : " + item.getfname());
                checkedListBox1.Items.Add(item.getfname());
            }
            Design.buttonStyle(btnAdd);
        }
        
        private void btnAdd_Click(object sender, EventArgs e)
        {
            /* 채팅방 생성 버튼 */
            
            List<User> cMember = new List<User>();
            string packet = "2|1|" + Store.myInfo.getUserNum() + "|";
            /* 채팅방 멤버 설정 */
            for (int i=0; i<=(checkedListBox1.Items.Count)-1; i++)
            {
                if (checkedListBox1.GetItemChecked(i))
                {   // 체크된 친구를 채팅방 멤버로 추가
                    int num = Store.friendList[i].getfNum();
                    memberList.Add(Store.friendList.Single((x) => x.getfNum() == num));
                    packet += num + ",";
                    //User user = null;
                    //foreach(User item in Store.userlist)
                    //{
                    //    if(num.Equals(item.getUserNum()))
                    //    {
                    //        user = item;
                    //    }
                    //}
                    //cMember.Add(user);
                }
            }
            packet += "|";
            main.SendStr(packet);
            //User my = null;
            //foreach(User item in Store.userlist)
            //{
            //    if (Store.myInfo.getUserNum().Equals(item.getUserNum()))
            //        my = item;
            //}
            //cMember.Add(my); // 방 멤버에 본인 추가

            /* 채팅방 리스트에 추가 */
            //ChattingRoom chatRoom = new ChattingRoom(main, rNum);

            //int cnt = Store.chatList.Count;
            //chatRoom.setRoomNum(cnt);
            //chatRoom.setDateTime(DateTime.Today);
            //chatRoom.setMembers(cMember);
            //Store.chatList.Add(chatRoom);
            
            /* 각 멤버들의 채팅방 리스트에 추가 */
            /*
            for(int i=0; i<Store.userlist.Count;i++)
            {
                for(int j=0; j<cMember.Count; j++)
                {
                    if(cMember.ElementAt(j) == Store.userlist[i])
                    {
                        Store.userlist[i].getRList().Add(chatRoom.getRoomNum());
                    }
                }
            }
            */
            //Store.chatList.Add(chatRoom); // 본인의 채팅방리스트에 채팅방 정보 추가
            
            //cRoom = new ChatRoom(chatRoom.getRoomNum());
            //cRoom.Show();
            //menu_chatting.pntRoomList();            // 메뉴-채팅 창에 채팅방 목록 출력

            //this.Close();
        }

        public List<Friend> getMemberList()
        {
            return memberList;  //채팅방 생성 성공시 채팅방 멤버 리턴
        }
        private void AddChat_Load(object sender, EventArgs e)
        {
            /* 인원 체크 유무에 따른 방생성 버튼 활성화 */
            btnAdd.Enabled = false;
        }
        
        private void checkedListBox1_MouseUp(object sender, MouseEventArgs e)
        {
            /* 인원 체크 유무에 따른 방생성 버튼 활성화 */
            if (checkedListBox1.CheckedItems.Count == 0)    // 체크된 멤버 없을 시 버튼 비활성화
            {   
                btnAdd.Enabled = false;
            }
            else
            {
                btnAdd.Enabled = true;
            }
        }
    }
}
