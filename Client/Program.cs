using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Client
{
    static class Program
    {
        public static ApplicationContext ac = new ApplicationContext();
        /// <summary>
        /// 해당 응용 프로그램의 주 진입점입니다.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            try
            {
                // 메인폼 전환
                MainForm startForm = new MainForm();
                ac.MainForm = startForm;

                //Application.Run(new MainForm());
                Application.Run(ac);
            }
            catch (Exception)
            {

            }
        }
    }
}
