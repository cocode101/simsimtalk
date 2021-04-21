using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server
{
    class UserData
    {
        //유저 기본 정보
        public int userNum;
        public string userID;
        public string password;
        //유저 닉네임
        public string nickName;
        //대화방 목록
        public List<string> AllRoomNum;
        //친구 목록
        public List<string> AllFriNum;

        public bool logState;
    }
}
