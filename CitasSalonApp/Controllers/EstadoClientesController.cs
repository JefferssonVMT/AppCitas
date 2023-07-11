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
    public class EstadoClientesController : Controller
    {
        private CitasModelContainer db = new CitasModelContainer();

        // GET: EstadoClientes
        public ActionResult Index()
        {
            return View(db.EstadoClientes.ToList());
        }

        // GET: EstadoClientes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EstadoCliente estadoCliente = db.EstadoClientes.Find(id);
            if (estadoCliente == null)
            {
                return HttpNotFound();
            }
            return View(estadoCliente);
        }

        // GET: EstadoClientes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: EstadoClientes/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,descripcion")] EstadoCliente estadoCliente)
        {
            if (ModelState.IsValid)
            {
                db.EstadoClientes.Add(estadoCliente);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(estadoCliente);
        }

        // GET: EstadoClientes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EstadoCliente estadoCliente = db.EstadoClientes.Find(id);
            if (estadoCliente == null)
            {
                return HttpNotFound();
            }
            return View(estadoCliente);
        }

        // POST: EstadoClientes/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,descripcion")] EstadoCliente estadoCliente)
        {
            if (ModelState.IsValid)
            {
                db.Entry(estadoCliente).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(estadoCliente);
        }

        // GET: EstadoClientes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EstadoCliente estadoCliente = db.EstadoClientes.Find(id);
            if (estadoCliente == null)
            {
                return HttpNotFound();
            }
            return View(estadoCliente);
        }

        // POST: EstadoClientes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            EstadoCliente estadoCliente = db.EstadoClientes.Find(id);
            db.EstadoClientes.Remove(estadoCliente);
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
