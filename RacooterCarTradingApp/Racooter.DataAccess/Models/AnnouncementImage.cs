using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Racooter.DataAccess.Models
{
    public class AnnouncementImage
    {
        [Key]
        public Guid AnnouncementImageId { get; set; }
        public string Name { get; set; }
        public string ImagePath { get; set; }
        public Guid? AnnouncementId { get; set; }
        public virtual Announcement Announcement { get; set; }
    }

    public class AnnouncementHistoryImage
    {
        [Key]
        public Guid AnnouncementHistoryImageId { get; set; }
        public string Name { get; set; }
        public string ImagePath { get; set; }
        public Guid? HistoryId { get; set; }
        public virtual History History { get; set; }
    }
}
