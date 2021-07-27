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
    public class UrlConfigController : Controller
    {
        private TrueDynamicDBEntities db = new TrueDynamicDBEntities();

        // GET: UrlConfig
        public async Task<ActionResult> Index()
        {
            return View(await db.Url_config_tabl.ToListAsync());
        }

        // GET: UrlConfig/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Url_config_tabl url_config_tabl = await db.Url_config_tabl.FindAsync(id);
            if (url_config_tabl == null)
            {
                return HttpNotFound();
            }
            return View(url_config_tabl);
        }

        // GET: UrlConfig/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: UrlConfig/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "ID,Endpoint_name,url,url_param,interval_number,Report_Name,Status,TimeStamp,CreateDate,UpdateDate")] Url_config_tabl url_config_tabl)
        {
            if (ModelState.IsValid)
            {
                db.Url_config_tabl.Add(url_config_tabl);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(url_config_tabl);
        }

        // GET: UrlConfig/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Url_config_tabl url_config_tabl = await db.Url_config_tabl.FindAsync(id);
            if (url_config_tabl == null)
            {
                return HttpNotFound();
            }
            return View(url_config_tabl);
        }

        // POST: UrlConfig/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "ID,Endpoint_name,url,url_param,interval_number,Report_Name,Status,TimeStamp,CreateDate,UpdateDate")] Url_config_tabl url_config_tabl)
        {
            if (ModelState.IsValid)
            {
                db.Entry(url_config_tabl).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(url_config_tabl);
        }

        // GET: UrlConfig/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Url_config_tabl url_config_tabl = await db.Url_config_tabl.FindAsync(id);
            if (url_config_tabl == null)
            {
                return HttpNotFound();
            }
            return View(url_config_tabl);
        }

        // POST: UrlConfig/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Url_config_tabl url_config_tabl = await db.Url_config_tabl.FindAsync(id);
            db.Url_config_tabl.Remove(url_config_tabl);
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
