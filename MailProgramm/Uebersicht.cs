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
        // list for subjects and dates
        private List<KeyVal<string, string>> subjects = new List<KeyVal<string, string>>();
        private List<string> dates = new List<string>();

        private string subjectMails = null;

        Label subjectLabel;
        Panel subjectDatePanel;
        Label subjectDateLabel;

        // x and y cooradinate for label
        private int x = 0;
        private int y = 0;


        public Uebersicht()
        {
            InitializeComponent();

            ReadServer.Connection();

            subjects = ReadServer.ReadAndSaveMessages();

            int i = 0;
            x = 10;
            y = 10;

            foreach (KeyVal<string, string> subject in subjects)
            {
                // counter for label name


                // positions for first label

                subjectDatePanel = new Panel();

                subjectDateLabel = new Label();

                subjectLabel = new Label();

                // date for panel
                subjectDatePanel.Name = Convert.ToString(i);
                subjectDatePanel.Height = 30;
                subjectDatePanel.Width = 650;

                // data for subjectlabel
                subjectLabel.Name = Convert.ToString(i);
                subjectLabel.Height = 16;
                subjectLabel.Width = 400;
                subjectLabel.Location = new Point(0, 0);

                subjectDateLabel.Name = Convert.ToString(i);
                subjectDateLabel.Height = 16;
                subjectDateLabel.Width = 100;
                subjectDateLabel.Location = new Point(410,0);

                if (subjectDatePanel.Name == Convert.ToString(i))
                {
                    subjectLabel.Text = subject.id;
                    subjectMails = subject.id;
                    subjectDateLabel.Text = subject.value;

                    subjectDatePanel.Controls.Add(subjectLabel);
                    subjectDatePanel.Controls.Add(subjectDateLabel);

                }

                if (subjectDatePanel.Name == "0")
                {
                    subjectDatePanel.Location = new Point(x, y);
                }

                if (i > 0)
                {
                    y = y + 40;
                    subjectDatePanel.Location = new Point(x, y);
                }


                pnlSubjects.Controls.Add(subjectDatePanel);


                subjectDatePanel.Click += new EventHandler(subjectLabel_Click);

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

            Panel pnl = sender as Panel;
            
            // point of the subject text field
            Point pointSubejct = new Point(0, 0);

            //point of the date text field
            Point pointDate = new Point(410, 0);

            Control subjectInPanel = pnl.GetChildAtPoint(pointSubejct);
            Control dateInPanel = pnl.GetChildAtPoint(pointDate);

            message.Subject = subjectInPanel.Text;
            string date = dateInPanel.Text;

            message.Date = date.Substring(0, date.Length - 1);

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
