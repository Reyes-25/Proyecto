using System.Linq;
using System.Web.Http;
using Proyecto._2.Models;

namespace Proyecto._2.Controllers
{
    [RoutePrefix("api/HistorialCalculos")]
    public class HistorialCalculosApiController : ApiController
    {
        private readonly HistorialCalculosRepository _repository;

        public HistorialCalculosApiController()
        {
            _repository = new HistorialCalculosRepository();
        }

        [HttpGet]
        [Route("Todos")]
        public IHttpActionResult GetTodos()
        {
            var calculos = _repository.GetTodos();
            return Ok(calculos);
        }

        [HttpGet]
        [Route("Sumas")]
        public IHttpActionResult GetSumas()
        {
            var sumas = _repository.GetSumas();
            return Ok(sumas);
        }

        [HttpGet]
        [Route("Restas")]
        public IHttpActionResult GetRestas()
        {
            var restas = _repository.GetRestas();
            return Ok(restas);
        }

        [HttpGet]
        [Route("Multiplicaciones")]
        public IHttpActionResult GetMultiplicaciones()
        {
            var multiplicaciones = _repository.GetMultiplicaciones();
            return Ok(multiplicaciones);
        }

        [HttpGet]
        [Route("Divisiones")]
        public IHttpActionResult GetDivisiones()
        {
            var divisiones = _repository.GetDivisiones();
            return Ok(divisiones);
        }
    }
}