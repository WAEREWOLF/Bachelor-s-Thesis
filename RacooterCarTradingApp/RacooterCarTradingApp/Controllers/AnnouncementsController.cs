using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Racooter.Business.Logic.Services;
using Racooter.DataAccess.Models;
using Racooter.DataAccess.UnitOfWork;
using Racooter.DataTransferObjects.Announcement;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace RacooterCarTradingApp.Controllers
{
    [Authorize]
    public class AnnouncementsController : Controller
    {
        private readonly IAnnouncementService _announcementService;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IWebHostEnvironment _hostEnvironment;
        private readonly IMessageService _messageService;
        public AnnouncementsController(IUnitOfWork unitOfWork, IAnnouncementService announcementService, IWebHostEnvironment hostEnvironment, IMessageService messageService)
        {
            _unitOfWork = unitOfWork;
            _announcementService = announcementService;
            _hostEnvironment = hostEnvironment;
            _messageService = messageService;
        }

        #region Announcements Management
        public async Task<IActionResult> Index()
        {
            var announcements = _unitOfWork.Announcements.GetAll().Select(x => new AnnouncementDto
            {
                AnnouncementId = x.AnnouncementId,
                Category = x.Category,
                CreatedDate = x.CreatedDate,
                Price = x.Price,
                Title = x.Title,
                Views = x.Views,
                IsApprovedByAdmin = x.IsApprovedByAdmin,
                CreatedBy = x.CreatedBy
            }).ToList();

            var currentUserEmail = User.Identity.Name;

            if (!User.IsInRole("Admin") && !User.IsInRole("Moderator"))
            {
                var currentUserId = await GetCurrentUserId();
                announcements = announcements.Where(x => x.CreatedBy == currentUserId).ToList();
            }

            var categories = await _announcementService.GetCategories();

            ViewBag.IsAllowedForAnnouncement = await _announcementService.IsAllowForAnnouncementCreation(currentUserEmail);

            foreach (var item in announcements)
            {
                item.CategoryString = categories.Where(x => x.Id == item.Category).Select(r => r.Name).FirstOrDefault();
                item.CategoryString = string.IsNullOrEmpty(item.CategoryString) ? "No Category" : item.CategoryString;
            }

            return View(announcements);
        }

        public async Task<IActionResult> AddUpdate(Guid? Id)
        {
            var currentUserId = await GetCurrentUserId();
            var currentUserEmail = User.Identity.Name;
            var isAllowed = await _announcementService.IsAllowForAnnouncementCreation(currentUserEmail);
            if (User.IsInRole("Admin") || User.IsInRole("Moderator"))
            {
                isAllowed = true;
            }
            ViewBag.IsAllowed = isAllowed;
            var model = await _announcementService.GetAnnouncement(Id, currentUserId);
            ViewBag.CurrentUserId = currentUserId;
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> AddUpdate(AnnouncementDto data, string CurrentUserId)
        {
            if (string.IsNullOrEmpty(CurrentUserId))
                CurrentUserId = await GetCurrentUserId();
            var announcementId = await _announcementService.SaveAnnouncement(data, CurrentUserId);
            return Ok(announcementId);
        }

        public async Task<IActionResult> RemoveImage(Guid id, string aId)
        {
            await _announcementService.RemoveImage(id);
            return RedirectToAction("AddUpdate", new { Id = aId });
        }

        public async Task<IActionResult> Categories()
        {
            return View();
        }

        public async Task<IActionResult> _Categories()
        {
            return PartialView(await _announcementService.GetCategories());
        }

        [HttpPost]
        public async Task<IActionResult> SaveCategory(int id, string name)
        {
            await _announcementService.SaveCategoryAsync(id, name);
            return Json(true);
        }

        public async Task<IActionResult> DeleteCategory(int id)
        {
            await _announcementService.DeleteCategory(id);
            return Json(true);
        }

        public async Task<IActionResult> Announcement(Guid? Id)
        {
            var currentUserId = await GetCurrentUserId();
            if (Id != null && Id != Guid.Empty)
            {
                
                var announcement = await _announcementService.GetAnnouncement(Id.Value, currentUserId);
                return View(announcement);
            }
            ViewBag.CurrentUserId = currentUserId;
            return View(new AnnouncementDto());
        }


        public async Task<IActionResult> Messages(string id)
        {
            var currentUserId = await GetCurrentUserId();
            await _messageService.AddFirstMessage(id, currentUserId);
            ViewBag.MessageUsers = await _messageService.GetAllUsersForMessages(currentUserId);
            ViewBag.ReceipentId = id;
            return View();
        }

        public async Task<IActionResult> UserMessages(string userId)
        {
            var currentUserId = await GetCurrentUserId();
            var list = await _messageService.GetUserMessages(userId, currentUserId);
            ViewBag.CurrentUserId = currentUserId;
            return PartialView(list);
        }

        [HttpPost]
        public async Task<IActionResult> SaveMessage(string MessageText, string receiverId)
        {
            await _messageService.SaveMessage(MessageText, receiverId, await GetCurrentUserId());
            return Json(true);
        }


        [AllowAnonymous]
        public async Task<IActionResult> Home()
        {
            var categories = await _announcementService.GetCategories();
            ViewBag.Categories = categories;
            return View();
        }

        [AllowAnonymous]
        public async Task<IActionResult> _Home(AnnouncementFilter filter)
        {
            var currentUserId = string.Empty;
            if (User.Identity.IsAuthenticated)
            {
                currentUserId = await GetCurrentUserId();
            }
            ViewBag.CurrentUserId = currentUserId;
            var approvedAnnouncements = await _announcementService.GetFiltererdAnnouncements(filter, currentUserId);
            return PartialView(approvedAnnouncements);
        }

        public async Task<IActionResult> Delete(Guid id)
        {
            await _announcementService.DeleteAnnouncement(id);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Approve(Guid Guid)
        {
            await _announcementService.Approve(Guid);
            return Ok();
        }

        public async Task<string> GetCurrentUserId()
        {
            var name = User.Identity.Name;
            //return await _unitOfWork.Users.GetAll().Where(x => x.UserName == name).Select(r => r.Id).FirstOrDefaultAsync();
            return await _announcementService.GetUserIdByUserName(name);
        }

        [HttpPost]
        public async Task<IActionResult> UploadImages(SaveObj data)
        {
            List<KeyValuePair<string, string>> list = new List<KeyValuePair<string, string>>();

            string webRootPath = _hostEnvironment.WebRootPath;

            if (data != null)
            {
                foreach (var item in data.Images)
                {
                    string fileName = Guid.NewGuid().ToString();
                    var uploads = Path.Combine(webRootPath, @"Images");
                    var extension = Path.GetExtension(item.FileName);
                    var imagePath = Path.Combine(webRootPath, fileName.TrimStart('\\'));
                    if (System.IO.File.Exists(imagePath))
                    {
                        System.IO.File.Delete(imagePath);
                    }
                    using (var fileStreams = new FileStream(Path.Combine(uploads, fileName + extension), FileMode.Create))
                    {
                        item.CopyTo(fileStreams);
                    }
                    var fullImagePath = @"\Images\" + fileName + extension;
                    list.Add(new KeyValuePair<string, string>(fileName + item.FileName, fullImagePath));
                }

                await _announcementService.UploadAnnouncementImages(list, data.AnnouncementId);

            }

            return Json(true);
        }

        [AllowAnonymous]
        public async Task<IActionResult> NewsPosts()
        {
            var data = await _announcementService.GetNewsPostsAsync();
            return View(data);
        }

        [HttpPost]
        public async Task<IActionResult> SaveNewsPost(string Title, string SubTitle, string Content)
        {
            await _announcementService.SaveNewsPost(Title, SubTitle, Content);
            return Json(true);
        }

        public async Task<IActionResult> DeleteNewsPost(int id)
        {
            await _announcementService.DeletePost(id);
            return RedirectToAction("NewsPosts");
        }

        public async Task<IActionResult> ReportUser(string UserIdToReport)
        {
            var currentUserId = await GetCurrentUserId();
            await _announcementService.ReportUser(UserIdToReport, currentUserId);
            return Json(true);
        }
        #endregion



    }
}
