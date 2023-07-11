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
    public class CitasController : Controller
    {
        private CitasModelContainer db = new CitasModelContainer();

        // GET: Citas
        public ActionResult Index()
        {
            Llenar_Anio();
            return View(db.Citas.Include(cl => cl.Cliente).Include(serv => serv.Servicio).Include(estado => estado.EstadoCita).Include(fecha => fecha.DetalleFechaBloque).ToList());
        }

        // GET: Citas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cita cita = db.Citas.Find(id);
            if (cita == null)
            {
                return HttpNotFound();
            }
            return View(cita);
        }

        // GET: Citas/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Citas/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,descripcion,numero_deposito")] Cita cita)
        {
            if (ModelState.IsValid)
            {
                db.Citas.Add(cita);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(cita);
        }

        // GET: Citas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cita cita = db.Citas.Find(id);
            if (cita == null)
            {
                return HttpNotFound();
            }
            return View(cita);
        }

        // POST: Citas/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,descripcion,numero_deposito")] Cita cita)
        {
            if (ModelState.IsValid)
            {
                db.Entry(cita).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(cita);
        }

        // GET: Citas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cita cita = db.Citas.Find(id);
            if (cita == null)
            {
                return HttpNotFound();
            }
            return View(cita);
        }

        // POST: Citas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Cita cita = db.Citas.Find(id);
            db.Citas.Remove(cita);
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



        private void Llenar_Anio()
        {
            CitasModelContainer db = new CitasModelContainer();

            DateTime fecha = DateTime.Now;

            if (db.Fechas.Where(f => f.año == fecha.Year).Any() == false)
            {
                for (int i = fecha.Month; i < 13; i++)
                {
                    for (int j = 1; j <= DateTime.DaysInMonth(fecha.Year, i); j++)
                    {
                        if (db.Fechas.Where(f => f.año == fecha.Year && f.mes == i && f.dia == j).Any() == false)
                        {
                            DateTime fechaCiclo = new DateTime(fecha.Year, i, j);

                            if (fechaCiclo >= fecha)
                            {
                                Fecha dato = new Fecha()
                                {
                                    año = ((short)fecha.Year),
                                    mes = ((short)i),
                                    dia = ((short)j)
                                };

                                db.Fechas.Add(dato);
                            }
                        }
                    }
                }
                db.SaveChanges();
                LlenarHorarios();
            }
        }

        private void LlenarHorarios()
        {
            CitasModelContainer db = new CitasModelContainer();

            List<Fecha> dias = db.Fechas.Where(d => d.año == DateTime.Now.Year).ToList();
            List<Hora> bloques = db.Horas.ToList();

            foreach (var dia in dias)
            {
                foreach (var bloque in bloques)
                {
                    DetalleFechaBloque det = new DetalleFechaBloque();

                    det.FechaId = dia.Id;
                    det.HoraId = bloque.Id;
                    det.EstadoHorario = db.EstadoHorarios.Find(1);

                    db.DetalleFechaBloques.Add(det);
                }
            }
            db.SaveChanges();
        }
    }
}
