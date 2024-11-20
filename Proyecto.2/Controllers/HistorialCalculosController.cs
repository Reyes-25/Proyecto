using System.Linq;
using System.Web.Http;
using Proyecto._2.Models;

namespace Proyecto._2.Controllers
{
    [RoutePrefix("api/HistorialCalculos")]
    public class HistorialCalculosApiController : ApiController
    {
        private Model1 db = new Model1();

        [HttpGet]
        [Route("Todos")]
        public IHttpActionResult GetTodos()
        {
            var calculos = db.HistorialCalculos.ToList();
            return Ok(calculos);
        }

        [HttpGet]
        [Route("Sumas")]
        public IHttpActionResult GetSumas()
        {
            var sumas = db.HistorialCalculos.Where(c => c.Operacion.Contains("+")).ToList();
            return Ok(sumas);
        }

        [HttpGet]
        [Route("Restas")]
        public IHttpActionResult GetRestas()
        {
            var restas = db.HistorialCalculos.Where(c => c.Operacion.Contains("-")).ToList();
            return Ok(restas);
        }

        [HttpGet]
        [Route("Multiplicaciones")]
        public IHttpActionResult GetMultiplicaciones()
        {
            var multiplicaciones = db.HistorialCalculos.Where(c => c.Operacion.Contains("*")).ToList();
            return Ok(multiplicaciones);
        }

        [HttpGet]
        [Route("Divisiones")]
        public IHttpActionResult GetDivisiones()
        {
            var divisiones = db.HistorialCalculos.Where(c => c.Operacion.Contains("/")).ToList();
            return Ok(divisiones);
        }

        [HttpGet]
        [Route("Filtrado")]
        public IHttpActionResult GetFiltrado(string criterio)
        {
            var filtrados = db.HistorialCalculos
                .Where(c => c.Operacion.Contains(criterio))
                .ToList();
            return Ok(filtrados);
        }

        [HttpPost]
        [Route("Crear")]
        public IHttpActionResult PostCalculo(HistorialCalculos calculo)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            db.HistorialCalculos.Add(calculo);
            db.SaveChanges();

            return Ok(calculo);
        }
    }
}