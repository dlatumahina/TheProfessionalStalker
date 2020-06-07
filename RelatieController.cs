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
    public class RelatieController : Controller
    {
        private TheProfessionalStalkerEntities db = new TheProfessionalStalkerEntities();

		// GET: Relatie
		[Authorize]
		public ActionResult Index()
        {
            return View(db.relatie.ToList());
        }

		// GET: Relatie/Details/5
		[Authorize]
		public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            relatie relatie = db.relatie.Find(id);
            if (relatie == null)
            {
                return HttpNotFound();
            }
            return View(relatie);
        }

		// GET: Relatie/Create
		[Authorize]
		public ActionResult Create()
        {
            return View();
        }

        // POST: Relatie/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
		[Authorize]
		public ActionResult Create([Bind(Include = "relatie1")] relatie relatie)
        {
            if (ModelState.IsValid)
            {
                db.relatie.Add(relatie);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(relatie);
        }

		// GET: Relatie/Edit/5
		[Authorize]
		public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            relatie relatie = db.relatie.Find(id);
            if (relatie == null)
            {
                return HttpNotFound();
            }
            return View(relatie);
        }

        // POST: Relatie/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
		[Authorize]
		public ActionResult Edit([Bind(Include = "relatie1")] relatie relatie)
        {
            if (ModelState.IsValid)
            {
                db.Entry(relatie).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(relatie);
        }

		// GET: Relatie/Delete/5
		[Authorize]
		public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            relatie relatie = db.relatie.Find(id);
            if (relatie == null)
            {
                return HttpNotFound();
            }
            return View(relatie);
        }

		// POST: Relatie/Delete/5
		[Authorize]
		[HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            relatie relatie = db.relatie.Find(id);
            db.relatie.Remove(relatie);
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
