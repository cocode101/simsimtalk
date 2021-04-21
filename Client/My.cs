using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client
{
    class My
    {   
        // 임시 저장
        //private int userNum = 1;
        //private string userId = "id1";
        //private string userPwd = "1234";
        //private string userName = "가나파이";

        private int userNum;
        private string userId;
        private string userPwd;
        private string userName;

        private List<Friend> AllFndNum=new List<Friend>();
        private List<ChattingRoom> AllRoomNum = new List<ChattingRoom>();

        public int getUserNum() { return this.userNum; }
        public void setUserNum(int userNum) { this.userNum = userNum; }

        public string getuserId() { return this.userId; }
        public void setUserId(string userId) { this.userId = userId; }

        public string getPwd() { return this.userPwd; }
        public void setPwd(string userPwd) { this.userPwd = userPwd; }

        public string getName() { return this.userName; }
        public void setName(string userName) { this.userName = userName; }

        public List<Friend> getFList() { return this.AllFndNum; }
        public void setFList(List<Friend> AllFndNum) { this.AllFndNum = AllFndNum; }

        public List<ChattingRoom> getRList() { return this.AllRoomNum; }
        public void setRList(List<ChattingRoom> AllRoomNum) { this.AllRoomNum = AllRoomNum; }

        public void addFriend(Friend friend) { this.AllFndNum.Add(friend); }
        public void addChattRoom(ChattingRoom chat) { this.AllRoomNum.Add(chat); }

        
    }
}
