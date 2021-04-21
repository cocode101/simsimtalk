using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Client
{
    class Design
    {
        public static void  buttonStyle(Button btn)
        {

            btn.FlatStyle = FlatStyle.Flat;
            btn.FlatAppearance.BorderSize = 0;
            btn.FlatAppearance.MouseOverBackColor = Color.LightGray;

            btn.BackColor = Color.Gainsboro;

            btn.Font = new Font("굴림", 9, FontStyle.Bold);
            btn.ForeColor = Color.DarkGreen;
            
            
                
        }
    }
}
