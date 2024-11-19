using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using Proyecto._2.Models;

namespace Proyecto._2.Controllers
{
    public class HistorialCalculosController : ApiController
    {
        private Model1 db = new Model1();

        // GET: api/HistorialCalculos
        // Obtiene todos los cálculos existentes
        public IHttpActionResult Get()
        {
            var calculos = db.HistorialCalculos.ToList();
            return Ok(calculos);
        }

        // GET: api/HistorialCalculos/{id}
        // Obtiene un cálculo específico por id
        public IHttpActionResult Get(int id)
        {
            var historialCalculos = db.HistorialCalculos.Find(id);
            if (historialCalculos == null)
            {
                return NotFound();
            }
            return Ok(historialCalculos);
        }

        // GET: api/HistorialCalculos/sumas
        // Obtiene todas las sumas realizadas
        [HttpGet]
        [Route("api/HistorialCalculos/sumas")]
        public IHttpActionResult GetSumas()
        {
            var sumas = db.HistorialCalculos.Where(h => h.Operacion.Contains("+")).ToList();
            return Ok(sumas);
        }

        // GET: api/HistorialCalculos/restas
        // Obtiene todas las restas realizadas
        [HttpGet]
        [Route("api/HistorialCalculos/restas")]
        public IHttpActionResult GetRestas()
        {
            var restas = db.HistorialCalculos.Where(h => h.Operacion.Contains("-")).ToList();
            return Ok(restas);
        }

        // GET: api/HistorialCalculos/multiplicaciones
        // Obtiene todas las multiplicaciones realizadas
        [HttpGet]
        [Route("api/HistorialCalculos/multiplicaciones")]
        public IHttpActionResult GetMultiplicaciones()
        {
            var multiplicaciones = db.HistorialCalculos.Where(h => h.Operacion.Contains("*")).ToList();
            return Ok(multiplicaciones);
        }

        // GET: api/HistorialCalculos/divisiones
        // Obtiene todas las divisiones realizadas
        [HttpGet]
        [Route("api/HistorialCalculos/divisiones")]
        public IHttpActionResult GetDivisiones()
        {
            var divisiones = db.HistorialCalculos.Where(h => h.Operacion.Contains("/")).ToList();
            return Ok(divisiones);
        }

        // GET: api/HistorialCalculos/porFecha?startDate={startDate}&endDate={endDate}
        // Obtiene cálculos realizados entre dos fechas
        [HttpGet]
        [Route("api/HistorialCalculos/porFecha")]
        public IHttpActionResult GetPorFecha(DateTime startDate, DateTime endDate)
        {
            var calculosPorFecha = db.HistorialCalculos
                .Where(h => h.FechaRegistro >= startDate && h.FechaRegistro <= endDate)
                .ToList();

            if (!calculosPorFecha.Any())
            {
                return NotFound();
            }

            return Ok(calculosPorFecha);
        }

        // POST: api/HistorialCalculos
        // Crea un nuevo cálculo
        public IHttpActionResult Post([FromBody] HistorialCalculos historialCalculos)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Invalid data.");
            }

            db.HistorialCalculos.Add(historialCalculos);
            db.SaveChanges();
            return CreatedAtRoute("DefaultApi", new { id = historialCalculos.Id }, historialCalculos);
        }

        // PUT: api/HistorialCalculos/{id}
        // Actualiza un cálculo existente
        public IHttpActionResult Put(int id, [FromBody] HistorialCalculos historialCalculos)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Invalid data.");
            }

            var existingHistorial = db.HistorialCalculos.Find(id);
            if (existingHistorial == null)
            {
                return NotFound();
            }

            existingHistorial.Operacion = historialCalculos.Operacion;
            existingHistorial.Resultado = historialCalculos.Resultado;
            existingHistorial.FechaRegistro = historialCalculos.FechaRegistro;
            existingHistorial.HoraRegistro = historialCalculos.HoraRegistro;

            db.SaveChanges();
            return StatusCode(System.Net.HttpStatusCode.NoContent);
        }

        // DELETE: api/HistorialCalculos/{id}
        // Elimina un cálculo
        public IHttpActionResult Delete(int id)
        {
            var historialCalculos = db.HistorialCalculos.Find(id);
            if (historialCalculos == null)
            {
                return NotFound();
            }

            db.HistorialCalculos.Remove(historialCalculos);
            db.SaveChanges();
            return Ok(historialCalculos);
        }
    }
}
