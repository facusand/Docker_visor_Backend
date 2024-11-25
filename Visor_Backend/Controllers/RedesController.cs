using Microsoft.AspNetCore.Mvc;
using Visor_Backend.DTOs;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Visor_Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RedesController : ControllerBase
    {
        [HttpGet("redes-sociales")]
        public IActionResult GetRedesSociales()
        {
            var redesSociales = new List<RedSocial>
    {
        new RedSocial { Id = 1, Nombre = "Twitter", Url = "http://twitter.com/tu_cuenta", Contenido = "Última publicación en Twitter." },
        new RedSocial { Id = 2, Nombre = "Facebook", Url = "http://facebook.com/tu_cuenta", Contenido = "Última publicación en Facebook." },
        new RedSocial { Id = 3, Nombre = "Instagram", Url = "http://instagram.com/tu_cuenta", Contenido = "Última publicación en Instagram." }
    };

            return Ok(redesSociales);
        }
    }
}
