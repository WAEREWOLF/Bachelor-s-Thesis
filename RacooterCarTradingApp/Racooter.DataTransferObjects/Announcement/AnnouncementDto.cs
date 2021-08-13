using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Http;

namespace Racooter.DataTransferObjects.Announcement
{
    public class AnnouncementDto
    {
        public Guid AnnouncementId { get; set; }
        public string Title { get; set; }
        public decimal Price { get; set; }
        public string Description { get; set; }
        public int Category { get; set; }
        public int Views { get; set; }
        public DateTime Date { get; set; }
        public bool IsApprovedByAdmin { get; set; }
        public DateTime CreatedDate { get; set; }
        public string CreatedBy { get; set; }
        public string UserName { get; set; }
        public string UserEmail { get; set; }
        public SpecificationDto Specification { get; set; }

        public List<AnnouncementImageDto> AnnouncementImages { get; set; }
        public List<CategoryDto> Categories { get; set; }
        public string CategoryString { get; set; }
        public List<string> ImagesPath { get; set; }
        public List<IFormFile> Images { get; set; }
        public char FilterColumn { get; set; }
        public AnnouncementDto()
        {
            Specification = new SpecificationDto();
            AnnouncementImages = new List<AnnouncementImageDto>();
            Categories = new List<CategoryDto>();
            Images = new List<IFormFile>();
            ImagesPath = new List<string>();
        }
    }

    public class AnnouncementFilter
    {
        public int PageNumber { get; set; }
        public string Title { get; set; }
        public int? Category { get; set; }
        public int? Price { get; set; }
        public string Model { get; set; }
        public string Make { get; set; }
        public int? Year { get; set; }
        public int? Mileage { get; set; }
        public int? Power { get; set; }
    }

    public class CategoryDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }

    

    public class SaveObj
    {
        public string Test { get; set; }
        public string AnnouncementId { get; set; }
        public List<IFormFile> Images { get; set; }
        public SaveObj()
        {
            Images = new List<IFormFile>();
        }
    }
    public class AnnouncementImageDto
    {
        public Guid AnnouncementImageId { get; set; }
        public string Name { get; set; }
        public string ImagePath { get; set; }
        public Guid? AnnouncementId { get; set; }
    }

    public class SpecificationDto
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
        
    }
}
