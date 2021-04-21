using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client
{
    class Store
    {
        public static List<User> userlist = new List<User>();
        public static List<Friend> friendList = new List<Friend>();
        public static List<ChattingRoom> chatList = new List<ChattingRoom>();
        public static List<Message> msgList = new List<Message>();
        public static My myInfo = new My();
        public static List<File> file = new List<File>();
        
        public static void sort(List<User> list)
        {
            list.Sort(delegate (User a, User b)
            {
                string aname = a.getName();
                string bname = b.getName();
                return aname.CompareTo(bname);
            });
        }
        public static void sort(List<Friend> list)
        {
            list.Sort(delegate (Friend a, Friend b)
            {
                string aname = a.getfname();
                string bname = b.getfname();
                return aname.CompareTo(bname);
            });
        }
        
    }
    

    
    
}
