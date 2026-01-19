using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using BusinessLayer;

namespace DVLD
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            clsUserBusinessLayer _user= new clsUserBusinessLayer(); 
            void setinfo(clsUserBusinessLayer user)
            {
                _user = user;
            }

            while (true)
            {
                using (LoginScreen loginScreen = new LoginScreen())
                {
                    loginScreen.StartPosition = FormStartPosition.CenterScreen;
                    loginScreen.GetUserInfo += setinfo;
                    if (loginScreen.ShowDialog() == DialogResult.OK)
                    {
                        

                        using (MainForm main = new MainForm(_user))
                        {
                            
                            Application.Run(main);

                            if (main.LogoutRequested)
                            {
                                // رجوع إلى شاشة الدخول
                                continue;
                            }
                            else
                            {
                                // خروج من التطبيق
                                break;
                            }

                        }
                    }
                    else
                    {
                        break;
                    }
                }
            }




        }
    }
}
