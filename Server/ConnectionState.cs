using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server
{
    class ConnectionState
    {
        SqlConnection con = null;                             //DB call
        SqlCommand cmd;                                //DB command
        SqlDataReader sqlReader = null;

        StringSplit stSplit = new StringSplit();

        // 생성자
        public ConnectionState(string DBAdd, string DBPort, string DBName, string User, string password)
        {
            Connect(DBAdd, DBPort, DBName, User, password);
        }

        //기본적인 DB연결
        private void Connect(string DBAdd, string DBPort, string DBName, string User, string password)
        {
            con = new SqlConnection();
            con.ConnectionString =
                                    "server=" + DBAdd + "," + DBPort + ";"
                                    + "database=" + DBName + ";"
                                    + "uid=" + User + ";"
                                    + "pwd=" + password;
            con.Open();

            cmd = new SqlCommand();
            cmd.Connection = con;
        }



        //select 영역 시작
        //
        //01.로그인
        public UserData login(string userID)//친구 정보 불러오기: 회원번호와 닉네임만
        {
            cmd.CommandText = (@"select * from UserTable where userID= '" + userID + "'");

            sqlReader = cmd.ExecuteReader();// DB 데이터 리시버
            UserData user = new UserData();

            try
            {
                while (sqlReader.Read())//userData에 데이터 담기
                {
                    user.userID = sqlReader["userID"].ToString();
                    user.password = sqlReader["Password"].ToString();
                    user.userNum = (int)sqlReader["userNum"];
                    user.nickName = sqlReader["NickName"].ToString();
                    user.AllRoomNum = stSplit.dataCut(sqlReader["AllRoomNum"].ToString());
                    user.AllFriNum = stSplit.dataCut(sqlReader["AllFriNum"].ToString());
                    user.logState = (bool)sqlReader["LogState"];//회원 탈퇴시  널이기에 예외발생
                }
            }
            catch (Exception)
            {

                user = null;
            }
            sqlReader.Close();

            return user;
        }

        public bool userCheck(string UserID)
        {
            cmd.CommandText = (@"SELECT * FROM UserTable WHERE UserID = '" + UserID + "'");
            sqlReader = cmd.ExecuteReader();
            bool result = sqlReader.HasRows;
            sqlReader.Close();
            return result;
        }

        public string searchPassword(string userID, string NickName)
        {
            string result = null;
            cmd.CommandText = (@"SELECT NickName, Password FROM UserTable WHERE UserID = '" + userID + "'"); // 아이디로 닉네임을 찾는다
            sqlReader = cmd.ExecuteReader();
            while (sqlReader.Read())//userData에 데이터 담기
            {
                if (sqlReader["NickName"].ToString().Equals(NickName))
                {
                    result = "1|" + sqlReader["Password"].ToString() + "|";
                }
                else
                {
                    result = "0||";
                }
            }
            sqlReader.Close();
            return result;
        }
        //
        //02.친구
        public List<string> callFriends(int userNum)//친구 정보 불러오기: 회원번호와 닉네임만
        {
            List<string> result = null;
            try
            {

                cmd.CommandText = (@"select AllFriNum from UserTable where UserNum = " + userNum);
                result = stSplit.comaCut(cmd.ExecuteScalar().ToString());
                Debug.Print("callFriend");
            }
            catch (Exception)
            {
                result = new List<string>()
                {
                    ""
                };
                Debug.Print("callFriend1");
            }
            return result;
        }

        //Overloading
        public string getNickName(int userNum)
        {
            string result = null;
            try
            {
                cmd.CommandText = (@"select NickName from UserTable where UserNum = " + userNum + " and LogState IS NOT null");
                result = cmd.ExecuteScalar().ToString();
            }
            catch (Exception)
            {
                result = "알 수 없는 사람";
            }
            return result;
        }
        //
        //03.채팅             
        public List<string> roomNum(int userNum)//유저가 포함된 방번호 전송
        {
            List<string> result = null;
            try
            {
                cmd.CommandText = (@"select AllRoomNum from UserTable where UserNum = " + userNum);
                result = stSplit.comaCut(cmd.ExecuteScalar().ToString());
            }
            catch (Exception)
            {

            }
            return result;
        }

        public List<string> chatMemberByRoomNum(int roomNum)//채팅 방에 있는 인원 검색
        {
            cmd.CommandText = (@"select AllChatNum from RoomTable where RoomNum= " + roomNum);
            return stSplit.comaCut(cmd.ExecuteScalar().ToString());
        }

        public int selectNewRoom(string AllChatNum)
        {
            cmd.CommandText = (@"select RoomNum from RoomTable where AllChatNum= '" + AllChatNum + "' order by RoomNum DESC");
            return (int)cmd.ExecuteScalar();
        }

        public string selectChatMem(int roomNum) // 채팅에 참여하고 있는 멤버 찾기
        {
            cmd.CommandText = (@"SELECT AllChatNum FROM RoomTable Where RoomNum = " + roomNum);
            return cmd.ExecuteScalar().ToString();
        }

        public List<string> chattingMessageReader(int roomNum)//채팅 메시지 전송
        {
            cmd.CommandText = (@"select * from ChatTable where RoomNum= '" + roomNum + "' order by WriteTime asc");
            List<string> result = new List<string>();


            sqlReader = cmd.ExecuteReader();
            while (sqlReader.Read())
            {
                string temp = sqlReader["RoomNum"].ToString() + "?" +
                              sqlReader["UserNum"].ToString() + "?" +
                              sqlReader["Message"].ToString() + "?" +
                              sqlReader["WriteTime"].ToString() + "?";

                result.Add(temp);
            }
            sqlReader.Close();

            if (result.Count == 0)
            {
                result = new List<string>() { "null|" + roomNum };
            }

            return result;
        }
        //select 영역 끝

        //insert 영역 시작
        //
        //01.로그인
        public int joinNewUser(string UserID, string Password, string Nickname)
        {
            cmd.CommandText = (@"INSERT INTO UserTable(UserID, Password, NickName, AllRoomNum, AllFriNum, LogState)"
                            + "VALUES(" + "'" + UserID + "'," + "'" + Password + "'," + "'" + Nickname + "'," + "'', '', 0)");
            return cmd.ExecuteNonQuery();
        }
        //
        //03.채팅

        //새로운 방생성 AllChatNum(채팅참가인원) = 나,친구들
        public string newRoom(string userNum, string chatMenbers)
        {
            string temp = userNum + "," + chatMenbers;
            cmd.CommandText = (@"insert into RoomTable (AllChatNum) values('" + temp + "')");
            if (cmd.ExecuteNonQuery() > 0)
            {
                return temp;
            }
            else
            {
                return null;
            }
        }

        public int chatMsgInsert(int roomNum, int UserNum, string msg) // 채팅 DB 업데이트
        {
            cmd.CommandText = (@"INSERT INTO ChatTable (RoomNum, UserNum, Message) 
                VALUES (" + roomNum + "," + UserNum + ",'" + msg + "')");
            return cmd.ExecuteNonQuery();
        }
        public string chatTimesel(int UserNum, string msg)
        {
            cmd.CommandText = (@"SELECT WriteTime FROM ChatTable WHERE Message = '" + msg + "' AND UserNum =" + UserNum +
                " ORDER BY WriteTime DESC");
            return cmd.ExecuteScalar().ToString();
        }

        //insert 영역 끝

        //update 영역 시작
        //
        //01.로그인
        public int logStateUpdate(int userNum, bool logState)//유저 로그인 정보 갱신용
        {
            if (logState == true)
            {
                cmd.CommandText = (@"update UserTable set LogState = 0 where userNum= " + userNum);
            }
            else
            {
                cmd.CommandText = (@"update UserTable set LogState = 1 where userNum= " + userNum);
            }
            return cmd.ExecuteNonQuery();// DB 데이터 리시버
        }
        //
        //03.채팅
        public void updateNewRoom(int roomNum, int userNum)//회원의 채팅방 추가
        {
            try
            {
                cmd.CommandText = (@"update UserTable set AllRoomNum +='" + roomNum + ",' where userNum= '" + userNum + "'");
                cmd.ExecuteNonQuery();
            }
            catch (Exception)
            {
                cmd.CommandText = (@"update UserTable set AllRoomNum ='" + roomNum + ",' where userNum= '" + userNum + "'");
                cmd.ExecuteNonQuery();
            }

        }

        public void updateRoomMember(int roomNum, string userNum)//회원의 채팅방 멤버 추가
        {
            cmd.CommandText = (@"update RoomTable set AllChatNum +='" + userNum + "' where RoomNum= '" + roomNum + "'");
            cmd.ExecuteNonQuery();
        }

        // 회원 닉네임 변경*****2017.5.12
        public int NickUpdate(int UserNum, string nNick)
        {
            cmd.CommandText = (@"UPDATE UserTable SET NickName = '" + nNick + "' WHERE UserNum= " + UserNum);
            return cmd.ExecuteNonQuery();
        }

        // 회원 비밀번호 변경******2017.5.12
        public int PwdUpdate(int UserNum, string Password, string newPwd)
        {
            cmd.CommandText = (@"UPDATE UserTable SET Password = '" + newPwd +
                "' WHERE UserNum = " + UserNum + "AND Password = '" + Password + "'");
            return cmd.ExecuteNonQuery();
        }

        // 회원 탈퇴 : LogState = NULL******2017.5.12
        public int UserNULL(int UserNum, string Password)
        {
            cmd.CommandText = (@"UPDATE UserTable SET LogState = NULL WHERE UserNum = " + UserNum);
            return cmd.ExecuteNonQuery();
        }
        //
        //02.친구
        public int addFriend(int userNum, string userID)//친구 추가-UserNum는 틀라이언트, UserID는 추가할 친구 아이디
        {
            int result = 0;
            try
            {
                cmd.CommandText = (@"select UserNum from UserTable where UserID= '" + userID + "'");
                result = (int)cmd.ExecuteScalar();
            }
            catch (Exception)
            {
                return 0;
            }
            foreach (string item in fCheck(userNum))
            {
                Debug.Print(item);
                if (item.Equals(result.ToString()))
                {
                    return 0;
                }
            }
            try
            {
                cmd.CommandText = (@"update UserTable set AllFriNum += '" + result + ",' where UserNum=" + userNum);
                cmd.ExecuteNonQuery();
            }
            catch (Exception)//만약 AllFriNum이 NULL이면 작동
            {
                cmd.CommandText = (@"update UserTable set AllFriNum = '" + result + ",' where UserNum=" + userNum);
                cmd.ExecuteNonQuery();
            }

            return result;
        }

        private List<string> fCheck(int UserNum)
        {
            cmd.CommandText = (@"select AllFriNum from UserTable Where UserNum = " + UserNum);

            return stSplit.comaCut(cmd.ExecuteScalar().ToString());
        }
        //update 영역 끝


        //delete 영역

        internal void close()
        {
            if (sqlReader != null)
            {
                sqlReader.Close();
            }
            con.Close();
        }
    }
}
