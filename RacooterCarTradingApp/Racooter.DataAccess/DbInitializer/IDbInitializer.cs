using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Racooter.DataAccess.DbContext;
using Racooter.DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Racooter.DataAccess.DbInitializer
{
    public interface IDbInitializer
    {
        void InidializeDb();
    }
    public class DbInitializer : IDbInitializer
    {
        private readonly RacooterDbContext _db;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        public DbInitializer(RacooterDbContext db, UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            _db = db;
            _roleManager = roleManager;
            _userManager = userManager;
        }
        public void InidializeDb()
        {
            try
            {
                if (_db.Database.GetPendingMigrations().Count() > 0)
                {
                    _db.Database.Migrate();
                }
            }
            catch (Exception)
            {

            }
            if (!_db.Roles.Any(r => r.Name == "Admin"))
            {
                _roleManager.CreateAsync(new IdentityRole("Admin")).GetAwaiter().GetResult();
                _roleManager.CreateAsync(new IdentityRole("Seller")).GetAwaiter().GetResult();
                _roleManager.CreateAsync(new IdentityRole("Buyer")).GetAwaiter().GetResult();
                _roleManager.CreateAsync(new IdentityRole("Moderator")).GetAwaiter().GetResult();

                //Admin
                _userManager.CreateAsync(new ApplicationUser
                {
                    UserName = "admin@admin.com",
                    Email = "admin@admin.com",
                    EmailConfirmed = true,
                    FullName="Admin",
                    IsBlockFromPost=false
                }, "Abcd@123").GetAwaiter().GetResult();

                var user = _db.Users.Where(u => u.Email == "admin@admin.com").FirstOrDefault();
                _userManager.AddToRoleAsync(user, "Admin").GetAwaiter().GetResult();

                //Seller
                _userManager.CreateAsync(new ApplicationUser
                {
                    UserName = "seller@admin.com",
                    Email = "seller@admin.com",
                    EmailConfirmed = true,
                    FullName = "Test Seller",
                    IsBlockFromPost = false
                }, "Abcd@123").GetAwaiter().GetResult();

                var seller = _db.Users.Where(u => u.Email == "seller@admin.com").FirstOrDefault();
                _userManager.AddToRoleAsync(seller, "Seller").GetAwaiter().GetResult();

                //Buyer
                _userManager.CreateAsync(new ApplicationUser
                {
                    UserName = "buyer@admin.com",
                    Email = "buyer@admin.com",
                    EmailConfirmed = true,
                    FullName = "Test Buyer",
                    IsBlockFromPost = false
                }, "Abcd@123").GetAwaiter().GetResult();

                var Buyer = _db.Users.Where(u => u.Email == "buyer@admin.com").FirstOrDefault();
                _userManager.AddToRoleAsync(Buyer, "Buyer").GetAwaiter().GetResult();

                //Moderator
                _userManager.CreateAsync(new ApplicationUser
                {
                    UserName = "moderator@admin.com",
                    Email = "moderator@admin.com",
                    EmailConfirmed = true,
                    FullName = "Moderator",
                    IsBlockFromPost = false
                }, "Abcd@123").GetAwaiter().GetResult();

                var moderator = _db.Users.Where(u => u.Email == "moderator@admin.com").FirstOrDefault();
                _userManager.AddToRoleAsync(moderator, "Moderator").GetAwaiter().GetResult();
            }
        }
    }
}
