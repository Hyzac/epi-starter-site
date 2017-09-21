using EPiServer.DataAnnotations;

namespace EPiStarterSite.Features.Shared.Models
{
    public class SiteContentType : ContentTypeAttribute
    {
        public SiteContentType()
        {
            GroupName = Global.GroupNames.Default;
        }
    }
}