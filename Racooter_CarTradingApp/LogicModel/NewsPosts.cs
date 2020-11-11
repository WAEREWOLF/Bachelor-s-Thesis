using System;
using System.Collections.Generic;

namespace LogicModel
{
    public class NewsPosts
    {
        public string Title { get; set; }
        public string Subtitle { get; set; }
        public string Content { get; set; }
        public DateTime Date { get; set; }
        public int Views { get; set; }
        public int Likes { get; set; }
        public int Dislikes { get; set; }
        public ICollection<Comment> Comments { get; set; }
}
}