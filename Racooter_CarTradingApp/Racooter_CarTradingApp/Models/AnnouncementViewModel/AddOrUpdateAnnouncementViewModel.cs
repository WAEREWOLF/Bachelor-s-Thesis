using LogicModel;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Racooter.UI.Models.AnnouncementViewModel
{
    public class AddOrUpdateAnnouncementViewModel
    {
        // TODO validate the fields
        public Guid Id { get; set; }
        [Required] 
        [StringLength(100,ErrorMessage ="Limit exceeded!", MinimumLength = 10)]
        public string Description { get; set; }
        public List<IFormFile> Images { get; set; }
        [Required]
        [StringLength(50, ErrorMessage = "Limit exceeded!", MinimumLength = 5)]
        public string Title { get; set; }
        [Required]
        public decimal Price { get; set; }
        [Required]
        [StringLength(15, ErrorMessage = "Limit exceeded!", MinimumLength = 5)]
        public string Category { get; set; }

        // Specification fields
        [Required]
        [StringLength(15, ErrorMessage = "Limit exceeded!", MinimumLength = 5)]
        public string Make { get; set; }
        [Required]
        [StringLength(15, ErrorMessage = "Limit exceeded!", MinimumLength = 5)]
        public string Model { get; set; }
        [Required]
        [StringLength(15, ErrorMessage = "Limit exceeded!", MinimumLength = 5)]
        public string Year { get; set; }
        [Required]
        [StringLength(15, ErrorMessage = "Limit exceeded!", MinimumLength = 5)]
        public string Mileage { get; set; }
        [Required]        
        public FuelType GetFuelType { get; set; }
        [Required]
        [StringLength(15, ErrorMessage = "Limit exceeded!", MinimumLength = 5)]
        public string Power { get; set; }
        [Required]
        [StringLength(15, ErrorMessage = "Limit exceeded!", MinimumLength = 5)]
        public string BodyType { get; set; }
        [Required]
        [Range(2,5)]
        public int NrOfDoors { get; set; }
        [Required]
        [StringLength(10, ErrorMessage = "Limit exceeded!", MinimumLength = 6)]
        public string GearBox { get; set; }
        [Required]
        [StringLength(10, ErrorMessage = "Limit exceeded!", MinimumLength = 5)]
        public string EngineSize { get; set; }
        public string Emissions { get; set; }
        public string Color { get; set; }
        [Required]
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

    }
}
