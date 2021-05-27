using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MimeKit;
using MailKit;
using MailKit.Search;
using MailKit.Net.Imap;
using System.Threading;
using System.IO;
using Newtonsoft.Json;

namespace MailProgramm
{
    public static class ReadServer
    {
        private static string server = "imap.gmx.net";
        private static int port = 993;
        private static bool ssl = true;
        private static List<MimeMessage> list = new List<MimeMessage>();

        // to pair subject and date from one mail
        private static List<KeyVal<string, string>> subjectsDates = new List<KeyVal<string, string>>();

        private static KeyVal<string, string> subjectDate;

        internal static ImapClient imapClient = new ImapClient();

        private static int i = 0;

        public static void Connection()
        {
            imapClient.Connect(server, port, ssl);

            imapClient.Authenticate(Verifizierung.Username, Verifizierung.Password);
        }
        
        /// <summary>
        /// read messages from server and safe them in a local file
        /// </summary>
        /// <returns></returns>
        public static List<KeyVal<string, string>> ReadAndSaveMessages()
        {

            imapClient.Inbox.Open(FolderAccess.ReadOnly);

            foreach (UniqueId id in imapClient.Inbox.Search(SearchQuery.DeliveredOn(System.DateTime.Today)))
            {
               list.Add(imapClient.Inbox.GetMessage(id));
            }

            foreach(MimeMessage mail in list)
            {
               
                subjectDate = new KeyVal<string, string>();

                subjectDate.Name = Convert.ToString(i);
                subjectDate.id = mail.Subject;
                subjectDate.value = CutString(Convert.ToString(mail.Date));

                subjectsDates.Add(subjectDate);

                ++i;

            }

            //Speichern der Nachrichten
            SaveMessages();

            // Öffnen der Dateil und lesen

            return subjectsDates;
        }

        /// <summary>
        /// Speichern Methode soll nur in dieser Klasse sein 
        /// soll in ReadAndSaveMessage aufgerufen werden
        /// wird im JSON Format gespeichert
        /// </summary>
        private static void SaveMessages()
        {
                int i = 0;

            
                string path = null;
                JsonSerializer serializer = new JsonSerializer();

                // Zeitstempel um Mails später zu lesen
                DateTime dtActualDate = DateTime.Today;

                foreach (MimeMessage mail in list)
                {
                    path = @"c:\Mailprogramm\" + i + dtActualDate.Day + dtActualDate.Month + dtActualDate.Year + ".txt";

                    StringBuilder sb = new StringBuilder();
                    StringWriter sw = new StringWriter(sb);

                    string subject = mail.Subject;
                    InternetAddressList empfänger = mail.To;
                    string to = null;
                    string from = null;
                    InternetAddressList sender = mail.From;
                    string text = mail.TextBody;
                    string strActualDate = Convert.ToString(dtActualDate);

                    foreach (MailboxAddress adress in empfänger)
                    {
                        to = adress.Address;
                    }

                    foreach (MailboxAddress adress in sender)
                    {
                        from = adress.Address;
                    }

                    using (JsonWriter writer = new JsonTextWriter(sw))
                    {
                        writer.WriteStartObject();
                        writer.WritePropertyName("Absender");
                        writer.WriteValue(from);
                        writer.WritePropertyName("Empfaenger");
                        writer.WriteValue(to);
                        writer.WritePropertyName("Betreff");
                        writer.WriteValue(subject);
                        writer.WritePropertyName("Nachricht");
                        writer.WriteValue(text);
                        writer.WritePropertyName("Zeitstempel");
                        writer.WriteValue(strActualDate);
                        writer.WriteEndObject();

                    }

                    using (StreamWriter sW = File.AppendText(path))
                    {

                        sW.WriteLine(sb);

                    }

                    ++i;
                } 
        }

        private static string CutString(string dateString)
        {
            string newDateString = dateString.Substring(0, 11);

            return newDateString; 
        }
    }
}
