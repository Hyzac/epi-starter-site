﻿using System.Web.Mvc;
using EPiStarterSite.Features.Shared.Controllers;
using EPiStarterSite.Features.Start.Models;

namespace EPiStarterSite.Features.Start.Controllers
{
    public class StartPageController : PageControllerBase<StartPage>
    {
        public ActionResult Index(StartPage currentPage)
        {
            /* Implementation of action. You can create your own view model class that you pass to the view or
             * you can pass the page type for simpler templates */

            return View(currentPage);
        }
    }
}