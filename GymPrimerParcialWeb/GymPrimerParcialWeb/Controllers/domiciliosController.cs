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
    public class domiciliosController : Controller
    {
        private gymEntities db = new gymEntities();

        // GET: domicilios
        public ActionResult Index()
        {
            return View(db.domicilio.ToList());
        }

        // GET: domicilios/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            domicilio domicilio = db.domicilio.Find(id);
            if (domicilio == null)
            {
                return HttpNotFound();
            }
            return View(domicilio);
        }

        // GET: domicilios/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: domicilios/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id_dom,calle_dom,num_casa_dom,colonia_dom,cp_dom")] domicilio domicilio)
        {
            if (ModelState.IsValid)
            {
                db.domicilio.Add(domicilio);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(domicilio);
        }

        // GET: domicilios/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            domicilio domicilio = db.domicilio.Find(id);
            if (domicilio == null)
            {
                return HttpNotFound();
            }
            return View(domicilio);
        }

        // POST: domicilios/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id_dom,calle_dom,num_casa_dom,colonia_dom,cp_dom")] domicilio domicilio)
        {
            if (ModelState.IsValid)
            {
                db.Entry(domicilio).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(domicilio);
        }

        // GET: domicilios/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            domicilio domicilio = db.domicilio.Find(id);
            if (domicilio == null)
            {
                return HttpNotFound();
            }
            return View(domicilio);
        }

        // POST: domicilios/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            domicilio domicilio = db.domicilio.Find(id);
            db.domicilio.Remove(domicilio);
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
