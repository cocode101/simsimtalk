using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Client
{
    public class Message
    {
        private int rNum;
        private int id;
        private string msg;
        private DateTime time;
        
        public Message(int uNum, string msg, DateTime time)
        {
            this.id = uNum;
            this.msg = msg;
            this.time = time;
        }

        public Message(int rNum, int uNum, string msg, DateTime time)
        {
            this.rNum = rNum;
            this.id = uNum;
            this.msg = msg;
            this.time = time;
        }

        public int getRoomNum() { return this.rNum; }
        public int getId() { return this.id; }
        public string getMsg() { return this.msg; }
        public DateTime getTime() { return this.time; }
    }
}
