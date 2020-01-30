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
    public partial class SettingsForm : Form
    {
        public SettingsForm()
        {
            InitializeComponent();
            txtHost.Text = Properties.Settings.Default["DatabaseHost"].ToString();
            txtName.Text = Properties.Settings.Default["DatabaseName"].ToString();
            txtUser.Text = Properties.Settings.Default["DatabaseUser"].ToString();
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default["DatabaseHost"] = txtHost.Text;
            Properties.Settings.Default["DatabaseName"] = txtName.Text;
            Properties.Settings.Default["DatabaseUser"] = txtUser.Text;

            Encryption.SecureStringWrapper sw = new Encryption.SecureStringWrapper(txtPass.SecureString);
            Properties.Settings.Default["DatabasePass"] = Encryption.EncryptStringAES(Encoding.UTF8.GetString(sw.ToByteArray()), Encryption.PasswordHash);
            Properties.Settings.Default.Save();
        }

        private void BtnUpdatePass_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you'd like to change the application password?", "Just a sec...", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                string hash = Encryption.CreateHash(txtNewPass.SecureString);
                Properties.Settings.Default["ApplicationPass"] = hash;
                Properties.Settings.Default.Save();
                Encryption.PasswordHash = hash;
            }
            txtNewPass.SecureString.Clear();
            txtNewPass.Clear();
        }
    }
}
