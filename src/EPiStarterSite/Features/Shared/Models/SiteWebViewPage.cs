using System.Web.Mvc;
using EPiServer.ServiceLocation;
using EPiServer.Web.Routing;

namespace EPiStarterSite.Features.Shared.Models
{

    public class SiteWebViewPage : WebViewPage
    {
        public override void Execute() { }
    }

    public abstract class SiteWebViewPage<T> : WebViewPage<T>
    {
        public Injected<LayoutModel> LayoutModel { get; set; }

        public LayoutModel PageLayout => LayoutModel.Service;

        public SitePageData CurrentPage => (SitePageData)ServiceLocator.Current.GetInstance<IPageRouteHelper>().Page;

        public override void Execute() { }
    }

}