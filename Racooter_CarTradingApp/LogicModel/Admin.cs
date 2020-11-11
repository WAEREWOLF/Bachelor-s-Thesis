using System;
using System.Collections.Generic;

namespace LogicModel
{
    public class Admin
    {
        public Guid AdminId { get; set; }
        public ICollection<NewsPost> NewsPosts { get; set; }
        public AuthenticatedUser AuthenticatedUser { get; set; }
    }
}
