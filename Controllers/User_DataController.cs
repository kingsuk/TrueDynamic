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
    public class User_DataController : Controller
    {
        private TrueDynamicDBEntities db = new TrueDynamicDBEntities();

        // GET: User_Data
        public async Task<ActionResult> Index()
        {
            return View(await db.User_Data.ToListAsync());
        }

        // GET: User_Data/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            User_Data user_Data = await db.User_Data.FindAsync(id);
            if (user_Data == null)
            {
                return HttpNotFound();
            }
            return View(user_Data);
        }

        // GET: User_Data/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: User_Data/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "UserDataId,Name,UserEmail,PhoneNo,ShiftTiming,ManagerName,ManagerEmail,Tower")] User_Data user_Data)
        {
            if (ModelState.IsValid)
            {
                db.User_Data.Add(user_Data);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(user_Data);
        }

        // GET: User_Data/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            User_Data user_Data = await db.User_Data.FindAsync(id);
            if (user_Data == null)
            {
                return HttpNotFound();
            }
            return View(user_Data);
        }

        // POST: User_Data/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "UserDataId,Name,UserEmail,PhoneNo,ShiftTiming,ManagerName,ManagerEmail,Tower")] User_Data user_Data)
        {
            if (ModelState.IsValid)
            {
                db.Entry(user_Data).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(user_Data);
        }

        // GET: User_Data/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            User_Data user_Data = await db.User_Data.FindAsync(id);
            if (user_Data == null)
            {
                return HttpNotFound();
            }
            return View(user_Data);
        }

        // POST: User_Data/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            User_Data user_Data = await db.User_Data.FindAsync(id);
            db.User_Data.Remove(user_Data);
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
