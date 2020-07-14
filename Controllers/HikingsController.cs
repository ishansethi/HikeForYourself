using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using hikeforyourselfver3.Models;

namespace hikeforyourselfver3.Controllers
{
    public class HikingsController : Controller
    {
        private Entities db = new Entities();

        // GET: Hikings
        public ActionResult Index()
        {
            return View(db.Hikings.ToList());
        }

        // GET: Hikings/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Hiking hiking = db.Hikings.Find(id);
            if (hiking == null)
            {
                return HttpNotFound();
            }
            return View(hiking);
        }

        // GET: Hikings/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Hikings/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,HikeName,HikeLoc,HikeDesc,HikePrice,HikeDate")] Hiking hiking)
        {
            if (ModelState.IsValid)
            {
                db.Hikings.Add(hiking);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(hiking);
        }

        // GET: Hikings/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Hiking hiking = db.Hikings.Find(id);
            if (hiking == null)
            {
                return HttpNotFound();
            }
            return View(hiking);
        }

        // POST: Hikings/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,HikeName,HikeLoc,HikeDesc,HikePrice,HikeDate")] Hiking hiking)
        {
            if (ModelState.IsValid)
            {
                db.Entry(hiking).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(hiking);
        }

        // GET: Hikings/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Hiking hiking = db.Hikings.Find(id);
            if (hiking == null)
            {
                return HttpNotFound();
            }
            return View(hiking);
        }

        // POST: Hikings/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Hiking hiking = db.Hikings.Find(id);
            db.Hikings.Remove(hiking);
            db.SaveChanges();
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
