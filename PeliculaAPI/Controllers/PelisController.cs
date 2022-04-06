using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PeliculaAPI.Models;
using PeliculaAPI.Repositories;

namespace PeliculaAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PelisController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get()
        {
            RPPelis rpPelis = new RPPelis();
            return Ok(rpPelis.ObtenerPeliculas());
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            RPPelis rpPelis = new RPPelis();

            var cliRet = rpPelis.ObtenerPeliculas(id);

            if (cliRet == null)
            {
                var nf = NotFound("La pelicula " + id.ToString() + " no existe.");
                return nf;
            }

            return Ok(cliRet);
        }

        [HttpPost("agregar")]
        public IActionResult AgregarPelicula(Peliculas nuevaPeliculas)
        {
            RPPelis rpPelis = new RPPelis();
            rpPelis.Agregar(nuevaPeliculas);
            return CreatedAtAction(nameof(AgregarPelicula), nuevaPeliculas);
        }
    }
}



