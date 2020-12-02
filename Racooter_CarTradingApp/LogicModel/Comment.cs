using System;

namespace LogicModel
{
    public class Comment : BaseIdentifier
    {
        public string Title { get; set; }
        public string Content { get; set; }
        public virtual AuthenticatedUser AuthenticatedUser { get; set; }
        public DateTime Date { get; set; }
    }
}