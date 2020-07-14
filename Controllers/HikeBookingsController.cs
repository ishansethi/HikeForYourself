using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using hikeforyourselfver3.Models;
using Microsoft.AspNet.Identity;

namespace hikeforyourselfver3.Controllers
{
    [Authorize]
    public class HikeBookingsController : Controller
    {
        private Entities db = new Entities();

        // GET: HikeBookings
        public ActionResult Index()
        {
           //var userId = User.Identity.GetUserId();
            var hikeBookings = db.HikeBookings.Include(h => h.Hiking);
            return View(hikeBookings.ToList());
            //return View(db.HikeBookings.Where(h => h.AspNetUserId == userId).ToList());
        }

        // GET: HikeBookings/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HikeBooking hikeBooking = db.HikeBookings.Find(id);
            if (hikeBooking == null)
            {
                return HttpNotFound();
            }
            return View(hikeBooking);
        }

        // GET: HikeBookings/Create
        public ActionResult Create()
        {

            ViewBag.AspNetUserId = new SelectList(db.AspNetUsers, "Id", "Email");
            ViewBag.HikingId = new SelectList(db.Hikings, "Id", "HikeName");
            return View();
        }

        // POST: HikeBookings/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public ActionResult Create([Bind(Include = "Id,StartDate,EndDate,Status,AspNetUserId,HikingId")] HikeBooking hikeBooking)
        {
           hikeBooking.AspNetUserId = User.Identity.GetUserId();
            ModelState.Clear();
            TryValidateModel(hikeBooking);
            if (ModelState.IsValid)
            {
                db.HikeBookings.Add(hikeBooking);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.AspNetUserId = new SelectList(db.AspNetUsers, "Id", "Email", hikeBooking.AspNetUserId);
            ViewBag.HikingId = new SelectList(db.Hikings, "Id", "HikeName", hikeBooking.HikingId);
            return View(hikeBooking);
        }

        // GET: HikeBookings/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HikeBooking hikeBooking = db.HikeBookings.Find(id);
            if (hikeBooking == null)
            {
                return HttpNotFound();
            }
            ViewBag.AspNetUserId = new SelectList(db.AspNetUsers, "Id", "Email", hikeBooking.AspNetUserId);
            ViewBag.HikingId = new SelectList(db.Hikings, "Id", "HikeName", hikeBooking.HikingId);
            return View(hikeBooking);
        }

        // POST: HikeBookings/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,StartDate,EndDate,Status,AspNetUserId,HikingId")] HikeBooking hikeBooking)
        {
            if (ModelState.IsValid)
            {
                db.Entry(hikeBooking).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.AspNetUserId = new SelectList(db.AspNetUsers, "Id", "Email", hikeBooking.AspNetUserId);
            ViewBag.HikingId = new SelectList(db.Hikings, "Id", "HikeName", hikeBooking.HikingId);
            return View(hikeBooking);
        }

        // GET: HikeBookings/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HikeBooking hikeBooking = db.HikeBookings.Find(id);
            if (hikeBooking == null)
            {
                return HttpNotFound();
            }
            return View(hikeBooking);
        }

        // POST: HikeBookings/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            HikeBooking hikeBooking = db.HikeBookings.Find(id);
            db.HikeBookings.Remove(hikeBooking);
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
