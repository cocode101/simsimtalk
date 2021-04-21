using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server
{
    class StringSplit
    {
        public List<string> tempList(string temp)//'|'이 삽입된 글 잘라서 List만드는 메서드
        {
            List<string> sendList = new List<string>();
            string[] tempSplit = temp.Split('|');
            foreach (string item in tempSplit)
            {
                sendList.Add(item.Trim());//공백 제거후 리스트에 추가
            }
            return sendList;
        }

        public List<string> dataCut(string temp)//'/'이 삽입된 글 잘라서 List만드는 메서드(AllRoomNum과 AllFriNum에 사용)
        {
            List<string> sendList = new List<string>();
            string[] tempSplit = temp.Split('/');
            foreach (string item in tempSplit)
            {
                sendList.Add(item);
            }
            return sendList;
        }

        public List<string> listCut(string temp)//'?'이 삽입된 글 잘라서 List만드는 메서드
        {
            List<string> sendList = new List<string>();
            string[] tempSplit = temp.Split('?');
            foreach (string item in tempSplit)
            {
                sendList.Add(item.Trim());//공백 제거후 리스트에 추가
            }
            return sendList;
        }

        public List<string> comaCut(string temp)//','이 삽입된 글 잘라서 List만드는 메서드
        {
            List<string> sendList = new List<string>();
            string[] tempSplit = temp.Split(',');
            foreach (string item in tempSplit)
            {
                sendList.Add(item.Trim());//공백 제거후 리스트에 추가
            }
            return sendList;
        }
    }
}
