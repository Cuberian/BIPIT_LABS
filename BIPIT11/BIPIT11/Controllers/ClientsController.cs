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
    public class ClientsController : ApiController
    {
        private bipitpjEntities db = new bipitpjEntities();

        // GET: api/Clients
        public IEnumerable<ClientViewModel> GetClients()
        {
            List<ClientViewModel> result = new List<ClientViewModel>();
            foreach(Clients client in db.Clients)
            {
                result.Add(new ClientViewModel(client.client_id, client.client_fullname, client.client_email));
            }    
            return result;
        }

        // GET: api/Clients/5
        [ResponseType(typeof(Clients))]
        public IHttpActionResult GetClients(int id)
        {
            Clients clients = db.Clients.Find(id);
            if (clients == null)
            {
                return NotFound();
            }

            return Ok(clients);
        }

        // PUT: api/Clients/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutClients(int id, Clients client)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Entry(client).State = EntityState.Modified;

            db.SaveChanges();

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/Clients
        [ResponseType(typeof(Clients))]
        public IHttpActionResult PostClients(Clients clients)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Clients.Add(clients);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = clients.client_id }, clients);
        }

        // DELETE: api/Clients/5
        [ResponseType(typeof(Clients))]
        public IHttpActionResult DeleteClients(int id)
        {
            Clients clients = db.Clients.Find(id);
            if (clients == null)
            {
                return NotFound();
            }

            db.Clients.Remove(clients);
            db.SaveChanges();

            return Ok(clients);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ClientsExists(int id)
        {
            return db.Clients.Count(e => e.client_id == id) > 0;
        }
    }
}