using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BIPIT09.Controllers
{
    public class PagesController : Controller
    {
        // GET: Pages
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Clients()
        {
            return View("Clients");
        }

        public ActionResult Services()
        {
            return View("Services");
        }
        public ActionResult Shippings()
        {
            return View("Shippings");
        }

    }
}