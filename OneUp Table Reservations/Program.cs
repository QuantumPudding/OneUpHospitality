using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OneUp_Table_Reservations
{
    static class Program
    {
        public static class Globals
        {
            public static SecureString DatebasePassword;
        }
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            LoginForm login = new LoginForm();
            Application.Run(login);
            if (login.PasswordAccepted && login.DialogResult == DialogResult.OK)
            {
                Application.Run(new MainWindow());
            }
        }
    }
}
