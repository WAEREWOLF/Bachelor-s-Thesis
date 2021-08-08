using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Racooter.Business.Logic.Services;
using Racooter.DataAccess.UnitOfWork;
using Racooter.DataTransferObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RacooterCarTradingApp.Controllers
{
    [Authorize(Roles = "Admin")]
    public class UsersController : Controller
    {
        private readonly IAnnouncementService _announcementService;
        private readonly IUnitOfWork _unitOfWork;
        public UsersController(IUnitOfWork unitOfWork, IAnnouncementService announcementService)
        {
            _unitOfWork = unitOfWork;
            _announcementService = announcementService;
        }
        public async Task<IActionResult> Index()
        {
            var data = await _announcementService.GetAllUsers();
            return View(data);
        }

        public async Task<IActionResult> UpdateUser(string Id)
        {
            var user = await _announcementService.GetUser(Id);
            return View(user);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateUser(UserDto model)
        {
            await _announcementService.SaveUser(model);
            return Json(true);
        }

        public async Task<IActionResult> DeleteUser(string id)
        {
            await _announcementService.DeleteUser(id);
            return RedirectToAction("Index");
        }
    }
}
