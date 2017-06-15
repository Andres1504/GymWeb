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
    public class tarjetasController : Controller
    {
        private gymEntities db = new gymEntities();

        // GET: tarjetas
        public ActionResult Index()
        {
            var tarjeta = db.tarjeta.Include(t => t.usuario);
            return View(tarjeta.ToList());
        }

        // GET: tarjetas/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tarjeta tarjeta = db.tarjeta.Find(id);
            if (tarjeta == null)
            {
                return HttpNotFound();
            }
            return View(tarjeta);
        }

        // GET: tarjetas/Create
        public ActionResult Create()
        {
            ViewBag.id_usu = new SelectList(db.usuario, "id_usuario", "nombre_usu");
            return View();
        }

        // POST: tarjetas/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "num_tar,titular,codigo,fecha_ven,id_usu")] tarjeta tarjeta)
        {
            if (ModelState.IsValid)
            {
                db.tarjeta.Add(tarjeta);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.id_usu = new SelectList(db.usuario, "id_usuario", "nombre_usu", tarjeta.id_usu);
            return View(tarjeta);
        }

        // GET: tarjetas/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tarjeta tarjeta = db.tarjeta.Find(id);
            if (tarjeta == null)
            {
                return HttpNotFound();
            }
            ViewBag.id_usu = new SelectList(db.usuario, "id_usuario", "nombre_usu", tarjeta.id_usu);
            return View(tarjeta);
        }

        // POST: tarjetas/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "num_tar,titular,codigo,fecha_ven,id_usu")] tarjeta tarjeta)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tarjeta).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.id_usu = new SelectList(db.usuario, "id_usuario", "nombre_usu", tarjeta.id_usu);
            return View(tarjeta);
        }

        // GET: tarjetas/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tarjeta tarjeta = db.tarjeta.Find(id);
            if (tarjeta == null)
            {
                return HttpNotFound();
            }
            return View(tarjeta);
        }

        // POST: tarjetas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            tarjeta tarjeta = db.tarjeta.Find(id);
            db.tarjeta.Remove(tarjeta);
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
