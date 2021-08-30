using Racooter.DataAccess.Models;
using Racooter.DataAccess.Repositories;
using Racooter.DataAccess.UnitOfWork;
using Racooter.DataTransferObjects;
using Racooter.DataTransferObjects.Announcement;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Racooter.Business.Logic.Services
{
    public interface IAnnouncementService
    {
        public void AddAnnouncement();
        Task<Guid> SaveAnnouncement(AnnouncementDto data, string CurrentUserId);
        public void AddUpdate(Guid? Id);
        Task<List<CategoryDto>> GetCategories();
        Task SaveCategoryAsync(int id, string name);
        Task DeleteCategory(int id);
        Task<AnnouncementDto> GetAnnouncement(Guid? Id, string CurrentUserId);
        Task Approve(Guid guid);
        Task<List<AnnouncementDto>> GetFiltererdAnnouncements(AnnouncementFilter filter, string CurrentUserId);
        Task<string> GetUserIdByUserName(string userName);
        Task<List<UserDto>> GetAllUsers();
        Task<UserDto> GetUser(string Id);
        Task SaveUser(UserDto model);
        Task DeleteUser(string id);
        Task UploadAnnouncementImages(List<KeyValuePair<string, string>> imagesPaths, string AnnouncementId);
        Task RemoveImage(Guid ImageId);
        Task SaveNewsPost(string Title, string SubTitle, string Content);
        Task DeletePost(int Id);
        Task<List<NewsPost>> GetNewsPostsAsync();
        Task<bool> IsAllowForAnnouncementCreation(string CurrentUserEmail);
        Task DeleteAnnouncement(Guid id);
        Task ReportUser(string UserIdToReport, string CurrentUserId);
    }

    public class AnnouncementService : IAnnouncementService
    {
        private readonly IAnnouncementRepository _announcementRepository;
        private readonly IUnitOfWork _unitOfWork;
        public AnnouncementService(IAnnouncementRepository announcementRepository, IUnitOfWork unitOfWork)
        {
            _announcementRepository = announcementRepository;
            _unitOfWork = unitOfWork;
        }
        public void AddAnnouncement()
        {

        }

        public void AddUpdate(Guid? Id)
        {
            _unitOfWork.Announcements.GetAnnouncement(Id);
        }

        public async Task<AnnouncementDto> GetAnnouncement(Guid? Id, string CurrentUserId)
        {
            var announcement = await _announcementRepository.GetAnnouncement(Id);
            if (announcement.CreatedBy != CurrentUserId)
            {
                await _announcementRepository.AddAnnouncementView(Id);
                _unitOfWork.Commit();
            }
            return announcement;
        }
        public async Task<List<CategoryDto>> GetCategories()
        {
            return await _unitOfWork.Announcements.GetCategoriesAsync();
        }
        public async Task SaveCategoryAsync(int id, string name)
        {
            await _unitOfWork.Announcements.SaveCategoryAsync(id, name);
            _unitOfWork.Commit();
        }

        public async Task DeleteCategory(int id)
        {
            await _unitOfWork.Announcements.DeleteCategory(id);
            _unitOfWork.Commit();
        }

        public async Task<Guid> SaveAnnouncement(AnnouncementDto data, string CurrentUserId)
        {
            return await _announcementRepository.SaveAnnouncement(data, CurrentUserId);
        }
        public async Task Approve(Guid guid)
        {
            await _announcementRepository.Approve(guid);
            _unitOfWork.Commit();
        }
        public async Task<List<AnnouncementDto>> GetFiltererdAnnouncements(AnnouncementFilter filter, string CurrentUserId)
        {
            return await _announcementRepository.GetFiltererdAnnouncements(filter, CurrentUserId);
        }



        public async Task<string> GetUserIdByUserName(string userName)
        {
            return await _announcementRepository.GetUserIdByUserName(userName);
        }



        public async Task<List<UserDto>> GetAllUsers()
        {
            return await _announcementRepository.GetAllUsers();
        }

        public async Task<UserDto> GetUser(string Id)
        {
            return await _announcementRepository.GetUser(Id);
        }

        public async Task SaveUser(UserDto model)
        {
            await _announcementRepository.SaveUser(model);
            _unitOfWork.Commit();
        }

        public async Task DeleteUser(string id)
        {
            await _announcementRepository.DeleteUser(id);
            _unitOfWork.Commit();
        }
        public async Task UploadAnnouncementImages(List<KeyValuePair<string, string>> imagesPaths, string AnnouncementId)
        {
            await _announcementRepository.UploadAnnouncementImages(imagesPaths, AnnouncementId);
        }

        public async Task RemoveImage(Guid ImageId)
        {
            await _announcementRepository.RemoveImage(ImageId);
        }

        public async Task SaveNewsPost(string Title, string SubTitle, string Content)
        {
            await _announcementRepository.SaveNewsPost(Title, SubTitle, Content);
        }
        public async Task DeletePost(int Id)
        {
            await _announcementRepository.DeletePost(Id);
        }

        public async Task<List<NewsPost>> GetNewsPostsAsync()
        {
            return await _announcementRepository.GetNewsPostsAsync();
        }

        public async Task<bool> IsAllowForAnnouncementCreation(string CurrentUserEmail)
        {
            return await _announcementRepository.IsAllowForAnnouncementCreation(CurrentUserEmail);
        }
        public async Task DeleteAnnouncement(Guid id)
        {
            await _announcementRepository.DeleteAnnouncement(id);
        }
        public async Task ReportUser(string UserIdToReport, string CurrentUserId)
        {
            await _announcementRepository.ReportUser(UserIdToReport, CurrentUserId);
        }
    }
}
