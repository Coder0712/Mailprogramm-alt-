namespace MailProgramm
{
    partial class Senden
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
            this.txtWMs = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtWMr = new System.Windows.Forms.TextBox();
            this.rtxtWmM = new System.Windows.Forms.RichTextBox();
            this.btnWMSend = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.txtWMSubject = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // txtWMs
            // 
            this.txtWMs.Location = new System.Drawing.Point(120, 12);
            this.txtWMs.Name = "txtWMs";
            this.txtWMs.Size = new System.Drawing.Size(626, 22);
            this.txtWMs.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(29, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(54, 17);
            this.label1.TabIndex = 1;
            this.label1.Text = "Sender";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(29, 59);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(77, 17);
            this.label2.TabIndex = 2;
            this.label2.Text = "Empfänger";
            // 
            // txtWMr
            // 
            this.txtWMr.Location = new System.Drawing.Point(120, 56);
            this.txtWMr.Name = "txtWMr";
            this.txtWMr.Size = new System.Drawing.Size(626, 22);
            this.txtWMr.TabIndex = 3;
            // 
            // rtxtWmM
            // 
            this.rtxtWmM.Location = new System.Drawing.Point(120, 132);
            this.rtxtWmM.Name = "rtxtWmM";
            this.rtxtWmM.Size = new System.Drawing.Size(626, 244);
            this.rtxtWmM.TabIndex = 4;
            this.rtxtWmM.Text = "";
            // 
            // btnWMSend
            // 
            this.btnWMSend.Location = new System.Drawing.Point(671, 403);
            this.btnWMSend.Name = "btnWMSend";
            this.btnWMSend.Size = new System.Drawing.Size(75, 23);
            this.btnWMSend.TabIndex = 5;
            this.btnWMSend.Text = "Senden";
            this.btnWMSend.UseVisualStyleBackColor = true;
            this.btnWMSend.Click += new System.EventHandler(this.btnWMSend_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(29, 96);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(50, 17);
            this.label3.TabIndex = 6;
            this.label3.Text = "Betreff";
            // 
            // txtWMSubject
            // 
            this.txtWMSubject.Location = new System.Drawing.Point(120, 93);
            this.txtWMSubject.Name = "txtWMSubject";
            this.txtWMSubject.Size = new System.Drawing.Size(626, 22);
            this.txtWMSubject.TabIndex = 7;
            // 
            // Senden
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.txtWMSubject);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btnWMSend);
            this.Controls.Add(this.rtxtWmM);
            this.Controls.Add(this.txtWMr);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtWMs);
            this.Name = "Senden";
            this.Text = "Senden";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtWMs;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtWMr;
        private System.Windows.Forms.RichTextBox rtxtWmM;
        private System.Windows.Forms.Button btnWMSend;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtWMSubject;
    }
}