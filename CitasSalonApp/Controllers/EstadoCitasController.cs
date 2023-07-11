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
    public class EstadoCitasController : Controller
    {
        private CitasModelContainer db = new CitasModelContainer();

        // GET: EstadoCitas
        public ActionResult Index()
        {
            return View(db.EstadoCitas.ToList());
        }

        // GET: EstadoCitas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EstadoCita estadoCita = db.EstadoCitas.Find(id);
            if (estadoCita == null)
            {
                return HttpNotFound();
            }
            return View(estadoCita);
        }

        // GET: EstadoCitas/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: EstadoCitas/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,descripcion")] EstadoCita estadoCita)
        {
            if (ModelState.IsValid)
            {
                db.EstadoCitas.Add(estadoCita);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(estadoCita);
        }

        // GET: EstadoCitas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EstadoCita estadoCita = db.EstadoCitas.Find(id);
            if (estadoCita == null)
            {
                return HttpNotFound();
            }
            return View(estadoCita);
        }

        // POST: EstadoCitas/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,descripcion")] EstadoCita estadoCita)
        {
            if (ModelState.IsValid)
            {
                db.Entry(estadoCita).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(estadoCita);
        }

        // GET: EstadoCitas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EstadoCita estadoCita = db.EstadoCitas.Find(id);
            if (estadoCita == null)
            {
                return HttpNotFound();
            }
            return View(estadoCita);
        }

        // POST: EstadoCitas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            EstadoCita estadoCita = db.EstadoCitas.Find(id);
            db.EstadoCitas.Remove(estadoCita);
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
