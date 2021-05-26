using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.Threading.Tasks;
using MailKit;

namespace MailProgramm
{
    public static class Verifizierung
    {
        /// <summary>
        /// eventuell nochmal korrigieren was get, set und Sichtbakreit angeht
        /// </summary>
        public static string Username { get; set; }
        
        /// <summary>
        /// Passwort soll nur innerhalb des Programms zugewiesen werden und ausgelesen werden können
        /// </summary>
        internal static string Password { get; set; }
    }
}
