using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using TheProfessionalStalker.Models;


namespace TheProfessionalStalker.Controllers
{
    public class FotoController : Controller
    {
        private TheProfessionalStalkerEntities db = new TheProfessionalStalkerEntities();

		// GET: Foto
		[Authorize]
		public ActionResult Index()
        {
            return View(db.foto.ToList());
        }

		//public ActionResult FileUpload(HttpPostedFileBase file)
		//{
		//	if (file != null)
		//	{
		//		string pic = System.IO.Path.GetFileName(file.FileName);
		//		string path = System.IO.Path.Combine(
		//							   Server.MapPath("~/images/profile"), pic);
		//		// file is uploaded
		//		file.SaveAs(path);

		//		// save the image path path to the database or you can send image 
		//		// directly to database
		//		// in-case if you want to store byte[] ie. for DB
		//		using (MemoryStream ms = new MemoryStream())
		//		{
		//			file.InputStream.CopyTo(ms);
		//			byte[] array = ms.GetBuffer();
		//		}

		//	}
		//	// after successfully uploading redirect the user
		//	return RedirectToAction("actionname", "controller name");
		//}

		// GET: Foto/Details/5
		[Authorize]
		public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            foto foto = db.foto.Find(id);
            if (foto == null)
            {
                return HttpNotFound();
            }
            return View(foto);
        }

		// GET: Foto/Create
		[Authorize]
		public ActionResult Create()
        {
            return View();
        }

        // POST: Foto/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
		[Authorize]
		public ActionResult Create([Bind(Include = "coordinaten,foto1,datum")] foto foto)
        {
            if (ModelState.IsValid)
            {
                db.foto.Add(foto);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(foto);
        }

		// GET: Foto/Edit/5
		[Authorize]
		public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            foto foto = db.foto.Find(id);
            if (foto == null)
            {
                return HttpNotFound();
            }
            return View(foto);
        }

        // POST: Foto/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
		[Authorize]
		public ActionResult Edit([Bind(Include = "coordinaten,foto1,datum")] foto foto)
        {
            if (ModelState.IsValid)
            {
                db.Entry(foto).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(foto);
        }

		// GET: Foto/Delete/5
		[Authorize]
		public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            foto foto = db.foto.Find(id);
            if (foto == null)
            {
                return HttpNotFound();
            }
            return View(foto);
        }

		// POST: Foto/Delete/5
		[Authorize]
		[HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            foto foto = db.foto.Find(id);
            db.foto.Remove(foto);
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
