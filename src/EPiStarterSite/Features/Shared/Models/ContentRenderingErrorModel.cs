using System;
using EPiServer;
using EPiServer.Core;

namespace EPiStarterSite.Features.Shared.Models
{
    public class ContentRenderingErrorModel
    {
        public ContentRenderingErrorModel(IContentData contentData, Exception exception)
        {
            var content = contentData as IContent;
            ContentName = content != null ? content.Name : string.Empty;

            ContentTypeName = contentData.GetOriginalType().Name;

            Exception = exception;
        }

        public string ContentName { get; set; }
        public string ContentTypeName { get; set; }
        public Exception Exception { get; set; }
    }
}