using System.ComponentModel.DataAnnotations;
using EPiServer.DataAnnotations;

namespace EPiStarterSite
{
    public class Global
    {
        public static readonly string LoginPath = "/util/login.aspx";

        [GroupDefinitions()]
        public static class GroupNames
        {
            [Display(Name = "Default", Order = 2)]
            public const string Default = "Default";

            [Display(Name = "Metadata", Order = 3)]
            public const string MetaData = "Metadata";

            [Display(Name = "SiteSettings", Order = 6)]
            public const string SiteSettings = "SiteSettings";

        }
    }
}