using System;

namespace LogicModel
{
    public class Comment
    {
        public Guid CommentId { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public AuthenticatedUser AuthenticatedUser { get; set; }
        public DateTime Date { get; set; }
    }
}