using System.Web.Mvc;
using EPiServer.ServiceLocation;

namespace EPiStarterSite.Features.Shared.Models
{

    public class SiteWebViewPage : WebViewPage
    {
        public Injected<LayoutModel> LayoutModel { get; set; }

        public override void Execute() { }
    }

    public abstract class SiteWebViewPage<T> : WebViewPage<T>
    {
        public Injected<LayoutModel> LayoutModel { get; set; }

        public override void Execute() { }
    }

}