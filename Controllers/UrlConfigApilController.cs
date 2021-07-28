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
    public class UrlConfigApilController : ApiController
    {
        private TrueDynamicDBEntities db = new TrueDynamicDBEntities();

        // GET: api/UrlConfigApil
        public IQueryable<Url_config_tabl> GetUrl_config_tabl()
        {
            return db.Url_config_tabl;
        }

        // GET: api/UrlConfigApil/5
        [ResponseType(typeof(Url_config_tabl))]
        public async Task<IHttpActionResult> GetUrl_config_tabl(int id)
        {
            Url_config_tabl url_config_tabl = await db.Url_config_tabl.FindAsync(id);
            if (url_config_tabl == null)
            {
                return NotFound();
            }

            return Ok(url_config_tabl);
        }

        // PUT: api/UrlConfigApil/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutUrl_config_tabl(int id, Url_config_tabl url_config_tabl)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != url_config_tabl.ID)
            {
                return BadRequest();
            }

            db.Entry(url_config_tabl).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!Url_config_tablExists(id))
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

        // POST: api/UrlConfigApil
        [ResponseType(typeof(Url_config_tabl))]
        public async Task<IHttpActionResult> PostUrl_config_tabl(Url_config_tabl url_config_tabl)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Url_config_tabl.Add(url_config_tabl);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = url_config_tabl.ID }, url_config_tabl);
        }

        // DELETE: api/UrlConfigApil/5
        [ResponseType(typeof(Url_config_tabl))]
        public async Task<IHttpActionResult> DeleteUrl_config_tabl(int id)
        {
            Url_config_tabl url_config_tabl = await db.Url_config_tabl.FindAsync(id);
            if (url_config_tabl == null)
            {
                return NotFound();
            }

            db.Url_config_tabl.Remove(url_config_tabl);
            await db.SaveChangesAsync();

            return Ok(url_config_tabl);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool Url_config_tablExists(int id)
        {
            return db.Url_config_tabl.Count(e => e.ID == id) > 0;
        }
    }
}