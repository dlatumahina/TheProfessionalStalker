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
    public class PersoonController : Controller
    {
        private TheProfessionalStalkerEntities db = new TheProfessionalStalkerEntities();

		// GET: Persoon
		[Authorize]
		public ActionResult Index(string search, int? i)
        {
            var persoon = db.persoon.Include(p => p.relatie1);
            return View(persoon.ToList());
        }

		// GET: Persoon/Details/5
		[Authorize]
		public ActionResult Details(long id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
			persoon persoon = db.persoon.SingleOrDefault(m => m.id == id);
			if (persoon == null)
            {
                return HttpNotFound();
            }
            return View(persoon);
        }

		// GET: Persoon/Create
		[Authorize]
		public ActionResult Create()
        {
            ViewBag.relatie = new SelectList(db.relatie, "relatie1", "relatie1");
            return View();
        }

        // POST: Persoon/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
		[Authorize]
		public ActionResult Create([Bind(Include = "id,voornaam,achternaam,tussenvoegsel,geslacht,plaats,straat,huisnummer,postcode,land,startdatum,einddatum,relatie")] persoon persoon)
        {
            if (ModelState.IsValid)
            {
                db.persoon.Add(persoon);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.relatie = new SelectList(db.relatie, "relatie1", "relatie1", persoon.relatie);
            return View(persoon);
        }

		// GET: Persoon/Edit/5
		[Authorize]
		public ActionResult Edit(long id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            persoon persoon = db.persoon.SingleOrDefault(m => m.id == id);
			if (persoon == null)
            {
                return HttpNotFound();
            }
            ViewBag.relatie = new SelectList(db.relatie, "relatie1", "relatie1", persoon.relatie);
            return View(persoon);
        }

        // POST: Persoon/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
		[Authorize]
		public ActionResult Edit([Bind(Include = "id,voornaam,achternaam,tussenvoegsel,geslacht,plaats,straat,huisnummer,postcode,land,startdatum,einddatum,relatie")] persoon persoon)
        {
            if (ModelState.IsValid)
            {
                db.Entry(persoon).State = EntityState.Modified;
                 db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.relatie = new SelectList(db.relatie, "relatie1", "relatie1", persoon.relatie);
            return View(persoon);
        }

		// GET: Persoon/Delete/5
		[Authorize]
		public ActionResult Delete(long id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
			persoon persoon = db.persoon.SingleOrDefault(m => m.id == id);
			if (persoon == null)
            {
                return HttpNotFound();
            }
            return View(persoon);
        }

		// POST: Persoon/Delete/5
		[Authorize]
		[HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(long id)
        {
			persoon persoon = db.persoon.SingleOrDefault(m => m.id == id);
			db.persoon.Remove(persoon);
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
