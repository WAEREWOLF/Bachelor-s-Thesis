using LogicModel;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Racooter.DataAccess
{
    public class RacooterCarTradingDbContext : DbContext
    {
        public RacooterCarTradingDbContext(DbContextOptions<RacooterCarTradingDbContext> options)
                : base(options)
        {
        }

        public DbSet<Admin> Admins { get; set; }
        public DbSet<Announcement> Announcements { get; set; }
        public DbSet<AuthenticatedUser> AuthenticatedUsers { get; set; }
        public DbSet<Comment> Comments { get; set; }        
        public DbSet<History> Histories { get; set; }
        public DbSet<HistoryItem> HistoryItems { get; set; }
        public DbSet<Location> Locations { get; set; }
        public DbSet<Message> Messages { get; set; }
        public DbSet<Moderator> Moderators { get; set; }
        public DbSet<NewsPost> NewsPosts { get; set; }
        public DbSet<PersonalData> PersonalDatas { get; set; }
        public DbSet<Specification> Specifications { get; set; }
    }
}
