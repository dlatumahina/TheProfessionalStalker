using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using TheProfessionalStalker.Models;

namespace TheProfessionalStalker.Controllers
{
    public class ObjectenController : Controller
    {
        private TheProfessionalStalkerEntities db = new TheProfessionalStalkerEntities();

		// GET: Objecten
		[Authorize]
		public ActionResult Index()
        {
            return View(db.objecten.ToList());
        }

		// GET: Objecten/Details/5
		[Authorize]
		public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            objecten objecten = db.objecten.Find(id);
            if (objecten == null)
            {
                return HttpNotFound();
            }
            return View(objecten);
        }

		// GET: Objecten/Create
		[Authorize]
		public ActionResult Create()
        {
            return View();
        }

        // POST: Objecten/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
		[Authorize]
		public ActionResult Create([Bind(Include = "naam,datum,plaats,postcode,beschrijving,persoon")] objecten objecten)
        {
            if (ModelState.IsValid)
            {
                db.objecten.Add(objecten);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(objecten);
        }

		// GET: Objecten/Edit/5
		[Authorize]
		public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            objecten objecten = db.objecten.Find(id);
            if (objecten == null)
            {
                return HttpNotFound();
            }
            return View(objecten);
        }

        // POST: Objecten/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
		[Authorize]
		public ActionResult Edit([Bind(Include = "naam,datum,plaats,postcode,beschrijving,persoon")] objecten objecten)
        {
            if (ModelState.IsValid)
            {
                db.Entry(objecten).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(objecten);
        }

		// GET: Objecten/Delete/5
		[Authorize]
		public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            objecten objecten = db.objecten.Find(id);
            if (objecten == null)
            {
                return HttpNotFound();
            }
            return View(objecten);
        }

		// POST: Objecten/Delete/5
		[Authorize]
		[HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            objecten objecten = db.objecten.Find(id);
            db.objecten.Remove(objecten);
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
