using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BIPIT_10.Controllers
{
    public class ServiceController : Controller
    {
        bipitpjEntities db = new bipitpjEntities();
        // GET: Service
        public ActionResult Index()
        {
            var services = db.Services.ToList();

            return View("Services", services);
        }
        [Authorize]
        public ActionResult Create()
        {
            return View("Create");
        }
        [Authorize]
        public ActionResult Add(Services service)
        {
            db.Services.Add(service);
            db.SaveChanges();

            var services = db.Services.ToList();
            return View("Services", services);
        }
        [Authorize]
        public ActionResult Update(int id)
        {
            var service = db.Services.Find(id);

            return View("Update", service);
        }
        [Authorize]
        public ActionResult Edit(Services service)
        {
            var oldService = db.Services.Find(service.service_id);
            oldService.service_title = service.service_title;
            oldService.service_cost = service.service_cost;
            db.SaveChanges();

            var services = db.Services.ToList();
            return View("Services", services);
        }
        [Authorize]
        public ActionResult Delete(int id)
        {
            var service = db.Services.Find(id);
            if (service != null)
                db.Services.Remove(service);
            db.SaveChanges();

            var services = db.Services.ToList();
            return View("Services", services);

        }
    }
}