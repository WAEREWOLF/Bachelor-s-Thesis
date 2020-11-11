using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LogicModel
{
    public class Moderator
    {
        public AuthenticatedUser AuthenticatedUser { get; set; }
        public ICollection<NewsPosts> NewsPosts { get; set; }
    }
}
