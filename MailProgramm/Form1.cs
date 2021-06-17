using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using MailKit;
using MailKit.Net.Imap;
using MailKit.Search;
using MimeKit;
using Newtonsoft.Json;

namespace MailProgramm
{
    public partial class Form1 : Form
    {
        private BindingList<MailBox> _mailBoxes = new BindingList<MailBox>();
        private MailBoxStorage _storage = new MailBoxStorage();

        public Form1()
        {
            InitializeComponent();
            _mailBoxes.ListChanged += MailBoxesOnListChanged;
        }

        /// <summary>
        /// Adds or removes an account when a mailbox has been added
        /// </summary>
        private void MailBoxesOnListChanged(object sender, ListChangedEventArgs e)
        {
            switch (e.ListChangedType)
            {
                // Clear the List and Add all current items
                case ListChangedType.Reset:
                    _accountListView.BeginUpdate();

                    // Remove List change events
                    foreach (ListViewGroup g in _accountListView.Groups)
                    {
                        var box = (MailBox) g.Tag;
                        box.Items.ListChanged -= MailBoxItemsOnListChanged;
                    }

                    _accountListView.Groups.Clear();
                    foreach (var mailBox in _mailBoxes)
                    {
                        AddAccountToSidebar(mailBox);
                    }
                    _accountListView.EndUpdate();
                    break;

                // A new Account has been added - add it to the Sidebar
                case ListChangedType.ItemAdded:
                    _accountListView.BeginUpdate();
                    var addedItem = _mailBoxes[e.NewIndex];
                    AddAccountToSidebar(addedItem);
                    _accountListView.EndUpdate();
                    break;

                // An Account has been removed - remove it from the sidebar
                case ListChangedType.ItemDeleted:
                    _accountListView.BeginUpdate();
                    var group = _accountListView.Groups[e.OldIndex];
                    var groupMailBox = (MailBox)group.Tag;
                    var removeItems = _accountListView.Items.OfType<ListViewItem>().Where(i => i.Group == @group).ToList();
                    foreach (var item in removeItems)
                    {
                        _accountListView.Items.Remove(item);
                    }
                    _accountListView.Groups.RemoveAt(e.OldIndex);
                    groupMailBox.Items.ListChanged -= MailBoxItemsOnListChanged;
                    _accountListView.EndUpdate();
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        private void AddAccountToSidebar(MailBox mailBox)
        {
            var group = new ListViewGroup(mailBox.Account.Username)
            {
                Tag = mailBox
            };
            _accountListView.Groups.Add(group);
            _accountListView.Items.Add(new ListViewItem(group)
            {
                Text = "Inbox",
                Tag = mailBox
            });
            mailBox.Items.ListChanged += MailBoxItemsOnListChanged;
        }

        private void MailBoxItemsOnListChanged(object sender, ListChangedEventArgs e)
        {
            var selectedItem = _accountListView.SelectedItems.OfType<ListViewItem>().FirstOrDefault();

            if (selectedItem == null)
            {
                return;
            }

            var mailbox = selectedItem.Tag as MailBox;

            if (mailbox == null)
            {
                return;
            }

            if (sender != mailbox.Items)
            {
                // Currently not selected
                return;
            }

            _mailBoxlistView.BeginUpdate();

            switch (e.ListChangedType)
            {
                case ListChangedType.Reset:
                    _mailBoxlistView.Items.Clear();
                    AddMails(mailbox);
                    break;
                case ListChangedType.ItemAdded:
                    var item = mailbox.Items[e.NewIndex];
                    AddMail(item);
                    break;
                case ListChangedType.ItemDeleted:
                    throw new NotImplementedException();
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
            _mailBoxlistView.EndUpdate();

            _storage.AddOrUpdate(mailbox);
        }

        private async void Form1_Load(object sender, EventArgs e)
        {
            // Load Existing Accounts
            var mailBoxes = _storage.LoadMailBoxes(); 
            foreach (var mailBox in mailBoxes)
            {
                _mailBoxes.Add(mailBox);
            }

            await _webView.EnsureCoreWebView2Async();
        }

        private void accountToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Open Account Dialog
            using (var createAccountForm = new CreateAccount(new MailBox()))
            {
                var dialogResult = createAccountForm.ShowDialog(this);
                if (dialogResult == DialogResult.OK)
                {
                    _storage.AddOrUpdate(createAccountForm.MailBox);
                    _mailBoxes.Add(createAccountForm.MailBox);
                }
            }
        }

        /// <summary>
        /// Show the mail message when it has been selected
        /// </summary>
        private void _accountListView_ItemSelectionChanged(object sender, ListViewItemSelectionChangedEventArgs e)
        {
            _mailBoxlistView.Items.Clear();
            var mailbox = e.Item.Tag as MailBox;

            if (mailbox == null)
            {
                return;
            }

            sendAndReceiveToolStripMenuItem.Enabled = true;
            _mailBoxlistView.BeginUpdate();

            AddMails(mailbox);

            _mailBoxlistView.EndUpdate();
        }

        private void AddMails(MailBox mailBox)
        {
            foreach (var message in mailBox.Items)
            {
                AddMail(message);
            }
        }

        private void AddMail(MimeMessage message)
        {
            _mailBoxlistView.Items.Add(new ListViewItem(new ListViewItem.ListViewSubItem[]
            {
                new ListViewItem.ListViewSubItem(){Text = message.Subject},
                new ListViewItem.ListViewSubItem(){Text = message.Date.ToString("D")},
            }, -1)
            {
                Tag = message
            });
        }

        private void _mailBoxlistView_ItemSelectionChanged(object sender, ListViewItemSelectionChangedEventArgs e)
        {
            var message = e.Item.Tag as MimeMessage;

            if (message == null)
            {
                return;
            }

            if (!string.IsNullOrEmpty(message.HtmlBody))
            {
                _webView.NavigateToString(message.HtmlBody);
            }
            else if(!string.IsNullOrEmpty(message.TextBody))
            {
                _webView.NavigateToString(message.TextBody);
            }
            else
            {
                _webView.NavigateToString(string.Empty);
            }
        }

        private void sendAndReceiveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var selectedItem = _accountListView.SelectedItems.OfType<ListViewItem>().FirstOrDefault();

            if (selectedItem == null)
            {
                return;
            }

            var mailbox = selectedItem.Tag as MailBox;

            if (mailbox == null)
            {
                return;
            }


            using (var imap = new ImapClient())
            {
                imap.Connect(mailbox.Account.Host, mailbox.Account.Port, mailbox.Account.UseSSL);
                imap.Authenticate(mailbox.Account.Username, mailbox.Account.Password);

                imap.Inbox.Open(FolderAccess.ReadOnly);

                if (imap.Inbox.Count > 0)
                {
                    // fetch the UIDs of all messages that we have not yet seen
                    // this does not account for edited messages or messages removed from the server etc.
                    int index = mailbox.Items.Count;
                    var items = imap.Inbox.Fetch(index, -1, MessageSummaryItems.UniqueId);

                    if (items.Count == 0)
                    {
                        return;
                    }

                    var messages = new Stack<MimeMessage>();
                    foreach (var summary in items)
                    {
                        messages.Push(imap.Inbox.GetMessage(summary.UniqueId));
                    }

                    mailbox.Items.RaiseListChangedEvents = false;
                    var existingMessages = mailbox.Items.ToList();
                    mailbox.Items.Clear();

                    // Add New Messages
                    foreach (var mimeMessage in messages)
                    {
                        mailbox.Items.Add(mimeMessage);
                    }

                    // Add existing Messages
                    foreach (var mimeMessage in existingMessages)
                    {
                        mailbox.Items.Add(mimeMessage);
                    }

                    mailbox.Items.RaiseListChangedEvents = true;
                    mailbox.Items.ResetBindings();

                }
            }
        }
    }

