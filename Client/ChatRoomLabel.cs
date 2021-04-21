using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Client
{
    class ChatRoomLabel : Label
    {
        protected override void OnPaint(PaintEventArgs e)
        {
            Point drawPoint = new Point(0, 0);

            string[] ary = Text.Split(new char[] { '|' });
            if (ary.Length == 3)
            {
                Font normalFont = this.Font;

                Font boldFont = new Font(FontFamily.GenericSerif, 11f, FontStyle.Bold);

                Size boldSize = TextRenderer.MeasureText(ary[0], boldFont);
                Size normalSize = TextRenderer.MeasureText(ary[1], normalFont);
                Size timeSize = TextRenderer.MeasureText(ary[2], normalFont);

                Rectangle boldRect = new Rectangle(drawPoint, boldSize);
                Rectangle normalRect = new Rectangle(0, boldRect.Top + 20, normalSize.Width, normalSize.Height);
                Rectangle timeRect = new Rectangle(normalSize.Width + 10, boldRect.Top + 20, timeSize.Width, timeSize.Height);

                TextRenderer.DrawText(e.Graphics, ary[0], boldFont, boldRect, ForeColor);
                TextRenderer.DrawText(e.Graphics, ary[1], normalFont, normalRect, ForeColor);
                TextRenderer.DrawText(e.Graphics, ary[2], normalFont, timeRect, ForeColor);
            }
            else
            {

                TextRenderer.DrawText(e.Graphics, Text, Font, drawPoint, ForeColor);
            }
        }
    }
}

