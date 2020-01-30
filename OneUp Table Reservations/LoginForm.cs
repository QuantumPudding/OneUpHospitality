using HelperClasses;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OneUp_Table_Reservations
{
    public partial class LoginForm : Form
    {
        public bool PasswordAccepted;
        private bool UsingDefaultPassword;

        public LoginForm()
        {
            InitializeComponent();
            Encryption.PasswordHash = Properties.Settings.Default["ApplicationPass"].ToString();

            if (Encryption.PasswordHash == "")
            {
                Encryption.PasswordHash = Encryption.DefaultPasswordHash;
                UsingDefaultPassword = true;
            }
        }

        private void Login()
        {
            if (Encryption.TestPassword(txtPass.SecureString, Encryption.PasswordHash))
            {
                if (UsingDefaultPassword)
                    MessageBox.Show("Default password in use, please change it.");

                PasswordAccepted = true;
                this.Close();
            }
            else Application.Exit();
        }

        private void BtnLogin_Click(object sender, EventArgs e)
        {
            Login();
        }

        protected override void OnClosing(CancelEventArgs e)
        {
            if (!PasswordAccepted)
                Application.Exit();

            base.OnClosing(e);
        }


        private void TxtPass_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.Handled = true;
                DialogResult = DialogResult.OK;
                Login();
            }
            else
            {
                base.OnKeyDown(e);
            }
        }
    }
}
