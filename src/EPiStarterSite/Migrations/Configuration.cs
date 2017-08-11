using EPiStarterSite.Infrastructure.Identity;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace EPiStarterSite.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<EPiStarterSite.Infrastructure.Identity.SiteDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(EPiStarterSite.Infrastructure.Identity.SiteDbContext context)
        {
            context.Users.AddOrUpdate(u => u.UserName,
                new SiteUser
                {
                    Id = "3f8211cb-422b-4d45-aa04-42ace1fb05c1",
                    CreationDate = DateTime.Now,
                    Email = "admin@site.se",
                    EmailConfirmed = true,
                    IsApproved = true,
                    IsLockedOut = false,
                    Username = "admin",
                    PasswordHash = "AAwsxpbbay95Ig5UUtJfqrz5QQZDWbbJShgza2BVP9sZAEaDvoC+UZ6HP1ER3b94FQ==",
                    SecurityStamp = "989acc4f-30bd-425d-9b20-7c7f85bee15b",
                    UserName = "admin",
                    TwoFactorEnabled = false,
                    LockoutEnabled = false,
                    AccessFailedCount = 0
                });

            context.Roles.AddOrUpdate(r => r.Name,
                new IdentityRole
                {
                    Name = "Administrators"
                },
                new IdentityRole
                {
                    Name = "WebAdmins"
                },
                new IdentityRole
                {
                    Name = "WebEditors"
                },
                new IdentityRole
                {
                    Name = "GoogleAnalyticsReaders"
                },
                new IdentityRole
                {
                    Name = "GoogleAnalyticsAdministrators"
                });
            context.SaveChanges();
            var userManager = new UserManager<SiteUser>(new UserStore<SiteUser>(context));
            userManager.AddToRole("3f8211cb-422b-4d45-aa04-42ace1fb05c1", "Administrators");
        }
    }
}
