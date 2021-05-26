using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MailKit.Net.Smtp;

namespace MailProgramm
{
    public static class Client
    {
        private static string host = "mail.gmx.net";
        private static int port = 465;
        private static bool ssl = true;

        private static SmtpClient client = new SmtpClient();

        /// <summary>
        /// Connect the client with the mailserver.
        /// </summary>
        public static void connect()
        {
            client.Connect(host, port, ssl);

            // vielleicht nochmal überdenken und überarbeiten?
            client.Authenticate(Verifizierung.Username, Verifizierung.Password);
            
        }

        /// <summary>
        /// Call the createMail method from Mail class and send this message to the receiver.
        /// </summary>
        public static void sendMessage()
        {
            client.Send(Mail.createMail());
        }

        public static void closeConnection()
        {
            client.Disconnect(true);
        }

    }
}
