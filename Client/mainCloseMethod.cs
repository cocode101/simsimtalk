using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client
{
    class mainCloseMethod
    {
        public static void mainFromChange(MainForm pastMain)
        {
            // 메인폼 전환
            try
            {
                MainForm newMain = new MainForm(pastMain);

                Store.chatList = new List<ChattingRoom>();
                Store.friendList = new List<Friend>();
                Store.msgList = new List<Message>();

                newMain.Show();
            }
            catch (Exception) { }
            
        }
        public static void mainFromClose(MainForm main)
        {
            try
            {
                
                string packet = "3|0|" + Store.myInfo.getUserNum() + "|";
                main.SendStr(packet);

                Store.chatList = new List<ChattingRoom>();
                Store.friendList = new List<Friend>();
                Store.msgList = new List<Message>();

                //main.Close();
            }
            catch (Exception) { }
        }
    }
}
