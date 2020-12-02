using Racooter.Model;
using System;
using System.Collections.Generic;

namespace LogicModel
{
    public class Announcement : BaseIdentifier
    {        
        public string Title { get; set; }
        public decimal Price { get; set; }
        public virtual ICollection<AnnouncementImage> Images { get; set; }
        public virtual Specification Specification { get; set; }
        public string Description { get; set; }
        public string Category { get; set; }
        public int Views { get; set; }
        public DateTime Date { get; set; }
        public bool IsAproved { get; set; }
    }
}