using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Client
{
    public static class lblSubMethod
    {
        public static void SetHintText(this TextBox textBox, string hintText = "내용을 입력해주십시오.", bool isPw = false)
        {
            var hintTextColor = System.Drawing.SystemColors.GrayText;

            textBox.Text = hintText;
            textBox.ForeColor = hintTextColor;
            textBox.Leave += (sender, e) =>
            {
                var tb = sender as TextBox;

                if (tb != null && tb.Text.Length == 0)
                {
                    tb.Text = hintText;
                    tb.ForeColor = hintTextColor;
                    if (isPw)
                    {
                        tb.PasswordChar = '\0';
                    }
                }
            };
            textBox.Enter += (sender, e) =>
            {
                var tb = sender as TextBox;

                if (tb != null && tb.Text == hintText)
                {
                    tb.Text = string.Empty;
                    tb.ForeColor = System.Drawing.SystemColors.WindowText;
                }
                if (isPw)
                {
                    tb.PasswordChar = '*';
                }
            };
        }

        public static int textAppend(this Label label, string msg)
        {
            label.Text = "";
            int length = 0;
            int i = 0, j = 0, wordCnt = 0;
            foreach (char c in msg)
            {
                if (Char.GetUnicodeCategory(c).ToString() == "OtherLetter")
                {
                    length = length + 2;
                }
                else
                {
                    length = length + 1;
                }
                //MessageBox.Show("length = " + length);
                wordCnt++;
                if (length >= 17)
                {
                    
                    string temp = msg.Substring(0, wordCnt);
                    //string temp = msg.Substring(0, j);
                    msg = msg.Remove(0, wordCnt);
                    //msg = msg.Remove(0, j);
                    label.Text += temp + "\r\n";
                    //cnt++;
                    length = 0;
                    wordCnt = 0;
                }
                
            }
            label.Text += msg;
            return wordCnt;

        }
        //label.Text = "";
        //    int numberOfLine = msg.Length / 20;
        //    for (int i = 0; i < numberOfLine; i++)
        //    {
        //        string temp = msg.Substring(0, 20);
        //        msg = msg.Remove(0, 20);
        //        label.Text += temp + "\r\n";
        //    }
        //    label.Text += msg;
        //    return numberOfLine;
    }
}
