using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.Services;
using CitasSalonApp.Models;

namespace CitasSalonApp
{
    /// <summary>
    /// Descripción breve de CitasWebService
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // Para permitir que se llame a este servicio web desde un script, usando ASP.NET AJAX, quite la marca de comentario de la línea siguiente. 
    // [System.Web.Script.Services.ScriptService]
    public class CitasWebService : System.Web.Services.WebService
    {
        CitasModelContainer db = new CitasModelContainer();

        [WebMethod]
        public bool RegistrarCliente(string nombre, string apellido, string correo, string telefono, short edad)
        {
            // Verifico si el ususario ya existe y no permito el registro
            if(db.Clientes.Where(cl => cl.correo == correo).Any())
            {
                return false;
            }

            Cliente c = new Cliente();

            c.nombre = nombre;
            c.apellido = apellido;
            c.correo = correo;
            c.telefono = telefono;
            c.edad = edad;
            c.EstadoCliente = db.EstadoClientes.Find(1);

            db.Clientes.Add(c);

            int result = db.SaveChanges();

            return result > 0;
        }

        [WebMethod]
        public List<DetalleDia> Get_Horas_Disponibles_Fecha(int mes, int dia)
        {
            List<DetalleDia> deta = db.DetalleFechaBloques.Where(e => e.EstadoHorario.Id == 1 && e.Fecha.mes == mes && e.Fecha.dia == dia).Select(x => new DetalleDia()
            {
                Id = x.Id,
                HoraId = x.HoraId,
                Bloque = x.Hora.bloque,
                FechaId = x.FechaId,
                Mes = x.Fecha.mes,
                Dia = x.Fecha.dia,
            }).ToList();

            return deta;
        }

        public class DetalleDia
        {
            public int Id { get; set; }
            public int HoraId { get; set; }
            public string Bloque { get; set; }
            public int FechaId { get; set; }
            public short Mes { get; set; }
            public short Dia { get; set; }
        }

        [WebMethod]
        public List<Tipos_Servicio> Get_Tipos_Servicio()
        {
            return db.TipoServicios.Select(t => new Tipos_Servicio()
            {
                Id = t.Id,
                descripcion = t.descripcion
            }).ToList();
        }

        public class Tipos_Servicio
        {
            public int Id { get; set; }
            public string descripcion { get; set; }
        }

        [WebMethod]
        public List<Servicios> Get_Servicios()
        {
            return db.Servicios.Select(s => new Servicios()
            {
                Id = s.Id,
                nombre = s.nombre,
                TipoServicio_Id = s.TipoServicio.Id
            }).ToList();
        }

        public class Servicios
        {
            public int Id { get; set; }
            public string nombre { get; set; }
            public int TipoServicio_Id { get; set; }

        }
    }
}
