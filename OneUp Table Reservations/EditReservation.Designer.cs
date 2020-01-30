namespace OneUp_Table_Reservations
{
    partial class EditReservation
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.dtPicker = new System.Windows.Forms.DateTimePicker();
            this.label4 = new System.Windows.Forms.Label();
            this.txtCovers = new System.Windows.Forms.TextBox();
            this.txtRef = new System.Windows.Forms.TextBox();
            this.txtGuest = new System.Windows.Forms.TextBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.txtTime = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtNotes = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.cbRestaurants = new System.Windows.Forms.ComboBox();
            this.btnSelectGuest = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(15, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(60, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Reference:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(15, 40);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(38, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Guest:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(15, 67);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(43, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Covers:";
            // 
            // dtPicker
            // 
            this.dtPicker.Location = new System.Drawing.Point(96, 175);
            this.dtPicker.Name = "dtPicker";
            this.dtPicker.Size = new System.Drawing.Size(211, 20);
            this.dtPicker.TabIndex = 3;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(15, 179);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(33, 13);
            this.label4.TabIndex = 4;
            this.label4.Text = "Date:";
            // 
            // txtCovers
            // 
            this.txtCovers.Location = new System.Drawing.Point(96, 64);
            this.txtCovers.Name = "txtCovers";
            this.txtCovers.Size = new System.Drawing.Size(211, 20);
            this.txtCovers.TabIndex = 5;
            // 
            // txtRef
            // 
            this.txtRef.Location = new System.Drawing.Point(96, 12);
            this.txtRef.Name = "txtRef";
            this.txtRef.ReadOnly = true;
            this.txtRef.Size = new System.Drawing.Size(211, 20);
            this.txtRef.TabIndex = 6;
            // 
            // txtGuest
            // 
            this.txtGuest.Location = new System.Drawing.Point(96, 37);
            this.txtGuest.Name = "txtGuest";
            this.txtGuest.ReadOnly = true;
            this.txtGuest.Size = new System.Drawing.Size(172, 20);
            this.txtGuest.TabIndex = 7;
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(18, 214);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(289, 23);
            this.btnSave.TabIndex = 8;
            this.btnSave.Text = "Save and Close";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // txtTime
            // 
            this.txtTime.Location = new System.Drawing.Point(96, 90);
            this.txtTime.Name = "txtTime";
            this.txtTime.Size = new System.Drawing.Size(211, 20);
            this.txtTime.TabIndex = 10;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(15, 93);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(33, 13);
            this.label5.TabIndex = 9;
            this.label5.Text = "Time:";
            // 
            // txtNotes
            // 
            this.txtNotes.Location = new System.Drawing.Point(96, 116);
            this.txtNotes.Name = "txtNotes";
            this.txtNotes.Size = new System.Drawing.Size(211, 20);
            this.txtNotes.TabIndex = 12;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(15, 119);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(38, 13);
            this.label6.TabIndex = 11;
            this.label6.Text = "Notes:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(15, 149);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(62, 13);
            this.label7.TabIndex = 13;
            this.label7.Text = "Restaurant:";
            // 
            // cbRestaurants
            // 
            this.cbRestaurants.FormattingEnabled = true;
            this.cbRestaurants.Location = new System.Drawing.Point(96, 146);
            this.cbRestaurants.Name = "cbRestaurants";
            this.cbRestaurants.Size = new System.Drawing.Size(211, 21);
            this.cbRestaurants.TabIndex = 14;
            // 
            // btnSelectGuest
            // 
            this.btnSelectGuest.Location = new System.Drawing.Point(274, 36);
            this.btnSelectGuest.Name = "btnSelectGuest";
            this.btnSelectGuest.Size = new System.Drawing.Size(34, 22);
            this.btnSelectGuest.TabIndex = 15;
            this.btnSelectGuest.Text = "...";
            this.btnSelectGuest.UseVisualStyleBackColor = true;
            this.btnSelectGuest.Click += new System.EventHandler(this.btnSelectGuest_Click);
            // 
            // EditReservation
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(325, 249);
            this.Controls.Add(this.btnSelectGuest);
            this.Controls.Add(this.cbRestaurants);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.txtNotes);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txtTime);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.txtGuest);
            this.Controls.Add(this.txtRef);
            this.Controls.Add(this.txtCovers);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.dtPicker);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "EditReservation";
            this.Text = "View/Edit Reservation";
            this.Load += new System.EventHandler(this.EditReservation_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DateTimePicker dtPicker;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtCovers;
        private System.Windows.Forms.TextBox txtRef;
        private System.Windows.Forms.TextBox txtGuest;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.TextBox txtTime;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtNotes;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox cbRestaurants;
        private System.Windows.Forms.Button btnSelectGuest;
    }
}