using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MailKit;
using MimeKit;

namespace MailProgramm
{
    public static class Mail
    {

        #region Properties
        /// <summary>
        /// Name of the sender
        /// </summary>
        public static string SenderName { get; set; }

        public static string SenderMail { get; set; }

        /// <summary>
        /// Name of the receiver
        /// </summary>
        public static string ReceiverName { get; set; }

        /// <summary>
        /// Mailaddress from the receiver
        /// </summary>
        public static string ReceiverMail { get; set; }

        /// <summary>
        /// Subject of the mail
        /// </summary>
        public static string MailSubject { get; set; }

        /// <summary>
        /// Text of the mail
        /// </summary>
        public static string MailText { get; set; }

        #endregion


        /// <summary>
        /// A mail with sender, receiver, subject and body will be create with this method
        /// </summary>
        /// <returns></returns>
        internal static MimeMessage createMail()
        {

            MimeMessage message = new MimeMessage();

            MailboxAddress adressSender = new MailboxAddress("", SenderMail);
            MailboxAddress adressReceiver = new MailboxAddress("", ReceiverMail);

            
            message.From.Add(adressSender);
            message.To.Add(adressReceiver);

            message.Subject = MailSubject;


            // siehe http://www.mimekit.net/docs/html/Creating-Messages.htm#!
            BodyBuilder body = new BodyBuilder();

            body.TextBody = MailText;

            message.Body = body.ToMessageBody();

            return message;
        }

    }
}
