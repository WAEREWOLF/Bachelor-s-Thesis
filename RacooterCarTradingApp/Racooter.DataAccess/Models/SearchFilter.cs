using System;
using System.Collections.Generic;
using System.Text;

namespace Racooter.DataAccess.Models
{
    public class SearchFilter
    {
        public long Id { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public string Title { get; set; }
        public decimal? Price { get; set; }
        public string Model { get; set; }
        public string Make { get; set; }
        public int? Year { get; set; }
        public int? Mileage { get; set; }
        public int? Power { get; set; }
        public int? CategoryId { get; set; }
    }
}
