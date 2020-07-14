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
using Rotativa;

namespace hikeforyourselfver3.Controllers
{
    public class HikeRatingsController : Controller
    {

        private Entities db = new Entities();

        // GET: HikeRatings
        public ActionResult Index()
        {
            var userId = User.Identity.GetUserId();

            var hikeRatings = db.HikeRatings.Include(h => h.Hiking).Include(h => h.AspNetUser);
            //return View(hikeRatings.ToList());
            return View(db.HikeRatings.Where(h => h.AspNetUserId == userId).ToList());
        }

        // GET: HikeRatings/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HikeRating hikeRating = db.HikeRatings.Find(id);
            if (hikeRating == null)
            {
                return HttpNotFound();
            }
            return View(hikeRating);
        }

       

        // GET: HikeRatings/Create
        public ActionResult Create()
        {
            ViewBag.HikingId = new SelectList(db.Hikings, "Id", "HikeName");
            ViewBag.AspNetUserId = new SelectList(db.AspNetUsers, "Id", "Email");
            return View();
        }

        // POST: HikeRatings/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,HikeComment,Rating,HikingId,AspNetUserId")] HikeRating hikeRating)
        {
            hikeRating.AspNetUserId = User.Identity.GetUserId();
            ModelState.Clear();
            TryValidateModel(hikeRating);

            if (ModelState.IsValid)
            {
                db.HikeRatings.Add(hikeRating);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.HikingId = new SelectList(db.Hikings, "Id", "HikeName", hikeRating.HikingId);
            ViewBag.AspNetUserId = new SelectList(db.AspNetUsers, "Id", "Email", hikeRating.AspNetUserId);
            return View(hikeRating);
        }



       


        // GET: HikeRatings/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HikeRating hikeRating = db.HikeRatings.Find(id);
            if (hikeRating == null)
            {
                return HttpNotFound();
            }
            ViewBag.HikingId = new SelectList(db.Hikings, "Id", "HikeName", hikeRating.HikingId);
            ViewBag.AspNetUserId = new SelectList(db.AspNetUsers, "Id", "Email", hikeRating.AspNetUserId);
            return View(hikeRating);
        }

        // POST: HikeRatings/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,HikeComment,Rating,HikingId,AspNetUserId")] HikeRating hikeRating)
        {
            if (ModelState.IsValid)
            {
                db.Entry(hikeRating).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.HikingId = new SelectList(db.Hikings, "Id", "HikeName", hikeRating.HikingId);
            ViewBag.AspNetUserId = new SelectList(db.AspNetUsers, "Id", "Email", hikeRating.AspNetUserId);
            return View(hikeRating);
        }

        // GET: HikeRatings/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HikeRating hikeRating = db.HikeRatings.Find(id);
            if (hikeRating == null)
            {
                return HttpNotFound();
            }
            return View(hikeRating);
        }

        // POST: HikeRatings/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            HikeRating hikeRating = db.HikeRatings.Find(id);
            db.HikeRatings.Remove(hikeRating);
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
