using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using GymPrimerParcialWeb;

namespace GymPrimerParcialWeb.Controllers
{
    public class mesesController : Controller
    {
        private gymEntities db = new gymEntities();

        // GET: meses
        public ActionResult Index()
        {
            return View(db.meses.ToList());
        }

        // GET: meses/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            meses meses = db.meses.Find(id);
            if (meses == null)
            {
                return HttpNotFound();
            }
            return View(meses);
        }

        // GET: meses/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: meses/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id_mes,nombre_mes,dias_mes")] meses meses)
        {
            if (ModelState.IsValid)
            {
                db.meses.Add(meses);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(meses);
        }

        // GET: meses/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            meses meses = db.meses.Find(id);
            if (meses == null)
            {
                return HttpNotFound();
            }
            return View(meses);
        }

        // POST: meses/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id_mes,nombre_mes,dias_mes")] meses meses)
        {
            if (ModelState.IsValid)
            {
                db.Entry(meses).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(meses);
        }

        // GET: meses/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            meses meses = db.meses.Find(id);
            if (meses == null)
            {
                return HttpNotFound();
            }
            return View(meses);
        }

        // POST: meses/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            meses meses = db.meses.Find(id);
            db.meses.Remove(meses);
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
