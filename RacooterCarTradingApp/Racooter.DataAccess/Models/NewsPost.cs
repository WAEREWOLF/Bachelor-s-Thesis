using System;
using System.Collections.Generic;
using System.Text;

namespace Racooter.DataAccess.Models
{
    public class NewsPost
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string SubTitle { get; set; }
        public string Content { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
