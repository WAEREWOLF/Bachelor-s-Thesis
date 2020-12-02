using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LogicModel
{
    public class Moderator : BaseIdentifier
    {
        public virtual AuthenticatedUser AuthenticatedUser { get; set; }
        public virtual ICollection<NewsPost> NewsPosts { get; set; }
    }
}
