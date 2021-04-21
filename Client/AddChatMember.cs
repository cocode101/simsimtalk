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
    public partial class AddChatMember : Form
    {
        /* 채팅방 인원 추가 */

        List<Friend> friendList = Store.friendList;
        int rNumber;            // 방 번호
        ChatMember chatMember;
        MainForm main;
        List<Friend> members;

        public AddChatMember(MainForm main, ChatMember chatMember, int rNumber)
        {
            this.rNumber = rNumber;
            this.chatMember = chatMember;
            this.main = main;
            InitializeComponent();
            Design.buttonStyle(btnAdd);
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            /* 방 인원 추가 버튼 */
            //int cnt=0;
            // 현재 방 인원 리스트
            string packet = "2|3|" + rNumber + "|";

            for (int i = 0; i <= (checkedListBox1.Items.Count) - 1; i++)
            {
                if (checkedListBox1.GetItemChecked(i))
                {
                    Friend item;
                    item = checkedListBox1.Items[i] as Friend;

                    int userNumber = item.getfNum();
                    packet += userNumber + ",";
                    /*
                    string uName = checkedListBox1.Items[i].ToString();
                    //int uNumber = i;
                    //for(int j=0; j<friendList.Count; j++)
                    //{

                    Friend friend = friendList.Single((x) => x.getfname().Equals(uName));
                    packet += friend.getfNum() + ",";
                    */

                    //    //int fNumber = friend.getfNum();
                    //    //Friend user=null;
                    //    //foreach(Friend item in Store.friendList)
                    //    //{
                    //    //    if(item.getfNum().Equals(fNumber))
                    //    //    {
                    //    //        user = item;
                    //    //    }
                    //    //}

                    //    //bool isMember = false;

                    //    // 채팅방 인원인지 아닌지 체크
                    //    //isMember = members.Contains(user);
                    //    //foreach (User member in members)
                    //    //{
                    //    //    int userNum = member.getUserNum();
                    //    //    if (userNum.Equals(fNumber))
                    //    //    {
                    //    //        isMember = true;
                    //    //    }
                    //    //}

                    //    // 채팅방 인원이 아니면 ..
                    //    //if (!isMember)
                    //    //{
                    //    //    if(uNumber == cnt)
                    //    //    {
                    //    //        members.Add(user);
                    //    //        cnt++;
                    //    //        break;

                    //    //    }
                    //    //    cnt++;
                    //    //}
                    //}

                }
            }
            packet += "|";
            main.SendStr(packet);
            //Store.chatList.ElementAt(rNumber).setMembers(members);

            //chatMember.pntList();

            //this.Close();
        }

        private void AddChatMember_Load(object sender, EventArgs e)
        {
            /* 추가할 멤버리스트 출력 - 채팅방 멤버 아닌 친구 */
            ChattingRoom chatRoom = Store.chatList.Single((X) => X.getRoomNum() == rNumber);
            members = chatRoom.getMembers();

            for (int i=0; i<friendList.Count; i++)
            {
                int fnum = friendList.ElementAt(i).getfNum();                

                bool isMember = false;
                foreach (Friend member in members)
                {
                    int userNum = member.getfNum();
                    if (userNum == fnum)
                        isMember = true;
                }


                //if (!isMember)
                //    checkedListBox1.Items.Add(friendList.ElementAt(i).getfname());
                if (!isMember)
                    checkedListBox1.Items.Add(friendList.ElementAt(i));
            }
        }

    }
}
