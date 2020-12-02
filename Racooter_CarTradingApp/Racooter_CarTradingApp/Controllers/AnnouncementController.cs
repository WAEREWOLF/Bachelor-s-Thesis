using System;
using LogicModel;
using Microsoft.AspNetCore.Mvc;
using Racooter.Services;
using Racooter.UI.Models.AnnouncementViewModel;

namespace Racooter.UI.Controllers
{
    public class AnnouncementController : Controller
    {
        private readonly AnnouncementsService announcementsService;
        
        public AnnouncementController(AnnouncementsService announcementsService)
        {
            this.announcementsService = announcementsService;
        }

        // TODO: if no filters are applied then GetAll() else display acording to filters all the announcements
        //public IActionResult Index(string title, string category, decimal lowPrice, decimal highPrice, DateTime lowDate, DateTime highDate)
        //{
        //    if (title == null && category == null && lowPrice == 0 && highPrice == 0 && lowDate == null&& highDate == null)
        //    {
        //        var announcements = announcementsService.GetAllAnnouncements();
        //        return View(new AnnouncementViewModel { Announcements = announcements});
        //    }
        //    try
        //    {
        //        var filteredAnnouncements = announcementsService.GetAnnouncementsAccordingToFilters(title, category, lowPrice, highPrice, lowDate, highDate);
        //        return View(new AnnouncementViewModel { Announcements = filteredAnnouncements });
        //    }
        //    catch (Exception)
        //    {
        //        return BadRequest("Invalid request!");
        //    }

        //}
        public IActionResult Index()
        { 
            try
            {
                var announcements = announcementsService.GetAllAnnouncements();
                return View(new AnnouncementViewModel { Announcements = announcements });
            }
            catch (Exception)
            {
                return BadRequest("Invalid request!");
            }

        }

        #region AdvancedFilter
        
        [HttpGet]
        public IActionResult AdvancedFilter([FromForm]AdvancedFilterViewModel filterModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Model is invalid!");
            }

            announcementsService.GetAnnouncementsBySpecification(filterModel.Specification);
            return Redirect(Url.Action("Index", "Announcement"));
        }
        #endregion

        #region ADD

        [HttpGet]
        public IActionResult AddOrUpdateAnnouncement()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddOrUpdateAnnouncement([FromForm]AddOrUpdateAnnouncementViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Model is invalid!");
            }
            // TODO check Guid if null in order to add or update
            // create a new announcement object and pass the fields from the model
            var announcement = new Announcement
            {
                Category = viewModel.Category,
                Description = viewModel.Description,
                //Images = viewModel.Images, // TODO investigate on this
                Price = viewModel.Price,
                Title = viewModel.Title,
                IsAproved = false,
                Date = DateTime.Now,
                Specification = new Specification
                {
                    Id = Guid.NewGuid(),
                    Make = viewModel.Make,
                    BodyType = viewModel.BodyType,
                    Color = viewModel.Color,
                    Emissions = viewModel.Emissions,
                    EngineSize = viewModel.EngineSize,
                    GearBox = viewModel.GearBox,
                    GetFuelType = viewModel.GetFuelType,
                    HadAccident = viewModel.HadAccident,
                    HasABS = viewModel.HasABS,
                    HasCruiseControl = viewModel.HasCruiseControl,
                    HasDualZoneClimate = viewModel.HasDualZoneClimate,
                    HasElectricMirrors = viewModel.HasElectricMirrors,
                    HasESP = viewModel.HasESP,
                    HasFullElectricWin = viewModel.HasFullElectricWin,
                    HasHeatedSeats = viewModel.HasHeatedSeats,
                    HasHeatedStWheel = viewModel.HasHeatedStWheel,
                    HasLogHistory = viewModel.HasLogHistory,
                    HasVentedSeats = viewModel.HasVentedSeats,
                    HasWarranty = viewModel.HasWarranty,
                    IsFullOptions = viewModel.IsFullOptions,
                    IsNegotiable = viewModel.IsNegotiable,
                    Mileage = viewModel.Mileage,
                    Model = viewModel.Model,
                    NrOfDoors = viewModel.NrOfDoors,
                    Power = viewModel.Power,
                    Year = viewModel.Year
                }
            };
            
            if (viewModel.Id != null)
            {
                announcementsService.UpdateAnnouncement(viewModel.Id, announcement);
                return Redirect(Url.Action("Index", "Announcement"));
            }
            announcementsService.AddAnnoouncement(announcement);
            return Redirect(Url.Action("Index", "Announcement"));
        }
        #endregion

        #region Delete

        [HttpGet]
        public IActionResult DeleteAnnouncement()
        {
            return View();
        }

        [HttpDelete]
        public IActionResult DeleteAnnouncement(Guid announcementId)
        {
            if(announcementId != null)
            {
                announcementsService.DeleteAnnouncement(announcementId);
                return Redirect(Url.Action("Index", "Announcement"));
            }
            return BadRequest("Provided announcementId is null!");
        }
        #endregion
    }
}