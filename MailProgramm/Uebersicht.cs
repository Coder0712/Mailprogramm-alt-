using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MailProgramm
{
    public partial class Uebersicht : Form
    {
        // list for subjects
        private List<string> subjects = new List<string>();

        private string subjectMails = null;

        Label subjectLabel;

        // x and y cooradinate for label
        private int x = 0;
        private int y = 0;


        public Uebersicht()
        {
            InitializeComponent();

            ReadServer.Connection();

            subjects = ReadServer.ReadAndSaveMessages();

            int i = 0;
            x = 20;
            y = 20;

            foreach (string subject in subjects)
            {
                // counter for label name


                // positions for first label


                subjectLabel = new Label();

                subjectLabel.Name = Convert.ToString(i);
                subjectLabel.Height = 17;
                subjectLabel.Width = 550;


                if (subjectLabel.Name == Convert.ToString(i))
                {
                    subjectLabel.Text = subject;
                    subjectMails = subject;
                }

                if (subjectLabel.Name == "0")
                {
                    subjectLabel.Location = new Point(x, y);
                }

                if (i > 0)
                {
                    y = y + 20;
                    subjectLabel.Location = new Point(x, y);
                }

                pnlSubjects.Controls.Add(subjectLabel);


                subjectLabel.Click += new EventHandler(subjectLabel_Click);

                ++i;

            }
        }

        private void btnSenden_Click(object sender, EventArgs e)
        {
            new Senden().Show();
        }

        private void btnAbholen_Click(object sender, EventArgs e)
        {
            
        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        
        private void subjectLabel_Click(object sender, EventArgs e)
        {
            BuildMessage message = new BuildMessage();

            Label lbl = sender as Label;
            message.Subject = lbl.Text;

            message.LoadMailData();


            message.CreateMailToRead().Show();
            
            
        }

        private void btnlogout_Click(object sender, EventArgs e)
        {
            Client.closeConnection();

            Uebersicht.ActiveForm.Close();

            MessageBox.Show("Sie haben sich ausgeloggt.");
        }

    }
}
