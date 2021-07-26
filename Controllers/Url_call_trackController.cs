using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using TrueDynamicWeb.Models;

namespace TrueDynamicWeb.Controllers
{
    public class Url_call_trackController : ApiController
    {
        private TrueDynamicDBEntities db = new TrueDynamicDBEntities();

        // GET: api/Url_call_track
        public IQueryable<Url_call_track> GetUrl_call_track()
        {
            return db.Url_call_track;
        }

        // GET: api/Url_call_track/5
        [ResponseType(typeof(Url_call_track))]
        public async Task<IHttpActionResult> GetUrl_call_track(int id)
        {
            Url_call_track url_call_track = await db.Url_call_track.FindAsync(id);
            if (url_call_track == null)
            {
                return NotFound();
            }

            return Ok(url_call_track);
        }

        // PUT: api/Url_call_track/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutUrl_call_track(int id, Url_call_track url_call_track)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != url_call_track.ID)
            {
                return BadRequest();
            }

            db.Entry(url_call_track).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!Url_call_trackExists(id))
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

        // POST: api/Url_call_track
        [ResponseType(typeof(Url_call_track))]
        public async Task<IHttpActionResult> PostUrl_call_track(Url_call_track url_call_track)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Url_call_track.Add(url_call_track);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = url_call_track.ID }, url_call_track);
        }

        // DELETE: api/Url_call_track/5
        [ResponseType(typeof(Url_call_track))]
        public async Task<IHttpActionResult> DeleteUrl_call_track(int id)
        {
            Url_call_track url_call_track = await db.Url_call_track.FindAsync(id);
            if (url_call_track == null)
            {
                return NotFound();
            }

            db.Url_call_track.Remove(url_call_track);
            await db.SaveChangesAsync();

            return Ok(url_call_track);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool Url_call_trackExists(int id)
        {
            return db.Url_call_track.Count(e => e.ID == id) > 0;
        }
    }
}