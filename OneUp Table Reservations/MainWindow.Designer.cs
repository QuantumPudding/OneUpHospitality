using HelperClasses;
namespace OneUp_Table_Reservations
{
    partial class MainWindow
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.applicationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.settingsToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.guestsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.viewGuestsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.restaurantsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editRestaurantsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tcDiary = new System.Windows.Forms.TabControl();
            this.calendar = new System.Windows.Forms.MonthCalendar();
            this.label1 = new System.Windows.Forms.Label();
            this.btnQuickReservation = new System.Windows.Forms.Button();
            this.btnDetailedReservation = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.txtEmail = new HelperClasses.PromptTextBox();
            this.txtContactNumber = new HelperClasses.PromptTextBox();
            this.txtTime = new HelperClasses.PromptTextBox();
            this.txtCovers = new HelperClasses.PromptTextBox();
            this.txtName = new HelperClasses.PromptTextBox();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.applicationToolStripMenuItem,
            this.guestsToolStripMenuItem,
            this.restaurantsToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1015, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // applicationToolStripMenuItem
            // 
            this.applicationToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.settingsToolStripMenuItem1,
            this.exitToolStripMenuItem});
            this.applicationToolStripMenuItem.Name = "applicationToolStripMenuItem";
            this.applicationToolStripMenuItem.Size = new System.Drawing.Size(80, 20);
            this.applicationToolStripMenuItem.Text = "Application";
            // 
            // settingsToolStripMenuItem1
            // 
            this.settingsToolStripMenuItem1.Name = "settingsToolStripMenuItem1";
            this.settingsToolStripMenuItem1.Size = new System.Drawing.Size(116, 22);
            this.settingsToolStripMenuItem1.Text = "Settings";
            this.settingsToolStripMenuItem1.Click += new System.EventHandler(this.SettingsToolStripMenuItem1_Click);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(116, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.ExitToolStripMenuItem_Click);
            // 
            // guestsToolStripMenuItem
            // 
            this.guestsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.viewGuestsToolStripMenuItem});
            this.guestsToolStripMenuItem.Name = "guestsToolStripMenuItem";
            this.guestsToolStripMenuItem.Size = new System.Drawing.Size(54, 20);
            this.guestsToolStripMenuItem.Text = "Guests";
            // 
            // viewGuestsToolStripMenuItem
            // 
            this.viewGuestsToolStripMenuItem.Name = "viewGuestsToolStripMenuItem";
            this.viewGuestsToolStripMenuItem.Size = new System.Drawing.Size(175, 22);
            this.viewGuestsToolStripMenuItem.Text = "View/Edit Database";
            this.viewGuestsToolStripMenuItem.Click += new System.EventHandler(this.viewGuestsToolStripMenuItem_Click);
            // 
            // restaurantsToolStripMenuItem
            // 
            this.restaurantsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.editRestaurantsToolStripMenuItem});
            this.restaurantsToolStripMenuItem.Name = "restaurantsToolStripMenuItem";
            this.restaurantsToolStripMenuItem.Size = new System.Drawing.Size(80, 20);
            this.restaurantsToolStripMenuItem.Text = "Restaurants";
            // 
            // editRestaurantsToolStripMenuItem
            // 
            this.editRestaurantsToolStripMenuItem.Name = "editRestaurantsToolStripMenuItem";
            this.editRestaurantsToolStripMenuItem.Size = new System.Drawing.Size(94, 22);
            this.editRestaurantsToolStripMenuItem.Text = "Edit";
            this.editRestaurantsToolStripMenuItem.Click += new System.EventHandler(this.editRestaurantsToolStripMenuItem_Click);
            // 
            // tcDiary
            // 
            this.tcDiary.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tcDiary.Location = new System.Drawing.Point(257, 33);
            this.tcDiary.Name = "tcDiary";
            this.tcDiary.SelectedIndex = 0;
            this.tcDiary.Size = new System.Drawing.Size(746, 531);
            this.tcDiary.TabIndex = 1;
            this.tcDiary.SelectedIndexChanged += new System.EventHandler(this.tcDiary_SelectedIndexChanged);
            // 
            // calendar
            // 
            this.calendar.Location = new System.Drawing.Point(18, 33);
            this.calendar.Name = "calendar";
            this.calendar.ShowToday = false;
            this.calendar.TabIndex = 2;
            this.calendar.DateChanged += new System.Windows.Forms.DateRangeEventHandler(this.calendar_DateChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(15, 204);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(101, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Create Reservation:";
            // 
            // btnQuickReservation
            // 
            this.btnQuickReservation.Location = new System.Drawing.Point(18, 420);
            this.btnQuickReservation.Name = "btnQuickReservation";
            this.btnQuickReservation.Size = new System.Drawing.Size(227, 23);
            this.btnQuickReservation.TabIndex = 8;
            this.btnQuickReservation.Text = "Complete Reservation";
            this.btnQuickReservation.UseVisualStyleBackColor = true;
            this.btnQuickReservation.Click += new System.EventHandler(this.btnQuickReservation_Click);
            // 
            // btnDetailedReservation
            // 
            this.btnDetailedReservation.Location = new System.Drawing.Point(18, 449);
            this.btnDetailedReservation.Name = "btnDetailedReservation";
            this.btnDetailedReservation.Size = new System.Drawing.Size(227, 23);
            this.btnDetailedReservation.TabIndex = 9;
            this.btnDetailedReservation.Text = "Create Full Reservation";
            this.btnDetailedReservation.UseVisualStyleBackColor = true;
            this.btnDetailedReservation.Click += new System.EventHandler(this.btnDetailedReservation_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(18, 541);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(227, 23);
            this.btnCancel.TabIndex = 11;
            this.btnCancel.Text = "Cancel Reservation";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // txtEmail
            // 
            this.txtEmail.Location = new System.Drawing.Point(18, 335);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Prompt = "Email address...";
            this.txtEmail.Size = new System.Drawing.Size(100, 20);
            this.txtEmail.TabIndex = 17;
            // 
            // txtContactNumber
            // 
            this.txtContactNumber.Location = new System.Drawing.Point(18, 309);
            this.txtContactNumber.Name = "txtContactNumber";
            this.txtContactNumber.Prompt = "Contact number...";
            this.txtContactNumber.Size = new System.Drawing.Size(100, 20);
            this.txtContactNumber.TabIndex = 16;
            this.txtContactNumber.Enter += new System.EventHandler(this.TxtContactNumber_Enter);
            // 
            // txtTime
            // 
            this.txtTime.Location = new System.Drawing.Point(18, 283);
            this.txtTime.Name = "txtTime";
            this.txtTime.Prompt = "Time...";
            this.txtTime.Size = new System.Drawing.Size(100, 20);
            this.txtTime.TabIndex = 15;
            // 
            // txtCovers
            // 
            this.txtCovers.Location = new System.Drawing.Point(18, 257);
            this.txtCovers.Name = "txtCovers";
            this.txtCovers.Prompt = "Covers...";
            this.txtCovers.Size = new System.Drawing.Size(100, 20);
            this.txtCovers.TabIndex = 14;
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(18, 231);
            this.txtName.Name = "txtName";
            this.txtName.Prompt = "Name...";
            this.txtName.Size = new System.Drawing.Size(100, 20);
            this.txtName.TabIndex = 13;
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1015, 576);
            this.Controls.Add(this.txtEmail);
            this.Controls.Add(this.txtContactNumber);
            this.Controls.Add(this.txtTime);
            this.Controls.Add(this.txtCovers);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnDetailedReservation);
            this.Controls.Add(this.btnQuickReservation);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.calendar);
            this.Controls.Add(this.tcDiary);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "MainWindow";
            this.Text = "OneUp Table Reservations";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem guestsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem viewGuestsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem restaurantsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem editRestaurantsToolStripMenuItem;
        private System.Windows.Forms.TabControl tcDiary;
        private System.Windows.Forms.MonthCalendar calendar;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnQuickReservation;
        private System.Windows.Forms.Button btnDetailedReservation;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.ToolStripMenuItem applicationToolStripMenuItem;
        private PromptTextBox txtName;
        private PromptTextBox txtCovers;
        private PromptTextBox txtTime;
        private PromptTextBox txtContactNumber;
        private PromptTextBox txtEmail;
        private System.Windows.Forms.ToolStripMenuItem settingsToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
    }
}

