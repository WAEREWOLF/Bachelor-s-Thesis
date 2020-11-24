using System;

namespace LogicModel
{
    public class Announcement : BaseIdentifier
    {        
        public string Title { get; set; }
        public decimal Price { get; set; }
        public byte[] Images { get; set; }
        public Description Description { get; set; }
        public Specification Specification { get; set; }
        public int Views { get; set; }
        public DateTime Date { get; set; }
        public string Category { get; set; }
        public bool IsAproved { get; set; }
    }
}