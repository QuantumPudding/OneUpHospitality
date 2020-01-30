using HelperClasses;

namespace OneUp_Table_Reservations
{
    partial class SettingsForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Security.SecureString secureString1 = new System.Security.SecureString();
            System.Security.SecureString secureString2 = new System.Security.SecureString();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.txtPass = new SecureStringTextBox.SecureTextBox();
            this.txtUser = new HelperClasses.PromptTextBox();
            this.txtName = new HelperClasses.PromptTextBox();
            this.txtHost = new HelperClasses.PromptTextBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.btnUpdatePass = new System.Windows.Forms.Button();
            this.txtNewPass = new SecureStringTextBox.SecureTextBox();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(12, 12);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(217, 165);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.txtPass);
            this.tabPage1.Controls.Add(this.txtUser);
            this.tabPage1.Controls.Add(this.txtName);
            this.tabPage1.Controls.Add(this.txtHost);
            this.tabPage1.Controls.Add(this.btnSave);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(209, 139);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Database";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // txtPass
            // 
            this.txtPass.Location = new System.Drawing.Point(6, 84);
            this.txtPass.Name = "txtPass";
            this.txtPass.Prompt = "Password...";
            this.txtPass.SecureString = secureString1;
            this.txtPass.Size = new System.Drawing.Size(197, 20);
            this.txtPass.TabIndex = 9;
            this.txtPass.UseSystemPasswordChar = true;
            // 
            // txtUser
            // 
            this.txtUser.Location = new System.Drawing.Point(6, 58);
            this.txtUser.Name = "txtUser";
            this.txtUser.Prompt = "Username...";
            this.txtUser.Size = new System.Drawing.Size(197, 20);
            this.txtUser.TabIndex = 8;
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(6, 32);
            this.txtName.Name = "txtName";
            this.txtName.Prompt = "Database Name...";
            this.txtName.Size = new System.Drawing.Size(197, 20);
            this.txtName.TabIndex = 7;
            // 
            // txtHost
            // 
            this.txtHost.Location = new System.Drawing.Point(6, 6);
            this.txtHost.Name = "txtHost";
            this.txtHost.Prompt = "Host...";
            this.txtHost.Size = new System.Drawing.Size(197, 20);
            this.txtHost.TabIndex = 6;
            // 
            // btnSave
            // 
            this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSave.Location = new System.Drawing.Point(128, 110);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 5;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.BtnSave_Click);
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.txtNewPass);
            this.tabPage2.Controls.Add(this.btnUpdatePass);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(209, 139);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Application";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // btnUpdatePass
            // 
            this.btnUpdatePass.Location = new System.Drawing.Point(142, 4);
            this.btnUpdatePass.Name = "btnUpdatePass";
            this.btnUpdatePass.Size = new System.Drawing.Size(61, 23);
            this.btnUpdatePass.TabIndex = 1;
            this.btnUpdatePass.Text = "Update";
            this.btnUpdatePass.UseVisualStyleBackColor = true;
            this.btnUpdatePass.Click += new System.EventHandler(this.BtnUpdatePass_Click);
            // 
            // txtNewPass
            // 
            this.txtNewPass.Location = new System.Drawing.Point(6, 6);
            this.txtNewPass.Name = "txtNewPass";
            this.txtNewPass.Prompt = "New password...";
            this.txtNewPass.SecureString = secureString2;
            this.txtNewPass.Size = new System.Drawing.Size(130, 20);
            this.txtNewPass.TabIndex = 2;
            this.txtNewPass.UseSystemPasswordChar = true;
            // 
            // SettingsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(241, 189);
            this.Controls.Add(this.tabControl1);
            this.Name = "SettingsForm";
            this.Text = "Database Settings";
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private PromptTextBox txtUser;
        private PromptTextBox txtName;
        private PromptTextBox txtHost;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.TabPage tabPage2;
        private SecureStringTextBox.SecureTextBox txtPass;
        private System.Windows.Forms.Button btnUpdatePass;
        private SecureStringTextBox.SecureTextBox txtNewPass;
    }
}