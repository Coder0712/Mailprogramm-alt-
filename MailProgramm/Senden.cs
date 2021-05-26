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
    public partial class Senden : Form
    {
        public Senden()
        {
            InitializeComponent();
        }

        private void btnWMSend_Click(object sender, EventArgs e)
        {
            Mail.SenderMail = txtWMs.Text;
            Mail.ReceiverMail = txtWMr.Text;
            Mail.MailSubject = txtWMSubject.Text;
            Mail.MailText = rtxtWmM.Text;

            Client.sendMessage();

            txtWMs.Clear();
            txtWMr.Clear();
            txtWMSubject.Clear();
            rtxtWmM.Clear();

            
        }
    }
}
