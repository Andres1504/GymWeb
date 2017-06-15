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
    public class tipo_pagoController : Controller
    {
        private gymEntities db = new gymEntities();

        // GET: tipo_pago
        public ActionResult Index()
        {
            return View(db.tipo_pago.ToList());
        }

        // GET: tipo_pago/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tipo_pago tipo_pago = db.tipo_pago.Find(id);
            if (tipo_pago == null)
            {
                return HttpNotFound();
            }
            return View(tipo_pago);
        }

        // GET: tipo_pago/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: tipo_pago/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id_tipo_pag,tipo_pag")] tipo_pago tipo_pago)
        {
            if (ModelState.IsValid)
            {
                db.tipo_pago.Add(tipo_pago);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tipo_pago);
        }

        // GET: tipo_pago/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tipo_pago tipo_pago = db.tipo_pago.Find(id);
            if (tipo_pago == null)
            {
                return HttpNotFound();
            }
            return View(tipo_pago);
        }

        // POST: tipo_pago/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id_tipo_pag,tipo_pag")] tipo_pago tipo_pago)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tipo_pago).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tipo_pago);
        }

        // GET: tipo_pago/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tipo_pago tipo_pago = db.tipo_pago.Find(id);
            if (tipo_pago == null)
            {
                return HttpNotFound();
            }
            return View(tipo_pago);
        }

        // POST: tipo_pago/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tipo_pago tipo_pago = db.tipo_pago.Find(id);
            db.tipo_pago.Remove(tipo_pago);
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
