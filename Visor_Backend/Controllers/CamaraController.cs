using Microsoft.AspNetCore.Mvc;
using Visor_Backend.DTOs;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Visor_Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CamaraController : ControllerBase
    {
        [HttpGet("camaras")]
        public IActionResult GetCamaras()
        {
            var camaras = new List<Camara>
    {
        new Camara { Id = 1, Nombre = "Cámara 1", Url = "http://79.161.6.126:9092/axis-cgi/mjpg/video.cgi" },
        new Camara { Id = 2, Nombre = "Cámara 2", Url = "https://iihrwc03.iowa.uiowa.edu/axis-cgi/mjpg/video.cgi" },
        new Camara { Id = 3, Nombre = "Cámara 3", Url = "https://erma-stedi-cam.gmd-tg.ch/axis-cgi/mjpg/video.cgi" },
        new Camara { Id = 4, Nombre = "Cámara 4", Url = "http://webcam1.vilhelmina.se/axis-cgi/mjpg/video.cgi" },
        new Camara { Id = 5, Nombre = "Cámara 5", Url = "http://chalet-chuenis.internet-box.ch/axis-cgi/mjpg/video.cgi" },
        new Camara { Id = 6, Nombre = "Cámara 6", Url = "http://webcam4.vilhelmina.se/axis-cgi/mjpg/video.cgi" }
    };

            return Ok(camaras);
        }
    }
}
