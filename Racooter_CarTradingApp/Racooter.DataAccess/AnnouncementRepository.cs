using LogicModel;
using Microsoft.EntityFrameworkCore;
using Racooter.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Racooter.DataAccess
{
    public class AnnouncementRepository : BaseRepository<Announcement>, IAnnouncementRepository
    {
        public AnnouncementRepository(RacooterCarTradingDbContext dbContext) : base(dbContext)
        {
        }

        public Announcement GetAnnouncementById(Guid announcementId)
        {
            return dbContext.Announcements.Include(a => a.Description)
                                          .Include(a => a.Specification)
                                          .Where(a => a.Id == announcementId)
                                          .FirstOrDefault();
        }

        public IEnumerable<Announcement> GetAnnouncementsAccordingToFilters(string title, string category, decimal lowPrice, decimal highPrice, DateTime lowDate, DateTime highDate)
        {
            var announcements = dbContext.Announcements.Where(a => a.Title == title && a.Category == category && 
                                                                   (a.Price >= lowPrice && a.Price <= highPrice) && 
                                                                   (a.Date >= lowDate && a.Date <= highDate))
                                                       .AsEnumerable();
            return announcements;
        }

        public IEnumerable<Announcement> GetAnnouncementsBySpecification(Specification specification)
        {
            var announcements = dbContext.Announcements.Where(a => a.Specification.Equals(specification)).AsEnumerable();
            return announcements;
        }
    }
}
