using System;

namespace LogicModel
{
    public class Location
    {
        public Guid LocationId { get; set; }
        public string Country { get; set; }
        public string State { get; set; }
        public string City { get; set; }
        public string Street { get; set; }
        public string Block { get; set; }
        public string Coordinates { get; set; }
        public int Number { get; set; }
    }
}