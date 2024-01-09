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
using ClientDetails.Data;

namespace ClientDetails.Controllers
{
    public class tblCDetailsController : ApiController
    {
        private ClientDetailsEntities db = new ClientDetailsEntities();

        // GET: api/tblCDetails
        public IQueryable<tblCDetail> GettblCDetails()
        {
            return db.tblCDetails;
        }

        // GET: api/tblCDetails/5
        [ResponseType(typeof(tblCDetail))]
        public IHttpActionResult GettblCDetail(int id)
        {
            tblCDetail tblCDetail = db.tblCDetails.Find(id);
            if (tblCDetail == null)
            {
                return NotFound();
            }

            return Ok(tblCDetail);
        }

        // PUT: api/tblCDetails/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PuttblCDetail(int id, tblCDetail tblCDetail)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != tblCDetail.Id)
            {
                return BadRequest();
            }

            db.Entry(tblCDetail).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!tblCDetailExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.OK);
        }

        // POST: api/tblCDetails
        [ResponseType(typeof(tblCDetail))]
        public IHttpActionResult PosttblCDetail(tblCDetail tblCDetail)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.tblCDetails.Add(tblCDetail);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = tblCDetail.Id }, tblCDetail);
        }

        // DELETE: api/tblCDetails/5
        [ResponseType(typeof(tblCDetail))]
        public IHttpActionResult DeletetblCDetail(int id)
        {
            tblCDetail tblCDetail = db.tblCDetails.Find(id);
            if (tblCDetail == null)
            {
                return NotFound();
            }

            db.tblCDetails.Remove(tblCDetail);
            db.SaveChanges();

            return Ok(tblCDetail);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool tblCDetailExists(int id)
        {
            return db.tblCDetails.Count(e => e.Id == id) > 0;
        }
    }
}