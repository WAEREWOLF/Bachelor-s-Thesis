using Microsoft.AspNetCore.Identity;
using Racooter.DataAccess.Models;
using Racooter.DataAccess.Repositories;
using Racooter.DataAccess.Repository;
using System;
using System.Collections.Generic;
using System.Text;

namespace Racooter.DataAccess.UnitOfWork
{
    public interface IUnitOfWork
    {
        IRepository<IdentityUser> Users { get; }
        IAnnouncementRepository Announcements { get; }
        void Commit();
    }
}
