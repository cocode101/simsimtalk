using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net.Sockets;

namespace Client
{
    public partial class NewAccount : UserControl
    {
        Login login;
        MainForm form;

        bool isIdOk = false;
        bool isPwOk = false;
        bool isPwCheckOk = false;

        public NewAccount(Login login, MainForm form)
        {
            InitializeComponent();

            Design.buttonStyle(button1);
            Design.buttonStyle(button2);

            this.login = login;
            this.form = form;
            textBox1.SetHintText("아이디 입력");
            textBox2.SetHintText("비밀번호 입력", true);
            textBox3.SetHintText("비밀번호 확인", true);
            textBox4.SetHintText("닉네임 입력");

            textBox1.TextChanged += (sender, e) =>
            {
                int length = textBox1.Text.Length;
                if (length < 4)
                {
                    isIdOk = false;
                }
                else
                {
                    isIdOk = true;
                }
            };

            textBox1.KeyPress += (sender, e) =>
            {
                char[] noIdAlpha = { ',', '.', '/', '?', '<', '>', ':', ';', '\'', '\"', '{', '[', '}', ']', '|', '\\' };

                for (int i = 0; i < noIdAlpha.Length; i++)
                {
                    if (e.KeyChar == noIdAlpha[i])
                    {
                        e.Handled = true;
                        MessageBox.Show("특수기호는 `, ~, !, @, #, $, %, ^, &, * 만 가능합니다.");
                    }
                }
            };

            textBox2.TextChanged += (sender, e) =>
            {
                string pw = textBox2.Text;
                bool isPw = passwordCheck(pw);
                if (isPw)
                {
                    label1.Text = "비밀번호가 적합합니다.";
                    label1.ForeColor = Color.Green;
                    isPwOk = true;
                }
                else
                {
                    label1.Text = "비밀번호가 적합하지 않습니다.";
                    label1.ForeColor = Color.Red;
                    isPwOk = false;
                }
            };

            textBox2.KeyPress += (sender, e) =>
            {
                char[] noIdAlpha = { ',', '.', '/', '?', '<', '>', ':', ';', '\'', '\"', '{', '[', '}', ']', '|', '\\' };

                for (int i = 0; i < noIdAlpha.Length; i++)
                {
                    if (e.KeyChar == noIdAlpha[i])
                    {
                        e.Handled = true;
                        MessageBox.Show("특수기호는 `, ~, !, @, #, $, %, ^, &, * 만 가능합니다.");
                    }
                }
            };
        

            textBox3.TextChanged += (sender, e) =>
            {
                if (textBox2.Text != textBox3.Text)
                {
                    label2.Text = "비밀번호가 동일하지 않습니다.";
                    label2.ForeColor = Color.Red;
                    isPwCheckOk = false;
                }
                else
                {
                    label2.Text = "비밀번호가 동일합니다.";
                    label2.ForeColor = Color.Green;
                    isPwCheckOk = true;
                }
            };
        }

        //회원가입 실패
        public void newAccountFail()
        {
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            MessageBox.Show("회원가입에 실패했습니다.");
        }
        //회원가입 버튼 클릭
        private void button1_Click(object sender, EventArgs e)
        {
            if (!isIdOk)
            {
                MessageBox.Show("ID가 올바르지 않습니다.");
            }
            else if (!isPwOk)
            {
                MessageBox.Show("패스워드가 올바르지 않습니다.");
            }
            else if (!isPwCheckOk)
            {
                MessageBox.Show("패스워드 확인이 올바르지 않습니다.");
            }
            else
            {
                string id = textBox1.Text;
                string pw = textBox2.Text;
                string name = textBox4.Text;

                Socket temp = login.setSocket();

                string packet = 0 + "|" + "1" + "|" + id + "|" + pw + "|" + name + "|";
                byte[] data = new byte[1024];
                data = Encoding.Default.GetBytes(packet);

                temp.Send(data);

                temp.Receive(data);
                packet = Encoding.Default.GetString(data);
                form.RevPacket(packet);
            }
        }

        //회원가입 취소
        private void button2_Click(object sender, EventArgs e)
        {
            login.cancleNewAcount();
        }
        //비밀번호 확인
        private bool passwordCheck(String pw)
        {
            int alphaCnt = 0, numCnt = 0;
            if (pw.Length <= 7)
            {
                return false;
            }
            else
            {
                for (int i = 0; i < pw.Length; i++)
                {
                    if (pw[i] >= '0' && pw[i] <= '9')
                    {
                        numCnt++;
                    }
                    else if (pw[i] >= 'a' && pw[i] <= 'z')
                    {
                        alphaCnt++;
                    }
                    else if (pw[i] >= 'A' && pw[i] <= 'Z')
                    {
                        alphaCnt++;
                    }
                }
                if (numCnt == 0 || alphaCnt == 0)
                {
                    return false;
                }
            }
            return true;
        }
    }
}
