using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Racooter.DataAccess.Models
{
    public enum FuelType
    {
        diesel = 1,
        GPL = 2,
        Petrol = 3,
        Electric = 4,
        Hybrid = 5
    }

    public enum BodyType
    {
        Cabrio = 1,
        Sedan = 2,
        Coupe = 3,
        Hatchback = 4,
        SUV = 5
    }
    public class Specification
    {
        public Guid SpecificationId { get; set; }
        public string Make { get; set; }
        public string Model { get; set; }
        public int? Year { get; set; }
        public int? Mileage { get; set; }
        public int? GetFuelType { get; set; }
        public string FuelTypeSelected { get; set; }
        public int? Power { get; set; }
        public int BodyType { get; set; }
        public string BodyTypeSelected { get; set; }
        public int? NrOfDoors { get; set; }
        public string GearBox { get; set; }
        public int EngineSize { get; set; }
        public string Emissions { get; set; }
        public string Color { get; set; }
        public bool IsNegotiable { get; set; }
        public bool IsFullOptions { get; set; }
        public bool HasABS { get; set; }
        public bool HasESP { get; set; }
        public bool HasWarranty { get; set; }
        public bool HasLogHistory { get; set; }
        public bool HasCruiseControl { get; set; }
        public bool HasDualZoneClimate { get; set; }
        public bool HasFullElectricWin { get; set; }
        public bool HasHeatedSeats { get; set; }
        public bool HasVentedSeats { get; set; }
        public bool HasElectricMirrors { get; set; }
        public bool HasHeatedStWheel { get; set; }
        public bool HadAccident { get; set; }
        public Guid? AnnouncementId { get; set; }
        public virtual Announcement Announcement { get; set; }
    }


    public class SpecificationHistory
    {
        [Key]
        public Guid SpecificationHistoryId { get; set; }
        public string Make { get; set; }
        public string Model { get; set; }
        public string Year { get; set; }
        public string Mileage { get; set; }
        public int GetFuelType { get; set; }
        public string Power { get; set; }
        public string BodyType { get; set; }
        public int NrOfDoors { get; set; }
        public string GearBox { get; set; }
        public string EngineSize { get; set; }
        public string Emissions { get; set; }
        public string Color { get; set; }
        public bool IsNegotiable { get; set; }
        public bool IsFullOptions { get; set; }
        public bool HasABS { get; set; }
        public bool HasESP { get; set; }
        public bool HasWarranty { get; set; }
        public bool HasLogHistory { get; set; }
        public bool HasCruiseControl { get; set; }
        public bool HasDualZoneClimate { get; set; }
        public bool HasFullElectricWin { get; set; }
        public bool HasHeatedSeats { get; set; }
        public bool HasVentedSeats { get; set; }
        public bool HasElectricMirrors { get; set; }
        public bool HasHeatedStWheel { get; set; }
        public bool HadAccident { get; set; }
        public Guid? AnnouncementId { get; set; }
        public virtual History History { get; set; }
    }
}
