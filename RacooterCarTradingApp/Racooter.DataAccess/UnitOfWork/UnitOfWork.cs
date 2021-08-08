using Microsoft.AspNetCore.Identity;
using Racooter.DataAccess.DbContext;
using Racooter.DataAccess.Models;
using Racooter.DataAccess.Repositories;
using Racooter.DataAccess.Repository;
using System;
using System.Collections.Generic;
using System.Text;

namespace Racooter.DataAccess.UnitOfWork
{
    public class UnitOfWork: IUnitOfWork
    {
        private RacooterDbContext _context;
        private Repository<IdentityUser> _Users;
        private AnnouncementRepository _Announcements;
        public UnitOfWork(RacooterDbContext context)
        {
            _context = context;
        }

        public IRepository<IdentityUser> Users
        {
            get
            {
                return _Users ??
                    (_Users = new Repository<IdentityUser>(_context));
            }
        }

        IAnnouncementRepository IUnitOfWork.Announcements
        {
            get
            {
                return _Announcements ??
                    (_Announcements = new AnnouncementRepository(_context));
            }
        }
        public void Commit()
        {
            _context.SaveChanges();
        }
    }
}
