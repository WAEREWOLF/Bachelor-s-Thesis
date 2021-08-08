using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Racooter.DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Racooter.DataAccess.DbContext
{
    public class RacooterDbContext : IdentityDbContext<ApplicationUser>
    {
        public RacooterDbContext(DbContextOptions<RacooterDbContext> options) : base(options)
        {

        }

        public DbSet<Announcement> Announcements { get; set; }
        public DbSet<AnnouncementImage> AnnouncementImages { get; set; }
        public DbSet<Specification> Specifications { get; set; }
        public DbSet<History> Histories { get; set; }
        public DbSet<AnnouncementHistoryImage> AnnouncementHistoryImages { get; set; }
        public DbSet<SpecificationHistory> SpecificationHistories { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Message> Messages { get; set; }
        public DbSet<ApplicationUser> Users { get; set; }
        public DbSet<NewsPost> NewsPosts { get; set; }
        public DbSet<SearchFilter> SearchFilters { get; set; }
    }
}
