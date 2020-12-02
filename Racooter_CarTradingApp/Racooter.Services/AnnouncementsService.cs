using LogicModel;
using Racooter.Abstractions;
using System;
using System.Collections.Generic;

namespace Racooter.Services
{
    public class AnnouncementsService
    {
        private readonly IAnnouncementRepository announcementRepository;        

        public AnnouncementsService(IAnnouncementRepository announcementRepository)
        {
            this.announcementRepository = announcementRepository;
        }
        
        public IEnumerable<Announcement> GetAllAnnouncements()
        {
            return announcementRepository.GetAll();
        }

        public void AddAnnoouncement(Announcement announcement)
        {
            announcementRepository.Add(new Announcement() { Id = Guid.NewGuid(), Title = announcement.Title, Category = announcement.Category, Description = announcement.Description,
                                                            Date = announcement.Date, Images = announcement.Images, Price = announcement.Price,
                                                            Specification = announcement.Specification, Views = announcement.Views, IsAproved = announcement.IsAproved
            });
        }

        public void DeleteAnnouncement(Guid announcementId)
        {
            var announcement = announcementRepository.GetAnnouncementById(announcementId);
            announcementRepository.Delete(announcement);
        }

        public void UpdateAnnouncement(Guid announcementId, Announcement newAnnouncement)
        {
            var announcement = announcementRepository.GetAnnouncementById(announcementId);
            announcement = newAnnouncement;
            announcementRepository.Update(announcement);
        }

        public IEnumerable<Announcement> GetAnnouncementsAccordingToFilters(string title, string category, decimal lowPrice, decimal highPrice, DateTime lowDate, DateTime highDate)
        {
            return announcementRepository.GetAnnouncementsAccordingToFilters(title, category, lowPrice, highPrice, lowDate, highDate);
        }

        public IEnumerable<Announcement> GetAnnouncementsBySpecification(Specification specification)
        {
            return announcementRepository.GetAnnouncementsBySpecification(specification);
        }

    }
}
