using System;
using System.Collections.Generic;
using System.Text;

namespace Racooter.DataTransferObjects.Announcement
{
    public class MessageDto
    {
        public long Id { get; set; }
        public string MessageText { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public string Recipient { get; set; }
        public bool IsRead { get; set; }
    }
}
