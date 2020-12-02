using System;

namespace LogicModel
{
    public class HistoryItem : BaseIdentifier
    {        
        public string Title { get; set; }
        public string Category { get; set; }
        public DateTime Date { get; set; }
        public bool IsBuy { get; set; }
        public byte[] Image { get; set; }
        public string Description { get; set; }
        public virtual Specification Specification { get; set; }
    }
}