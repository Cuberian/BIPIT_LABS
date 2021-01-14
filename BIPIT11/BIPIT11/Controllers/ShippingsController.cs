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
using BIPIT11;

namespace BIPIT11.Controllers
{
    public class ShippingsController : ApiController
    {
        private bipitpjEntities db = new bipitpjEntities();

        // GET: api/Shippings
        public IQueryable<View_3> GetShippings()
        {
            return db.View_3;
        }

        // GET: api/Shippings/5
        [ResponseType(typeof(Shippings))]
        public IHttpActionResult GetShippings(int id)
        {
            Shippings shippings = db.Shippings.Find(id);
            if (shippings == null)
            {
                return NotFound();
            }

            return Ok(shippings);
        }

        // PUT: api/Shippings/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutShippings(int id, Shippings shippings)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != shippings.shipping_id)
            {
                return BadRequest();
            }

            db.Entry(shippings).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ShippingsExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/Shippings
        [ResponseType(typeof(Shippings))]
        public IHttpActionResult PostShippings(Shippings shippings)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Shippings.Add(shippings);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = shippings.shipping_id }, shippings);
        }

        // DELETE: api/Shippings/5
        [ResponseType(typeof(Shippings))]
        public IHttpActionResult DeleteShippings(int id)
        {
            Shippings shippings = db.Shippings.Find(id);
            if (shippings == null)
            {
                return NotFound();
            }

            db.Shippings.Remove(shippings);
            db.SaveChanges();

            return Ok(shippings);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ShippingsExists(int id)
        {
            return db.Shippings.Count(e => e.shipping_id == id) > 0;
        }
    }
}