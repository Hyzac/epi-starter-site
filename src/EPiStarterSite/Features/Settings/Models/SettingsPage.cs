using EPiServer.Core;
using EPiServer.DataAnnotations;
using EPiStarterSite.Infrastructure.Attributes;

namespace EPiStarterSite.Features.Settings.Models
{
    [ContentType(DisplayName = "SettingsPage", GUID = "d68e085c-fd3a-44c3-a2cf-71990a377edd", Description = "")]
    [Singleton]
    public class SettingsPage : PageData
    {

    }
}