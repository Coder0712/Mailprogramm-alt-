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
    public partial class CreateAccount : Form
    {
        public CreateAccount()
        {
            InitializeComponent();
        }

        public CreateAccount(MailBox mailBox)
        {
            MailBox = mailBox;
            InitializeComponent();
        }

        public MailBox MailBox { get; }


        private void _saveButton_Click(object sender, EventArgs e)
        {
            MailBox.Account.Username = _usernameTextBox.Text;
            MailBox.Account.Password = _passwordTextBox.Text;
            MailBox.Account.Host = _hostTextBox.Text;
            MailBox.Account.Port = (int)_portNumericUpDown.Value;
            MailBox.Account.UseSSL = _useSSLCheckBox.Checked;

            DialogResult = DialogResult.OK;
        }

        private void _cancelButton_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
