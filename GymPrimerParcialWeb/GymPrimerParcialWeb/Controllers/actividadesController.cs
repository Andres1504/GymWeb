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
    public class actividadesController : Controller
    {
        private gymEntities db = new gymEntities();
        gymEntities context;

        // GET: actividades
        /* public ActionResult Index()
         {
             return View(db.actividades.ToList());
         }*/

        public ActionResult Index()
        {
            context = new gymEntities();
            return View(context.actividades.Take(10).ToList());
        }

        public ActionResult VerPrecios(string id)
        {

            int idint = Convert.ToInt32(id);
            if (idint != 0)
            {
                return PartialView(db.precios.Where(x => x.id_actividad == idint).ToList());
            }
            return PartialView(db);
        }

        // GET: actividades/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            actividades actividades = db.actividades.Find(id);
            if (actividades == null)
            {
                return HttpNotFound();
            }
            return View(actividades);
        }

        // GET: actividades/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: actividades/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id_actv,nombre_actv,precio_act")] actividades actividades)
        {
            if (ModelState.IsValid)
            {
                db.actividades.Add(actividades);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(actividades);
        }

        // GET: actividades/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            actividades actividades = db.actividades.Find(id);
            if (actividades == null)
            {
                return HttpNotFound();
            }
            return View(actividades);
        }

        // POST: actividades/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id_actv,nombre_actv,precio_act")] actividades actividades)
        {
            if (ModelState.IsValid)
            {
                db.Entry(actividades).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(actividades);
        }

        // GET: actividades/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            actividades actividades = db.actividades.Find(id);
            if (actividades == null)
            {
                return HttpNotFound();
            }
            return View(actividades);
        }

        // POST: actividades/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            actividades actividades = db.actividades.Find(id);
            db.actividades.Remove(actividades);
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

        public ActionResult Viss()
        {
            return View(db.actividades.Select(p => new { p.id_actv, p.nombre_actv, p.precio_act }).ToList());
        }

        [HttpPost]
        public ActionResult Search(string BuscarActividad)
        {
            
            var result = db.actividades.Where(x => x.nombre_actv.Contains(BuscarActividad)).Select(p => new { p.id_actv, p.nombre_actv, p.precio_act }).ToList();
            return Json(result, JsonRequestBehavior.AllowGet);

        }


    }
}
