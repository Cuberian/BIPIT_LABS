using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BIPIT09.Models;

namespace BIPIT09.Controllers
{
    public class TableController : Controller
    {
        bipitpjEntities db = new bipitpjEntities();
        // GET: Table
        public ActionResult Index()
        {
            return View();
        }

        public PartialViewResult ShippingsPartial()
        {
            var shoppingsViews = db.View_3.ToList();

            return PartialView(shoppingsViews);
        }

        public PartialViewResult ClientsPartial()
        {
            var clientsViews = db.Clients.ToList();

            return PartialView(clientsViews);
        }

        public PartialViewResult ServicesPartial()
        {
            var servicesViews = db.Services.ToList();

            return PartialView(servicesViews);
        }
    }
}