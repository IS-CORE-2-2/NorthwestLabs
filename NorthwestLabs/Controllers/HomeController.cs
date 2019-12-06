/*
 *  HOME CONTROLLER, CONTROLS ALL ROUTES FOR HOME PAGES
 *  LAST EDITED 12/3/2019
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NorthwestLabs.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            return View();
        }

        public ActionResult Contact()
        {
            return View();
        }

        public ActionResult ViewPricing()
        {
            return View();////HERE
        }
    }
}