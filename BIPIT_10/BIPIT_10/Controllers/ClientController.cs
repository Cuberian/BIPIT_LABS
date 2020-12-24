using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BIPIT_10.Controllers
{
    public class ClientController : Controller
    {
        bipitpjEntities db = new bipitpjEntities();
        // GET: Client
        public ActionResult Index()
        {
            var clients = db.Clients.ToList();

            return View("Clients", clients);
        }
        [Authorize]
        public ActionResult Create()
        {
            return View("Create");
        }
        [Authorize]
        public ActionResult Add(Clients client)
        {
            db.Clients.Add(client);
            db.SaveChanges();

            var clients = db.Clients.ToList();
            return View("Clients", clients);
        }
        [Authorize]
        public ActionResult Update(int id)
        {
            var client = db.Clients.Find(id);

            return View("Update", client);
        }
        [Authorize]
        public ActionResult Edit(Clients client)
        {
            var oldClient = db.Clients.Find(client.client_id);
            oldClient.client_fullname = client.client_fullname;
            oldClient.client_email = client.client_email;
            db.SaveChanges();

            var clients = db.Clients.ToList();
            return View("Clients", clients);
        }
        [Authorize]
        public ActionResult Delete(int id)
        {
            var client = db.Clients.Find(id);
            if (client != null)
                db.Clients.Remove(client);
            db.SaveChanges();

            var clients = db.Clients.ToList();
            return View("Clients", clients);

        }
    }
}