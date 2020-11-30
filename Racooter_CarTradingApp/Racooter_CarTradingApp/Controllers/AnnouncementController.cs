using System;
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
        public IActionResult Index(string title, string category, decimal lowPrice, decimal highPrice, DateTime lowDate, DateTime highDate)
        {
            if (title == null && category == null && lowPrice == 0 && highPrice == 0 && lowDate == null&& highDate == null)
            {
                var announcements = announcementsService.GetAllAnnouncements();
                return View(new AnnouncementViewModel { Announcements = announcements});
            }
            try
            {
                var filteredAnnouncements = announcementsService.GetAnnouncementsAccordingToFilters(title, category, lowPrice, highPrice, lowDate, highDate);
                return View(new AnnouncementViewModel { Announcements = filteredAnnouncements });
            }
            catch (Exception)
            {
                return BadRequest("Invalid request!");
            }

        }

        #region AdvancedFilter
        
        [HttpGet]
        public IActionResult AdvancedFilter()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AdvancedFilter([FromForm]AdvancedFilterViewModel filterModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Model is invalid!");
            }

            //if (filterModel == null)
            //{
            //    return BadRequest("Model is null!");
            //}

            announcementsService.GetAnnouncementsBySpecification(filterModel.Specification);
            return Redirect(Url.Action("Index", "Announcement"));
        }
        #endregion

        #region ADD

        [HttpGet]
        public IActionResult AddAnnouncement()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddAnnouncement([FromForm]AddAnnouncementViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Model is invalid!");
            }

            announcementsService.AddAnnoouncement(model.Announcement);
            return Redirect(Url.Action("Index", "Announcement"));
        }
        #endregion

        #region Delete

        [HttpGet]
        public IActionResult DeleteAnnouncement()
        {
            return View();
        }

        [HttpPost]
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

        #region Update

        [HttpGet]
        public IActionResult UpdateAnnouncement()
        {
            return View();
        }

        [HttpPost]
        public IActionResult UpdateAnnouncement([FromForm]UpdateAnnouncementViewModel model, Guid oldAnnouncementId)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Model is invalid!");
            }

            announcementsService.UpdateAnnouncement(oldAnnouncementId, model.Announcement);
            return Redirect(Url.Action("Index", "Announcement"));
        }
        #endregion
    }
}