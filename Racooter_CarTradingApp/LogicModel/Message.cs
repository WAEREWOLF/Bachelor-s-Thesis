using System;

namespace LogicModel
{
    public class Message
    {
        public string Title { get; set; }
        public string Content { get; set; }
        public AuthenticatedUser Recipient { get; set; }
        public AuthenticatedUser Sender { get; set; }
        public DateTime Date { get; set; }
        public bool IsRead { get; set; }
        public bool IsDraft { get; set; }
    }
}