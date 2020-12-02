using System;

namespace LogicModel
{
    public class Message : BaseIdentifier
    {
        public string Title { get; set; }
        public string Content { get; set; }
        public virtual AuthenticatedUser Recipient { get; set; }        
        public DateTime Date { get; set; }
        public bool IsRead { get; set; }
        public bool IsDraft { get; set; }
    }
}