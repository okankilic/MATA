using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MATA.Data.DTO.Models
{
    public class MailDTO
    {
        public int ID { get; set; }

        public string Subject { get; set; }

        public bool IsBodyHtml { get; set; }

        public string MailBody { get; set; }

        public string State { get; set; }

        public int TryCount { get; set; }

        public DateTime LastTryTime { get; set; }

        public List<string> TOList { get; set; }

        public List<string> CCList { get; set; }

        public List<string> BCCList { get; set; }

        public MailDTO()
        {
            this.TOList = new List<string>();
            this.CCList = new List<string>();
            this.BCCList = new List<string>();
        }
    }
}
