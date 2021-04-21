using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Server
{
    public partial class ServerMain : Form
    {
        ConnectionState con = null;
        ServerState server = null;


        public ServerMain()
        {
            InitializeComponent();

        }

        //크로스 스레드 현상을 막기 위한 작업
        delegate void UpdateTextCallback(string msg);

        //화면 값 변경 (동기화 문제 해결) Thread에서 사용
        internal void AppendMessage(string msg)
        {
            try
            {
                if (resultTextBox.InvokeRequired)
                {
                    UpdateTextCallback d = new UpdateTextCallback(AppendMessage);
                    Invoke(d, new object[] { msg });
                }
                else
                {
                    resultTextBox.AppendText(msg);
                    resultTextBox.AppendText("\r\n");
                }
            }
            catch { }
        }

        public void clientCount()
        {
            toolStripLabel6.Text = ServerState.threadBySocket.Count.ToString();
        }//접속인원 표시

        private void serverButton_Click(object sender, EventArgs e)
        {
            resultTextBox.AppendText("=======================================\n");
            resultTextBox.AppendText("서버생성 시도 : " + serverIPTextBox.Text + "\n");
            resultTextBox.AppendText("=======================================\n");
            try
            {
                server = new ServerState(serverIPTextBox.Text, int.Parse(serverPortTextBox.Text), this);
                if (con != null)
                {
                    server.conRecive(con);
                }
                resultTextBox.AppendText("서버생성 성공 : " + serverIPTextBox.Text + "\n");
                toolStripLabel4.Text = "연결 중...";
            }
            catch (Exception ex)
            {
                resultTextBox.AppendText("서버 생성 실패" + ex.Source + "\n");
            }
            finally
            {
                resultTextBox.AppendText("=======================================\n");
            }
            serverButton.Enabled = false;
            serverCutButton.Enabled = true;
        }//server 연결

        private void serverCutButton_Click(object sender, EventArgs e)
        {
            server.serverStop();
            toolStripLabel4.Text = "연결 대기";
            serverButton.Enabled = true;
            serverCutButton.Enabled = false;
        }//server 연결 해제

        private void DBButton_Click(object sender, EventArgs e)
        {
            //서버연결함
            resultTextBox.AppendText("=======================================\n");
            resultTextBox.AppendText("DB연결 시도 : " + DBIPTextBox.Text + "\n");
            resultTextBox.AppendText("=======================================\n");
            try
            {
                con = new ConnectionState(DBIPTextBox.Text, DBPortTextBox.Text, DBNameTextBox.Text, userIDTextBox.Text, passwordTextBox.Text);
                if (server != null)//서버에 DB정보 전달자
                {
                    server.conRecive(con);
                }
                resultTextBox.AppendText("DB연결 성공, 사용포트 : " + DBPortTextBox.Text + "\n");
                toolStripLabel3.Text = "연결 중...";
                DBButton.Enabled = false;
                DBCutButton.Enabled = true;
            }
            catch (Exception ex)
            {
                resultTextBox.AppendText("DB연결 실패" + ex.Source + "\n");
            }
            finally
            {
                resultTextBox.AppendText("=======================================\n");
            }
        }//DB 연결

        private void DBCutButton_Click(object sender, EventArgs e)
        {
            con.close();
            toolStripLabel3.Text = "연결 대기";
            DBButton.Enabled = true;
            DBCutButton.Enabled = false;
        }//DB 연결 해제

        private void serverIPTextBox_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
