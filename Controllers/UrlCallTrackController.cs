using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using TrueDynamicWeb.Models;

namespace TrueDynamicWeb.Controllers
{
    public class UrlCallTrackController : Controller
    {
        private TrueDynamicDBEntities db = new TrueDynamicDBEntities();

        // GET: UrlCallTrack
        public async Task<ActionResult> Index()
        {
            return View(await db.Url_call_track.ToListAsync());
        }

        // GET: UrlCallTrack/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Url_call_track url_call_track = await db.Url_call_track.FindAsync(id);
            if (url_call_track == null)
            {
                return HttpNotFound();
            }
            return View(url_call_track);
        }

        // GET: UrlCallTrack/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: UrlCallTrack/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "ID,url_config_fk,response_data,Status,CreateDate,UpdateDate")] Url_call_track url_call_track)
        {
            if (ModelState.IsValid)
            {
                db.Url_call_track.Add(url_call_track);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(url_call_track);
        }

        // GET: UrlCallTrack/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Url_call_track url_call_track = await db.Url_call_track.FindAsync(id);
            if (url_call_track == null)
            {
                return HttpNotFound();
            }
            return View(url_call_track);
        }

        // POST: UrlCallTrack/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "ID,url_config_fk,response_data,Status,CreateDate,UpdateDate")] Url_call_track url_call_track)
        {
            if (ModelState.IsValid)
            {
                db.Entry(url_call_track).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(url_call_track);
        }

        // GET: UrlCallTrack/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Url_call_track url_call_track = await db.Url_call_track.FindAsync(id);
            if (url_call_track == null)
            {
                return HttpNotFound();
            }
            return View(url_call_track);
        }

        // POST: UrlCallTrack/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Url_call_track url_call_track = await db.Url_call_track.FindAsync(id);
            db.Url_call_track.Remove(url_call_track);
            await db.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
