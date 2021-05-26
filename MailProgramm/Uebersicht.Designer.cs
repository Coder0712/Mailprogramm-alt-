namespace MailProgramm
{
    partial class Uebersicht
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
            this.btnSenden = new System.Windows.Forms.Button();
            this.btnAbholen = new System.Windows.Forms.Button();
            this.gbMails = new System.Windows.Forms.GroupBox();
            this.pnlSubjects = new System.Windows.Forms.Panel();
            this.btnlogout = new System.Windows.Forms.Button();
            this.gbMails.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnSenden
            // 
            this.btnSenden.Location = new System.Drawing.Point(12, 12);
            this.btnSenden.Name = "btnSenden";
            this.btnSenden.Size = new System.Drawing.Size(99, 63);
            this.btnSenden.TabIndex = 0;
            this.btnSenden.Text = "Senden";
            this.btnSenden.UseVisualStyleBackColor = true;
            this.btnSenden.Click += new System.EventHandler(this.btnSenden_Click);
            // 
            // btnAbholen
            // 
            this.btnAbholen.Location = new System.Drawing.Point(117, 12);
            this.btnAbholen.Name = "btnAbholen";
            this.btnAbholen.Size = new System.Drawing.Size(99, 63);
            this.btnAbholen.TabIndex = 1;
            this.btnAbholen.Text = "Abholen";
            this.btnAbholen.UseVisualStyleBackColor = true;
            this.btnAbholen.Click += new System.EventHandler(this.btnAbholen_Click);
            // 
            // gbMails
            // 
            this.gbMails.Controls.Add(this.pnlSubjects);
            this.gbMails.Location = new System.Drawing.Point(13, 107);
            this.gbMails.Name = "gbMails";
            this.gbMails.Size = new System.Drawing.Size(775, 331);
            this.gbMails.TabIndex = 2;
            this.gbMails.TabStop = false;
            this.gbMails.Text = "Emails";
            // 
            // pnlSubjects
            // 
            this.pnlSubjects.AutoScroll = true;
            this.pnlSubjects.Location = new System.Drawing.Point(7, 22);
            this.pnlSubjects.Name = "pnlSubjects";
            this.pnlSubjects.Size = new System.Drawing.Size(762, 303);
            this.pnlSubjects.TabIndex = 0;
            this.pnlSubjects.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // btnlogout
            // 
            this.btnlogout.Location = new System.Drawing.Point(683, 12);
            this.btnlogout.Name = "btnlogout";
            this.btnlogout.Size = new System.Drawing.Size(99, 63);
            this.btnlogout.TabIndex = 3;
            this.btnlogout.Text = "Log Out";
            this.btnlogout.UseVisualStyleBackColor = true;
            this.btnlogout.Click += new System.EventHandler(this.btnlogout_Click);
            // 
            // Uebersicht
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnlogout);
            this.Controls.Add(this.gbMails);
            this.Controls.Add(this.btnAbholen);
            this.Controls.Add(this.btnSenden);
            this.Name = "Uebersicht";
            this.Text = "Uebersicht";
            this.gbMails.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnSenden;
        private System.Windows.Forms.Button btnAbholen;
        private System.Windows.Forms.GroupBox gbMails;
        private System.Windows.Forms.Panel pnlSubjects;
        private System.Windows.Forms.Button btnlogout;
    }
}