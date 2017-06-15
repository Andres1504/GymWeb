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
    public class membresiasController : Controller
    {
        private gymEntities db = new gymEntities();

        // GET: membresias
        public ActionResult Index()
        {
            var membresia = db.membresia.Include(m => m.meses).Include(m => m.precios).Include(m => m.usuario);
            return View(membresia.ToList());
        }

        // GET: membresias/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            membresia membresia = db.membresia.Find(id);
            if (membresia == null)
            {
                return HttpNotFound();
            }
            return View(membresia);
        }

        // GET: membresias/Create
        public ActionResult Create()
        {
            ViewBag.id_mes = new SelectList(db.meses, "id_mes", "nombre_mes");
            ViewBag.id_precio = new SelectList(db.precios, "id_precio", "id_precio");
            ViewBag.id_usu = new SelectList(db.usuario, "id_usuario", "nombre_usu");
            return View();
        }

        // POST: membresias/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id_mem,fecha_pago,estatus_mem,fecha_fin_mem,id_usu,id_mes,id_precio")] membresia membresia)
        {
            if (ModelState.IsValid)
            {
                db.membresia.Add(membresia);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.id_mes = new SelectList(db.meses, "id_mes", "nombre_mes", membresia.id_mes);
            ViewBag.id_precio = new SelectList(db.precios, "id_precio", "id_precio", membresia.id_precio);
            ViewBag.id_usu = new SelectList(db.usuario, "id_usuario", "nombre_usu", membresia.id_usu);
            return View(membresia);
        }

        // GET: membresias/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            membresia membresia = db.membresia.Find(id);
            if (membresia == null)
            {
                return HttpNotFound();
            }
            ViewBag.id_mes = new SelectList(db.meses, "id_mes", "nombre_mes", membresia.id_mes);
            ViewBag.id_precio = new SelectList(db.precios, "id_precio", "id_precio", membresia.id_precio);
            ViewBag.id_usu = new SelectList(db.usuario, "id_usuario", "nombre_usu", membresia.id_usu);
            return View(membresia);
        }

        // POST: membresias/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id_mem,fecha_pago,estatus_mem,fecha_fin_mem,id_usu,id_mes,id_precio")] membresia membresia)
        {
            if (ModelState.IsValid)
            {
                db.Entry(membresia).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.id_mes = new SelectList(db.meses, "id_mes", "nombre_mes", membresia.id_mes);
            ViewBag.id_precio = new SelectList(db.precios, "id_precio", "id_precio", membresia.id_precio);
            ViewBag.id_usu = new SelectList(db.usuario, "id_usuario", "nombre_usu", membresia.id_usu);
            return View(membresia);
        }

        // GET: membresias/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            membresia membresia = db.membresia.Find(id);
            if (membresia == null)
            {
                return HttpNotFound();
            }
            return View(membresia);
        }

        // POST: membresias/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            membresia membresia = db.membresia.Find(id);
            db.membresia.Remove(membresia);
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
