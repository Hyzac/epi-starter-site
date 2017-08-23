using System.Linq;
using EPiServer;
using EPiServer.Core;
using EPiServer.ServiceLocation;
using EPiStarterSite.Features.Settings.Models;

namespace EPiStarterSite.Features.Settings
{
    public sealed class SiteSettings
    {
        private static readonly object Padlock = new object();
        private readonly IContentLoader _contentLoader;

        private SiteSettings()
        {
            _contentLoader = ServiceLocator.Current.GetInstance<IContentLoader>();
            var contentEvents = ServiceLocator.Current.GetInstance<IContentEvents>();
            contentEvents.PublishedContent += contentEvents_PublishedContent;
        }

        private void contentEvents_PublishedContent(object sender, ContentEventArgs e)
        {
            if (!(e.Content is SettingsPage)) return;
            var settingPage = _contentLoader.GetDescendents(ContentReference.RootPage).Select(_contentLoader.Get<SettingsPage>).OfType<SettingsPage>().FirstOrDefault();
            _settingsPage = settingPage;
        }

        private static SiteSettings _instance;
        public static SiteSettings Instance
        {
            get
            {
                lock (Padlock)
                {
                    return _instance ?? (_instance = new SiteSettings());
                }
            }
        }

        private static SettingsPage _settingsPage;
        public SettingsPage SettingsPage => _settingsPage ?? (_settingsPage = _contentLoader
                                                .GetDescendents(ContentReference.RootPage).Select(_contentLoader.Get<SettingsPage>).OfType<SettingsPage>().FirstOrDefault());
    }
}