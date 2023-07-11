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
    public class DetalleFechaBloquesController : Controller
    {
        private CitasModelContainer db = new CitasModelContainer();

        // GET: DetalleFechaBloques
        public ActionResult Index()
        {
            var detalleFechaBloques = db.DetalleFechaBloques.Include(d => d.Hora).Include(d => d.Fecha);
            return View(detalleFechaBloques.ToList());
        }

        // GET: DetalleFechaBloques/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DetalleFechaBloque detalleFechaBloque = db.DetalleFechaBloques.Find(id);
            if (detalleFechaBloque == null)
            {
                return HttpNotFound();
            }
            return View(detalleFechaBloque);
        }

        // GET: DetalleFechaBloques/Create
        public ActionResult Create()
        {
            ViewBag.HoraId = new SelectList(db.Horas, "Id", "bloque");
            ViewBag.FechaId = new SelectList(db.Fechas, "Id", "Id");
            return View();
        }

        // POST: DetalleFechaBloques/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,HoraId,FechaId")] DetalleFechaBloque detalleFechaBloque)
        {
            if (ModelState.IsValid)
            {
                db.DetalleFechaBloques.Add(detalleFechaBloque);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.HoraId = new SelectList(db.Horas, "Id", "bloque", detalleFechaBloque.HoraId);
            ViewBag.FechaId = new SelectList(db.Fechas, "Id", "Id", detalleFechaBloque.FechaId);
            return View(detalleFechaBloque);
        }

        // GET: DetalleFechaBloques/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DetalleFechaBloque detalleFechaBloque = db.DetalleFechaBloques.Find(id);
            if (detalleFechaBloque == null)
            {
                return HttpNotFound();
            }
            ViewBag.HoraId = new SelectList(db.Horas, "Id", "bloque", detalleFechaBloque.HoraId);
            ViewBag.FechaId = new SelectList(db.Fechas, "Id", "Id", detalleFechaBloque.FechaId);
            return View(detalleFechaBloque);
        }

        // POST: DetalleFechaBloques/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,HoraId,FechaId")] DetalleFechaBloque detalleFechaBloque)
        {
            if (ModelState.IsValid)
            {
                db.Entry(detalleFechaBloque).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.HoraId = new SelectList(db.Horas, "Id", "bloque", detalleFechaBloque.HoraId);
            ViewBag.FechaId = new SelectList(db.Fechas, "Id", "Id", detalleFechaBloque.FechaId);
            return View(detalleFechaBloque);
        }

        // GET: DetalleFechaBloques/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DetalleFechaBloque detalleFechaBloque = db.DetalleFechaBloques.Find(id);
            if (detalleFechaBloque == null)
            {
                return HttpNotFound();
            }
            return View(detalleFechaBloque);
        }

        // POST: DetalleFechaBloques/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            DetalleFechaBloque detalleFechaBloque = db.DetalleFechaBloques.Find(id);
            db.DetalleFechaBloques.Remove(detalleFechaBloque);
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
