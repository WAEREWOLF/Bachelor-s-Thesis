using System;
using System.Collections.Generic;
using System.Text;

namespace Racooter.DataAccess.Models
{
    public class Announcement
    {
        public Guid AnnouncementId { get; set; }
        public string Title { get; set; }
        public decimal Price { get; set; }
        public string Description { get; set; }
        public int Category { get; set; }
        public int Views { get; set; }
        public DateTime Date { get; set; }
        public bool IsApprovedByAdmin { get; set; }
        public DateTime CreatedDate { get; set; }
        public string CreatedBy { get; set; }
    }


}
