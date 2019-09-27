using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace onlineSPC
{
    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            LoginForm loginform = new LoginForm();
            Application.Run(loginform);
            if (loginform.Form_OK)
            {
                MainFrom mainform = new MainFrom();
                mainform.name = loginform.name;
                Application.Run(mainform);
            }
        }
    }
}
