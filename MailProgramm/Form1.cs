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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Verifizierung.Username = textBox2.Text;
            Verifizierung.Password = textBox1.Text;

            if(textBox1.Text == "" & textBox2.Text == "")
            {
                MessageBox.Show("Bitte gib deine Anmeldedaten ein.");
            }

            Client.connect();

            new Uebersicht().Show();

        }
    }
}
