using System;
using System.Collections.Generic;

namespace LogicModel
{
    public class Admin : BaseIdentifier
    {        
        public ICollection<NewsPost> NewsPosts { get; set; }
        public AuthenticatedUser AuthenticatedUser { get; set; }
    }
}
