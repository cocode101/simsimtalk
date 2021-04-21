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
    public partial class ChatMember : Form
    {
        /* 채팅방 인원 목록 */

        int rNumber; // 채팅방 고유번호        
        MainForm main;
        AddChatMember addChatMember;

        delegate void delegatePrintMemberList();

        public ChatMember(MainForm main, int rNumber)
        {
            this.rNumber = rNumber;
            this.main = main;
            InitializeComponent();
            pntList();
            Design.buttonStyle(btnAdd);
        }

        private void btnAdd_Click(object sender, EventArgs e)
        { 
            /* 방 인원 추가 버튼 */

            addChatMember = new AddChatMember(main, this, rNumber);
            addChatMember.Show();
        }

        public void addMember()
        {
            addChatMember.Close();
            pntList();
        }

        public void pntList()
        {
            /* 채팅방 인원 리스트 출력 */

            try
            {
                if(listBox1.InvokeRequired)
                {
                    delegatePrintMemberList d = new delegatePrintMemberList(pntList);
                    Invoke(d);
                }
                else
                {
                    listBox1.Items.Clear();

                    ChattingRoom chatRoom = Store.chatList.Single((X) => X.getRoomNum() == rNumber);
                    List<Friend> members = chatRoom.getMembers();

                    foreach (Friend friend in members)
                    {
                        listBox1.Items.Add(friend.getfname());
                    }
                }
            }
            catch  { }

            

            //for(int i=0; i<members.Count;i++)
            //{
            //    for(int j=0; j<Store.userlist.Count;j++)
            //    {
            //        if(members.ElementAt(i) == Store.userlist[j])
            //        {
            //            listBox1.Items.Add(Store.userlist[j].getName());

            //        }
            //    }
            //}
        }


        //public void pntList()
        //{
        //    /* 채팅방 인원 리스트 출력 */

        //    listBox1.Items.Clear();

        //    ChattingRoom chatRoom = Store.chatList.Single((X)=> X.getRoomNum() == rNumber);
        //    List<Friend> members = chatRoom.getMembers();

        //    foreach(Friend friend in members)
        //    {
        //        listBox1.Items.Add(friend.getfname());
        //    }


        //    //for(int i=0; i<members.Count;i++)
        //    //{
        //    //    for(int j=0; j<Store.userlist.Count;j++)
        //    //    {
        //    //        if(members.ElementAt(i) == Store.userlist[j])
        //    //        {
        //    //            listBox1.Items.Add(Store.userlist[j].getName());

        //    //        }
        //    //    }
        //    //}
        //}

    }
}
