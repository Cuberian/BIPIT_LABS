using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BIPIT_10.Controllers
{
    public class ShippingsController : Controller
    {
        bipitpjEntities db = new bipitpjEntities();
        // GET: Shippings
        public ActionResult Index()
        {
            var shippings = db.View_3.ToList();

            return View("Shippings", shippings);
        }

        [Authorize]
        public ActionResult Create()
        {
            ViewBag.Clients = db.Clients.ToList();
            ViewBag.Services = db.Services.ToList();
            return View("Create");
        }

        [Authorize]
        public ActionResult Add(Shippings shipping)
        {
            db.Shippings.Add(shipping);
            db.SaveChanges();

            var shippings = db.View_3.ToList();
            return View("Shippings", shippings);
        }

        [Authorize]
        public ActionResult Update(int id)
        {
            var shipping = db.Shippings.Find(id);

            ViewBag.Clients = db.Clients.ToList();
            ViewBag.Services = db.Services.ToList();

            return View("Update", shipping);
        }

        [Authorize]
        public ActionResult Edit(Shippings shipping)
        {
            var oldShipping = db.Shippings.Find(shipping.shipping_id);
            oldShipping.client_id = shipping.client_id;
            oldShipping.service_id = shipping.service_id;
            oldShipping.shipping_date = shipping.shipping_date;
            db.SaveChanges();

            var shippings = db.View_3.ToList();
            return View("Shippings", shippings);
        }

        [Authorize]
        public ActionResult Delete(int id)
        {
            var shipping = db.Shippings.Find(id);
            if (shipping != null)
                db.Shippings.Remove(shipping);
            db.SaveChanges();

            var shippings = db.View_3.ToList();
            return View("Shippings", shippings);

        }
    }
}