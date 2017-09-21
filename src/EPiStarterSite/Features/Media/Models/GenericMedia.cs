using EPiServer.Core;
using EPiServer.DataAnnotations;

namespace EPiStarterSite.Features.Media.Models
{
    [ContentType(GUID = "6848e726-bd61-43aa-a031-7676a06d5187")]
    public class GenericMedia : MediaData
    {
        public virtual string Description { get; set; }

    }
}