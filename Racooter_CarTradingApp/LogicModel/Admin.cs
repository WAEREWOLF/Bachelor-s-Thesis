using System.Collections.Generic;

namespace LogicModel
{
    public class Admin
    {
        public ICollection<NewsPosts> NewsPosts { get; set; }
        public AuthenticatedUser AuthenticatedUser { get; set; }
    }
}
