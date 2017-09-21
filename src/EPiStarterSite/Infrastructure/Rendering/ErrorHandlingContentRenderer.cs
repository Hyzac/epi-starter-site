using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EPiServer.Core;
using EPiServer.DataAbstraction;
using EPiServer.Security;
using EPiServer.Web.Mvc;
using EPiServer.XForms;
using EPiStarterSite.Features.Shared.Models;
using System.Web.Mvc.Html;

namespace EPiStarterSite.Infrastructure.Rendering
{
    public class ErrorHandlingContentRenderer : IContentRenderer
    {
        private readonly MvcContentRenderer _mvcRenderer;
        public ErrorHandlingContentRenderer(MvcContentRenderer mvcRenderer)
        {
            _mvcRenderer = mvcRenderer;
        }
        public void Render(HtmlHelper helper, PartialRequest partialRequestHandler, IContentData contentData,
            TemplateModel templateModel)
        {
            try
            {
                _mvcRenderer.Render(helper, partialRequestHandler, contentData, templateModel);
            }
            catch (NullReferenceException ex)
            {
                if (HttpContext.Current.IsDebuggingEnabled)
                {
                    //If debug="true" we assume a developer is making the request
                    throw;
                }
                HandlerError(helper, contentData, ex);
            }
            catch (ArgumentException ex)
            {
                if (HttpContext.Current.IsDebuggingEnabled)
                {
                    throw;
                }
                HandlerError(helper, contentData, ex);
            }
            catch (ApplicationException ex)
            {
                if (HttpContext.Current.IsDebuggingEnabled)
                {
                    throw;
                }
                HandlerError(helper, contentData, ex);
            }
            catch (InvalidOperationException ex)
            {
                if (HttpContext.Current.IsDebuggingEnabled)
                {
                    throw;
                }
                HandlerError(helper, contentData, ex);
            }
            catch (NotImplementedException ex)
            {
                if (HttpContext.Current.IsDebuggingEnabled)
                {
                    throw;
                }
                HandlerError(helper, contentData, ex);
            }
            catch (IOException ex)
            {
                if (HttpContext.Current.IsDebuggingEnabled)
                {
                    throw;
                }
                HandlerError(helper, contentData, ex);
            }
            catch (EPiServerException ex)
            {
                if (HttpContext.Current.IsDebuggingEnabled)
                {
                    throw;
                }
                HandlerError(helper, contentData, ex);
            }
            catch (XFormException ex)
            {
                if (HttpContext.Current.IsDebuggingEnabled)
                {
                    throw;
                }
                HandlerError(helper, contentData, ex);
            }
        }

        private void HandlerError(HtmlHelper helper, IContentData contentData, Exception renderingException)
        {
            if (PrincipalInfo.HasEditAccess)
            {
                var errorModel = new ContentRenderingErrorModel(contentData, renderingException);
                helper.RenderPartial("TemplateError", errorModel);
            }
        }
    }
}