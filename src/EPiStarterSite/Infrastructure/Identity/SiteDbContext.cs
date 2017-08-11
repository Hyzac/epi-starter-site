using Microsoft.AspNet.Identity.EntityFramework;

namespace EPiStarterSite.Infrastructure.Identity
{
    public class SiteDbContext : IdentityDbContext<SiteUser>
    {
        public SiteDbContext() : base("EPiServerDB", throwIfV1Schema: false)
        {
        }

        public static SiteDbContext Create()
        {
            return new SiteDbContext();
        }
    }
}