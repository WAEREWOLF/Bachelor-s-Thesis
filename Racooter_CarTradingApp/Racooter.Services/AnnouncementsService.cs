using Racooter.Abstractions; // add global reference to abstraction?
using System;
using System.Collections.Generic;
using System.Text;

namespace Racooter.Services
{
    public class AnnouncementsService
    {
        private IAnnouncementRepository announcementRepository;

        public AnnouncementsService(IAnnouncementRepository announcementRepository)
        {
            this.announcementRepository = announcementRepository;
        }
        

    }
}
