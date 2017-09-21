using EPiServer.DataAnnotations;

namespace EPiStarterSite.Features.Shared.Models
{
    public class SiteImageUrl : ImageUrlAttribute
    {
        public SiteImageUrl() : base("~/Static/gfx/page-template.png")
        {
        }

        public SiteImageUrl(string path) : base(path)
        {
        }
    }
}