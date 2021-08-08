using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Racooter.DataAccess.Models
{
    public class History
    {
        [Key]
        public Guid HistoryId { get; set; }
        public Guid AnnouncementId { get; set; }
        public string Title { get; set; }
        public decimal Price { get; set; }
        public string Description { get; set; }
        public string Category { get; set; }
        public int Views { get; set; }
        public DateTime Date { get; set; }
        public bool IsApprovedByAdmin { get; set; }
        public string CreatedBy { get; set; }
        public string UpdatedBy { get; set; }

    }
}
