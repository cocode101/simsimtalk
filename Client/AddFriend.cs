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
    public partial class AddFriend : Form
    {
        //List<User> uList = Store.userlist;
        List<Friend> fList = Store.friendList;
        menu_friend fnd;
        MainForm main;

        public AddFriend(MainForm main, menu_friend fnd)
        {
            InitializeComponent();
            this.fnd = fnd;
            this.main = main;
            Design.buttonStyle(btnAdd);
        }
        
        private void btnAdd_Click(object sender, EventArgs e)
        { 
            /* 친구 등록하기 버튼 */
            
            //Friend friend = new Friend();
            bool isFriend=false;

            /* 친구 등록 */
            if (txtId.Text == "") { MessageBox.Show("아이디를 입력해주세요."); }
            else if (txtId.Text == Store.myInfo.getuserId()) { MessageBox.Show("본인은 추가할 수 없습니다."); }
            else
            {   
                //int size = fList.Count;
                //int i = 0;
                //while (i < size) // 친구 유무 검색
                //{
                //    if (txtId.Text == fList[i].getfId())
                //    {
                //        MessageBox.Show("등록된 친구있습니다.");
                //        isFriend = true;
                //        break;
                //    }
                //    i++;
                //}

                //i = 0;
                //if (isFriend == false) // 등록안된 친구
                //{
                    
                    string packet = "1|1|" + Store.myInfo.getUserNum() + "|" + txtId.Text + "|";
                    main.SendStr(packet);
                    /*
                    for (i = 0; i < uList.Count; i++)
                    {
                        if (txtId.Text == uList[i].getuserId()) // 같은 아이디 발견
                        {
                            User user = uList[i];
                            friend.setfId(user.getuserId());
                            friend.setfNum(user.getUserNum());
                            friend.setfname(user.getName());

                            Store.myInfo.addFriend(friend); // 내 정보에 추가
                            fList.Add(friend);              // 친구목록에 추가

                            Store.sort(fList);

                            txtId.Text = null;
                            fnd.pntFriendList();    // 메뉴-친구 친구목록 출력
                            break;
                        }
                    }
                    if (i == uList.Count)
                        MessageBox.Show("존재하지 않는 아이디입니다.");
                    */
            //    }
            }
            
        }
        //친구 추가 성공시 아이디 저장
        public string getFid()
        {
            return txtId.Text;
        }
    }
}
