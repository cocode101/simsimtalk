using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client
{
    public class Friend
    {
        private int fnumber;
        private string fid;
        private string fname;
     
        public int getfNum() { return this.fnumber; }
        public string getfId() { return this.fid; }
        public string getfname() { return this.fname; }
        
        public void setfNum(int fnumber) { this.fnumber = fnumber; }
        public void setfId(string fid) { this.fid = fid; }
        public void setfname(string fname) { this.fname=fname; }

        public override string ToString()
        {
            return this.fname;
        }
    }

}
