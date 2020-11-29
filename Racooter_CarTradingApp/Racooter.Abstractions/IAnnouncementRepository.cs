using LogicModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace Racooter.Abstractions
{
    public interface IAnnouncementRepository : IRepository<Announcement>
    {
        IEnumerable<Announcement> GetAnnouncementsAccordingToFilters(string title, string category, decimal lowPrice, decimal highPrice, DateTime lowDate, DateTime highDate);
        IEnumerable<Announcement> GetAnnouncementsBySpecification(Specification specification);
        Announcement GetAnnouncementById(Guid announcementId);
    }
}
