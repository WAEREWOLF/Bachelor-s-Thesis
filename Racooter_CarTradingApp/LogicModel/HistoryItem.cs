using System;

namespace LogicModel
{
    public class HistoryItem
    {
        public string Title { get; set; }
        public string Category { get; set; }
        public DateTime Date { get; set; }
        public bool IsBuy { get; set; }
        public byte[] Image { get; set; }
        public Description Description { get; set; }
        public Specification Specification { get; set; }
    }
}