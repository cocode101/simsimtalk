using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace test03
{/*
    public static class PrintList
    {
        public static void print_friendList(this ListBox listBox, List<Friend> list) // 친구리스트 출력
        {
            listBox.Items.Clear();

            foreach (Friend item in list)
                listBox.Items.Add(item.getfname());
        }
        public void prient_chattinList() // 채팅방 출력
        {
            lboxChattingRoom.Items.Clear();

            List<int> rList = Store.myInfo.getRList();
            for (int i = 0; i < rList.Count; i++)
            {
                int rNum = rList.ElementAt(i);
                lboxChattingRoom.Items.Add(rNum);

            }
        }
        public void print_addMemberList()
        { // 채팅방 생성 시 친구리스트 출력
            foreach (Friend item in friendList)
            {
                checkedListBox1.Items.Add(item.getfname());
            }
        }
        public void print_memberList() // 채팅방 멤버 출력
        {
            listBox1.Items.Clear();
            List<ChattingRoom> cList = Store.chatList;
            List<int> members = cList[rNumber].getMembers();

            for (int i = 0; i < members.Count; i++)
            {
                for (int j = 0; j < Store.userlist.Count; j++)
                {
                    if (members.ElementAt(i) == Store.userlist[j].getUserNum())
                    {
                        listBox1.Items.Add(Store.userlist[j].getName());

                    }
                }
            }
        }
        public void print_addMember() // 채팅방 멤버 추가
        {
            for (int i = 0; i < friendList.Count; i++)
            {
                int fnum = friendList.ElementAt(i).getfNum(); // 친구 아이디
                List<int> members = Store.chatList.ElementAt(rNumber).getMembers();

                bool check = members.Contains(fnum);

                if (!check)
                    checkedListBox1.Items.Add(friendList.ElementAt(i).getfname());
            }
        }
    }*/
}
