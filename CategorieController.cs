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
    public class CategorieController : Controller
    {
        private TheProfessionalStalkerEntities db = new TheProfessionalStalkerEntities();

		// GET: Categorie
		[Authorize]
		public ActionResult Index()
        {
            return View(db.categorieen.ToList());
        }

		// GET: Categorie/Details/5
		[Authorize]
		public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            categorieen categorieen = db.categorieen.Find(id);
            if (categorieen == null)
            {
                return HttpNotFound();
            }
            return View(categorieen);
        }

		// GET: Categorie/Create
		[Authorize]
		public ActionResult Create()
        {
            return View();
        }

        // POST: Categorie/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
		[Authorize]
		public ActionResult Create([Bind(Include = "id,naam,beschrijving")] categorieen categorieen)
        {
            if (ModelState.IsValid)
            {
                db.categorieen.Add(categorieen);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(categorieen);
        }

		// GET: Categorie/Edit/5
		[Authorize]
		public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            categorieen categorieen = db.categorieen.Find(id);
            if (categorieen == null)
            {
                return HttpNotFound();
            }
            return View(categorieen);
        }

        // POST: Categorie/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
		[Authorize]
		public ActionResult Edit([Bind(Include = "id,naam,beschrijving")] categorieen categorieen)
        {
            if (ModelState.IsValid)
            {
                db.Entry(categorieen).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(categorieen);
        }

		// GET: Categorie/Delete/5
		[Authorize]
		public ActionResult Delete(int? id)

        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            categorieen categorieen = db.categorieen.Find(id);
            if (categorieen == null)
            {
                return HttpNotFound();
            }
            return View(categorieen);
        }

		// POST: Categorie/Delete/5
		[Authorize]
		[HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            categorieen categorieen = db.categorieen.Find(id);
            db.categorieen.Remove(categorieen);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

		[Authorize]
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
