using System;
using EPiServer;
using EPiServer.Core;
using EPiServer.DataAbstraction;
using EPiServer.Framework;
using EPiServer.Framework.Initialization;
using EPiServer.ServiceLocation;
using EPiStarterSite.Infrastructure.Attributes;

namespace EPiStarterSite.Infrastructure.Initialization
{
    [InitializableModule]
    [ModuleDependency(typeof(EPiServer.Web.InitializationModule))]
    public class SingletonTypeInitializationModule : IInitializableModule
    {
        public void Initialize(InitializationEngine context)
        {
            ServiceLocator.Current.GetInstance<IContentEvents>().CreatedContent += Instance_CreatedContent;
            ServiceLocator.Current.GetInstance<IContentEvents>().DeletedContent += Instance_DeletedContent;
        }

        private static void Instance_DeletedContent(object sender, DeleteContentEventArgs e)
        {
            var contentRepository = ServiceLocator.Current.GetInstance<IContentRepository>();
            var contentTyperepository = ServiceLocator.Current.GetInstance<IContentTypeRepository>();

            foreach (var cr in e.DeletedDescendents)
            {
                var content = contentRepository.Get<IContent>(cr);

                if (content == null) continue;
                var contentType = contentTyperepository.Load(content.ContentTypeID);

                var attributes = Attribute.GetCustomAttributes(contentType.ModelType);
                foreach (var attr in attributes)
                {
                    if (!(attr is SingletonAttribute)) continue;
                    var writableContentType = (ContentType)contentType.CreateWritableClone();
                    writableContentType.IsAvailable = true;
                    contentTyperepository.Save(writableContentType);
                }
            }
        }

        private static void Instance_CreatedContent(object sender, ContentEventArgs e)
        {
            var repository = ServiceLocator.Current.GetInstance<IContentTypeRepository>();

            if (repository == null) return;
            var contentType = repository.Load(e.Content.ContentTypeID);

            var attributes = Attribute.GetCustomAttributes(contentType.ModelType);

            foreach (var attr in attributes)
            {
                if (!(attr is SingletonAttribute)) continue;
                var writableContentType = (ContentType)contentType.CreateWritableClone();
                writableContentType.IsAvailable = false;
                repository.Save(writableContentType);
            }
        }

        public void Uninitialize(InitializationEngine context)
        {
            ServiceLocator.Current.GetInstance<IContentEvents>().CreatedContent -= Instance_CreatedContent;
            ServiceLocator.Current.GetInstance<IContentEvents>().DeletedContent -= Instance_DeletedContent;
        }
    }
}