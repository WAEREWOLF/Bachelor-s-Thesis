using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LogicModel
{
    public class Moderator : BaseIdentifier
    {
        public AuthenticatedUser AuthenticatedUser { get; set; }
        public ICollection<NewsPost> NewsPosts { get; set; }
    }
}
