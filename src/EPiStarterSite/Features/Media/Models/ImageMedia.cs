using EPiServer.Core;
using EPiServer.DataAnnotations;
using EPiServer.Framework.DataAnnotations;

namespace EPiStarterSite.Features.Media.Models
{
    [ContentType(GUID = "6302568c-af4e-4c30-ab20-d0fde6343b2c")]
    [MediaDescriptor(ExtensionString = "jpg,jpeg,jpe,ico,gif,bmp,png")]
    public class ImageMedia : ImageData
    {
        public virtual string AltTag { get; set; }

    }
}