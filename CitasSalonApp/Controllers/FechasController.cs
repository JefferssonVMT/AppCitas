using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using CitasSalonApp.Models;

namespace CitasSalonApp.Controllers
{
    public class FechasController : Controller
    {
        private CitasModelContainer db = new CitasModelContainer();

        // GET: Fechas
        public ActionResult Index()
        {
            return View(db.Fechas.ToList());
        }

        // GET: Fechas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Fecha fecha = db.Fechas.Find(id);
            if (fecha == null)
            {
                return HttpNotFound();
            }
            return View(fecha);
        }

        // GET: Fechas/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Fechas/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,año,mes,dia")] Fecha fecha)
        {
            if (ModelState.IsValid)
            {
                db.Fechas.Add(fecha);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(fecha);
        }

        // GET: Fechas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Fecha fecha = db.Fechas.Find(id);
            if (fecha == null)
            {
                return HttpNotFound();
            }
            return View(fecha);
        }

        // POST: Fechas/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,año,mes,dia")] Fecha fecha)
        {
            if (ModelState.IsValid)
            {
                db.Entry(fecha).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(fecha);
        }

        // GET: Fechas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Fecha fecha = db.Fechas.Find(id);
            if (fecha == null)
            {
                return HttpNotFound();
            }
            return View(fecha);
        }

        // POST: Fechas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Fecha fecha = db.Fechas.Find(id);
            db.Fechas.Remove(fecha);
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
