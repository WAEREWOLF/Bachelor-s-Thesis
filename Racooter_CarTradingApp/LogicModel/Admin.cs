using System;
using System.Collections.Generic;

namespace LogicModel
{
    public class Admin : BaseIdentifier
    {        
        public virtual ICollection<NewsPost> NewsPosts { get; set; }
        public virtual AuthenticatedUser AuthenticatedUser { get; set; }
    }
}
