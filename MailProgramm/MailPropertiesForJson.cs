using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MailProgramm
{
    public  class MailPropertiesForJson
    {
        public string Absender { get; set; }
        public  string Empfaenger { get; set; }
        public  string Betreff { get; set; }
        public  string Nachricht { get; set; }
        public  string Zeitstempel { get; set; }
    }
}