    public class MailBoxStorage
    {
        public List<MailBox> LoadMailBoxes()
        {
            var mailBoxes = new List<MailBox>();
            var mailRootDirectory = new DirectoryInfo("MailBoxes");
            if (!mailRootDirectory.Exists)
            {
                return mailBoxes;
            }

            foreach (var mailBoxDirectory in mailRootDirectory.GetDirectories())
            {
                var mailBoxAccountDirectory = mailBoxDirectory.GetDirectories().FirstOrDefault(d => d.Name.Equals("Account", StringComparison.OrdinalIgnoreCase));

                var mailBox = new MailBox();

                // Load Account
                if (mailBoxAccountDirectory == null)
                {
                    mailBoxAccountDirectory = mailBoxDirectory.CreateSubdirectory("Account");
                }

                MailAccount mailBoxAccount;
                var accountSettings = mailBoxAccountDirectory.GetFiles().FirstOrDefault(f => f.Name.Equals("Settings.dat"));

                if (accountSettings == null)
                {
                    mailBoxAccount = new MailAccount();
                }
                else
                {
                    using (var reader = accountSettings.OpenText())
                    {
                        mailBoxAccount = JsonConvert.DeserializeObject<MailAccount>(reader.ReadToEnd());
                    }
                }
                mailBox.Account = mailBoxAccount;

                // Load Messages

                var messagesDirectory = mailBoxDirectory.GetDirectories().FirstOrDefault(d => d.Name.Equals("Messages", StringComparison.OrdinalIgnoreCase));

                if (messagesDirectory == null)
                {
                    messagesDirectory = mailBoxDirectory.CreateSubdirectory("Messages");
                }

                var messages = messagesDirectory.GetFiles().OrderByDescending(f => f.Name);

                mailBox.Items.RaiseListChangedEvents = false;

                foreach (var message in messages)
                {
                    using (var fileStream = message.OpenRead())
                    {
                        mailBox.Items.Add(MimeMessage.Load(fileStream));
                    }
                }

                mailBox.Items.RaiseListChangedEvents = true;
                mailBoxes.Add(mailBox);
            }

            return mailBoxes;
        }

