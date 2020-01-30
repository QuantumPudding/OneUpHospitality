using HelperClasses;

namespace OneUp_Table_Reservations
{
    partial class EditDatabase
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
            this.DGV = new System.Windows.Forms.DataGridView();
            this.cbTables = new System.Windows.Forms.ComboBox();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.btnConnect = new System.Windows.Forms.Button();
            this.txtHost = new PromptTextBox();
            this.txtUser = new PromptTextBox();
            this.txtPass = new PromptTextBox();
            ((System.ComponentModel.ISupportInitialize)(this.DGV)).BeginInit();
            this.SuspendLayout();
            // 
            // DGV
            // 
            this.DGV.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.DGV.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.DGV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DGV.Location = new System.Drawing.Point(12, 36);
            this.DGV.Name = "DGV";
            this.DGV.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DGV.Size = new System.Drawing.Size(776, 395);
            this.DGV.TabIndex = 24;
            // 
            // cbTables
            // 
            this.cbTables.FormattingEnabled = true;
            this.cbTables.Location = new System.Drawing.Point(502, 9);
            this.cbTables.Name = "cbTables";
            this.cbTables.Size = new System.Drawing.Size(205, 21);
            this.cbTables.TabIndex = 25;
            this.cbTables.SelectedIndexChanged += new System.EventHandler(this.CbTables_SelectedIndexChanged);
            // 
            // btnUpdate
            // 
            this.btnUpdate.Enabled = false;
            this.btnUpdate.Location = new System.Drawing.Point(713, 7);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(75, 23);
            this.btnUpdate.TabIndex = 26;
            this.btnUpdate.Text = "Update";
            this.btnUpdate.UseVisualStyleBackColor = true;
            this.btnUpdate.Click += new System.EventHandler(this.BtnUpdate_Click);
            // 
            // btnConnect
            // 
            this.btnConnect.Location = new System.Drawing.Point(394, 7);
            this.btnConnect.Name = "btnConnect";
            this.btnConnect.Size = new System.Drawing.Size(75, 23);
            this.btnConnect.TabIndex = 3;
            this.btnConnect.Text = "Connect";
            this.btnConnect.UseVisualStyleBackColor = true;
            this.btnConnect.Click += new System.EventHandler(this.BtnConnect_Click);
            // 
            // txtHost
            // 
            this.txtHost.Location = new System.Drawing.Point(13, 9);
            this.txtHost.Name = "txtHost";
            this.txtHost.Prompt = "Host...";
            this.txtHost.Size = new System.Drawing.Size(121, 20);
            this.txtHost.TabIndex = 27;
            // 
            // txtUser
            // 
            this.txtUser.Location = new System.Drawing.Point(140, 9);
            this.txtUser.Name = "txtUser";
            this.txtUser.Prompt = "Username...";
            this.txtUser.Size = new System.Drawing.Size(121, 20);
            this.txtUser.TabIndex = 28;
            // 
            // txtPass
            // 
            this.txtPass.Location = new System.Drawing.Point(267, 9);
            this.txtPass.Name = "txtPass";
            this.txtPass.Prompt = "Password...";
            this.txtPass.Size = new System.Drawing.Size(121, 20);
            this.txtPass.TabIndex = 29;
            this.txtPass.UseSystemPasswordChar = true;
            // 
            // EditDatabase
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.txtPass);
            this.Controls.Add(this.txtUser);
            this.Controls.Add(this.txtHost);
            this.Controls.Add(this.btnConnect);
            this.Controls.Add(this.btnUpdate);
            this.Controls.Add(this.cbTables);
            this.Controls.Add(this.DGV);
            this.Name = "EditDatabase";
            this.Text = "EditDatabase";
            this.Load += new System.EventHandler(this.EditDatabase_Load);
            ((System.ComponentModel.ISupportInitialize)(this.DGV)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.DataGridView DGV;
        private System.Windows.Forms.ComboBox cbTables;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.Button btnConnect;
        private PromptTextBox txtHost;
        private PromptTextBox txtUser;
        private PromptTextBox txtPass;
    }
}