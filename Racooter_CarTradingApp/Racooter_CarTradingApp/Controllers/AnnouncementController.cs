using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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

        // TODO: if no filters are applied then GetAll() else display acording to filters all the announcemnts
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

        //TODO: add method for advance filtering -> by Specification
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


        //TODO: add methods for ADD/DELETE/UPDATE announcements
    }
}