        public void AddOrUpdate(MailBox mailBox)
        {
            var mailRootDirectory = new DirectoryInfo("MailBoxes");
            if (!mailRootDirectory.Exists)
            {
                mailRootDirectory.Create();
            }

            var mailBoxDirectory = mailRootDirectory.GetDirectories().FirstOrDefault(d => d.Name.Equals(mailBox.Account.Identifier, StringComparison.OrdinalIgnoreCase));

            if (mailBoxDirectory == null)
            {
                mailBoxDirectory = mailRootDirectory.CreateSubdirectory(mailBox.Account.Identifier);
            }

            // Save Account Settings
            var mailBoxAccountDirectory = mailBoxDirectory.GetDirectories().FirstOrDefault(d => d.Name.Equals("Account", StringComparison.OrdinalIgnoreCase));

            if (mailBoxAccountDirectory == null)
            {
                mailBoxAccountDirectory = mailBoxDirectory.CreateSubdirectory("Account");
            }

            var serializedAccount = JsonConvert.SerializeObject(mailBox.Account);
            File.WriteAllText(Path.Combine("MailBoxes", mailBox.Account.Identifier, "Account", "Settings.dat"), serializedAccount);

            // Save Messages
            var messagesDirectory = mailBoxDirectory.GetDirectories().FirstOrDefault(d => d.Name.Equals("Messages", StringComparison.OrdinalIgnoreCase));

            if (messagesDirectory == null)
            {
                messagesDirectory = mailBoxDirectory.CreateSubdirectory("Messages");
            }

            if (mailBox.Items.Count == 0)
            {
                return;
            }

            var messages = messagesDirectory.GetFiles().ToDictionary(f => f.Name);
            for (var i = mailBox.Items.Count - 1; i >= 0; i--)
            {
                var fileName = $"{mailBox.Items.Count - i:0000000}.msg";
                var mailItem = mailBox.Items[i];
                if (!messages.ContainsKey(fileName))
                {
                    mailItem.WriteTo(Path.Combine("MailBoxes", mailBox.Account.Identifier, "Messages", fileName));
                }
            }
        }

        public void Remove(MailBox mailBox)
        {
            var mailRootDirectory = new DirectoryInfo("MailBoxes");

            if (!mailRootDirectory.Exists)
            {
                return;
            }

            var mailBoxDirectory = mailRootDirectory.GetDirectories().FirstOrDefault(d => d.Name.Equals(mailBox.Account.Identifier, StringComparison.OrdinalIgnoreCase));
            mailBoxDirectory?.Delete(true);
        }
    }

    public class MailBox
    {
        public BindingList<MimeMessage> Items { get; set; } = new BindingList<MimeMessage>();
        public MailAccount Account { get; set; } = new MailAccount();
    }

    public class MailAccount
    {
        public string Identifier { get; set; } = Guid.NewGuid().ToString("D");
        public string Username { get; set; }
        public string Password { get; set; }
        public int Port { get; set; }
        public string Host { get; set; }
        public bool UseSSL { get; set; }
    }
}
