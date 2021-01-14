using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using BIPIT11.Models;

namespace BIPIT11.Controllers
{
    public class ServicesController : ApiController
    {
        private bipitpjEntities db = new bipitpjEntities();

        // GET: api/Services
        public IEnumerable<ServiceViewModel> GetServices()
        {
            List<ServiceViewModel> result = new List<ServiceViewModel>();
            foreach (Services service in db.Services)
            {
                result.Add(new ServiceViewModel(service.service_id, service.service_title, service.service_cost));
            }
            return result;
        }

        // GET: api/Services/5
        [ResponseType(typeof(Services))]
        public IHttpActionResult GetServices(int id)
        {
            Services services = db.Services.Find(id);
            if (services == null)
            {
                return NotFound();
            }

            return Ok(services);
        }

        // PUT: api/Services/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutServices(Services services)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Entry(services).State = EntityState.Modified;

            db.SaveChanges();

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/Services
        [ResponseType(typeof(Services))]
        public IHttpActionResult PostServices(Services services)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Services.Add(services);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = services.service_id }, services);
        }

        // DELETE: api/Services/5
        [ResponseType(typeof(Services))]
        public IHttpActionResult DeleteServices(int id)
        {
            Services services = db.Services.Find(id);
            if (services == null)
            {
                return NotFound();
            }

            db.Services.Remove(services);
            db.SaveChanges();

            return Ok(services);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ServicesExists(int id)
        {
            return db.Services.Count(e => e.service_id == id) > 0;
        }
    }
}