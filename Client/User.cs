using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client
{
    class User
    {
        private int uNumber;
        private string uId;
        private string uPwd;
        private string uName;
        //private List<int> AllFndNum = new List<int>();
        //private List<int> AllRoomNum = new List<int>();
        
        public int getUserNum() { return this.uNumber; }
        public void setUserNum(int userNum) { this.uNumber = userNum; }

        public string getuserId() { return this.uId; }
        public void setUserId(string uId) { this.uId = uId; }

        public string getPwd() { return this.uPwd; }
        public void setPwd(string uPwd) { this.uPwd = uPwd; }

        public string getName() { return this.uName; }
        public void setName(string uName) { this.uName = uName; }

        //public List<int> getFList() { return this.AllFndNum; }
        //public void setFList(List<int> AllFndNum) { this.AllFndNum = AllFndNum; }

        //public List<int> getRList() { return this.AllRoomNum; }
        //public void setRList(List<int> AllRoomNum) { this.AllRoomNum = AllRoomNum; }
    }
}
