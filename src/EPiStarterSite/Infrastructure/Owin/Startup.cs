using System;
using EPiServer.Cms.UI.AspNetIdentity;
using EPiStarterSite.Infrastructure.Identity;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin;
using Microsoft.Owin.Security.Cookies;
using Owin;

[assembly: OwinStartup(typeof(EPiStarterSite.Infrastructure.Owin.Startup))]

namespace EPiStarterSite.Infrastructure.Owin
{
    public class Startup
    {

        public void Configuration(IAppBuilder app)
        {
            // Add CMS integration for ASP.NET Identity             
            app.AddCmsAspNetIdentity<SiteUser>();

            // Use cookie authentication
            app.UseCookieAuthentication(new CookieAuthenticationOptions
            {
                AuthenticationType = DefaultAuthenticationTypes.ApplicationCookie,
                LoginPath = new PathString("/Util/Login.aspx"),
                Provider = new CookieAuthenticationProvider
                {
                    OnValidateIdentity = SecurityStampValidator.OnValidateIdentity<ApplicationUserManager<SiteUser>, SiteUser>(
                        validateInterval: TimeSpan.FromMinutes(30),
                        regenerateIdentity: (manager, user) => manager.GenerateUserIdentityAsync(user))
                }
            });
        }
    }
}
