using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MailProgramm
{
    public class BuildMessage
    {
        MailPropertiesForJson mailWithProperties = new MailPropertiesForJson();

        public string Subject{ get; set;}

        /// <summary>
        /// Baut eine Form mit Controls zusammen, um den Inhalt der mail anzuzeigen. 
        /// </summary>
        /// <returns>Gibt Form zurück, damit diese angezeigt werden kann.</returns>
        public Form CreateMailToRead()
        {
            Form Readmessage = new Form();
            Readmessage.Width = 610;
            Readmessage.Height = 400;


            // Sender Controls
            Panel pnlsender = new Panel();
            pnlsender.Width = 600;
            pnlsender.Height = 25;
            pnlsender.Location = new Point(0, 0);

            Label lblRMs = new Label();
            lblRMs.Name = "lblReadmessageSender";
            lblRMs.Text = "Sender";
            lblRMs.Width = 50;
            lblRMs.Height = 17;
            lblRMs.Location = new Point(3, 3);

            TextBox strRMs = new TextBox();
            strRMs.ReadOnly = true;
            strRMs.Name = "ReadmessageSender";
            strRMs.Text = mailWithProperties.Absender;
            strRMs.Width = 300;
            strRMs.Height = 17;
            strRMs.Location = new Point(80, 3);

            pnlsender.Controls.Add(lblRMs);
            pnlsender.Controls.Add(strRMs);

            Readmessage.Controls.Add(pnlsender);


            // Panel Receiver
            Panel pnlReceiver = new Panel();
            pnlReceiver.Width = 600;
            pnlReceiver.Height = 25;
            pnlReceiver.Location = new Point(0, 30);
            pnlReceiver.Name = "Receiver";

            Label lblRMr = new Label();
            lblRMr.Name = "lblReadmessageReceiver";
            lblRMr.Text = "Empfänger";
            lblRMr.Width = 70;
            lblRMr.Height = 17;
            lblRMr.Location = new Point(3, 0);

            TextBox strRMr = new TextBox();
            strRMr.ReadOnly = true;
            strRMr.Name = "ReadmessageReceiver";
            strRMr.Text = mailWithProperties.Empfaenger;
            strRMr.Width = 300;
            strRMr.Height = 17;
            strRMr.Location = new Point(80, 0);

            pnlReceiver.Controls.Add(lblRMr);
            pnlReceiver.Controls.Add(strRMr);

            Readmessage.Controls.Add(pnlReceiver);

            // Panel Subject

            Panel pnlSubject = new Panel();
            pnlSubject.Width = 600;
            pnlSubject.Height = 25;
            pnlSubject.Location = new Point(0, 60);
            pnlSubject.Name = "Subject";

            Label lblRMsubject = new Label();
            lblRMsubject.Name = "lblReadmessageSubject";
            lblRMsubject.Text = "Betreff";
            lblRMsubject.Width = 50;
            lblRMsubject.Height = 17;
            lblRMsubject.Location = new Point(3, 0);

            TextBox strRMsubject = new TextBox();
            strRMsubject.ReadOnly = true;
            strRMsubject.Name = "txtReadmessageSubject";
            strRMsubject.Text = mailWithProperties.Betreff;
            strRMsubject.Width = 300;
            strRMsubject.Height = 17;
            strRMsubject.Location = new Point(80, 0);

            pnlSubject.Controls.Add(lblRMsubject);
            pnlSubject.Controls.Add(strRMsubject);

            Readmessage.Controls.Add(pnlSubject);

            //Textbox
            RichTextBox rtxtBox = new RichTextBox();
            rtxtBox.Name = "RMMessage";
            rtxtBox.Location = new Point(0, 80);
            rtxtBox.Width = 500;
            rtxtBox.Height = 200;
            rtxtBox.Text = mailWithProperties.Nachricht;
            rtxtBox.ReadOnly = true;

            Readmessage.Controls.Add(rtxtBox);

            return Readmessage;
        }

        public  void LoadMailData()
        {
            List<string> fileNames = new List<string>();

            string path = @"c:\Mailprogramm";

            DirectoryInfo di = new DirectoryInfo(path);

            FileInfo[] files = di.GetFiles(); 

            foreach(FileInfo file in files)
            {
                fileNames.Add(file.Name);
            }

            foreach(string name in fileNames)
            {
                using (StreamReader sr = File.OpenText(path + @"\" + name))
                {
                    string json = sr.ReadToEnd();


                    if (json.Contains(Subject))
                    {
                         mailWithProperties = JsonConvert.DeserializeObject<MailPropertiesForJson>(json);
                    }


                }
            }
        }

    }
}
