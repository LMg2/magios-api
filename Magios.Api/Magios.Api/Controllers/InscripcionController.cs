using Magios.Api.Models;
using Magios.Api.Repositories;
using System.Web.Http;
using System.Web.Http.Cors;

namespace Magios.Api.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class InscripcionController : ApiController
    {
        [Route("api/Inscripcion")]
        public IHttpActionResult Get()
        {
            var repo = new InscripcionesRepo();
            return Ok(repo.getDatosInscripcion());
        }

        [Route("api/Inscripcion/{claseBarco}/{numeroVela}")]
        public IHttpActionResult Get(string claseBarco, string numeroVela)
        {
            IHttpActionResult result = null;
            var repo = new InscripcionesRepo();
            var inscripcion = repo.getInscripcion(claseBarco, numeroVela);
            if (inscripcion == null)
                result = NotFound();
            else
                result = Ok(inscripcion);
            return result;
        }

        [Route("api/Inscripcion")]
        public IHttpActionResult Post([FromBody]DatosInscripcion data)
        {
            var repo = new InscripcionesRepo();
            var inscripcion = repo.getInscripcion(data.ClaseBarco, data.NumeroVela);
            IHttpActionResult result;
            if (inscripcion != null)
            {
                result = BadRequest("Ya existe clase de barco y numero de vela");
            }
            else
            {
                repo.addInscripcion(data);
                result = Created("get/" + data.ClaseBarco + "/" + data.NumeroVela, data);
            }
            return result;
        }

        [Route("api/Inscripcion/{claseBarco}/{numeroVela}")]
        public IHttpActionResult Delete(string claseBarco, string numeroVela)
        {
            var repo = new InscripcionesRepo();
            repo.deleteInscripcion(claseBarco, numeroVela);
            return Ok(new { Message = "Inscripcion eliminada" });
        }
    }
}
