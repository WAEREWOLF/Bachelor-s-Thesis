using System;
using System.Collections.Generic;
using System.Text;

namespace Racooter.DataAccess.Models
{
    public class Message
    {
        public long Id { get; set; }
        public string MessageText { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public string Recipient { get; set; }
        public bool IsRead { get; set; }
    }
}
