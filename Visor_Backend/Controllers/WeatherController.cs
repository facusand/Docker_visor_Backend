using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;


namespace Visor_Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WeatherController : ControllerBase
    {
        private readonly HttpClient _httpClient;
        private readonly IConfiguration _configuration;

        public WeatherController(HttpClient httpClient, IConfiguration configuration)
        {
            _httpClient = httpClient;
            _configuration = configuration;
        }

        [HttpGet("current")]
        public async Task<IActionResult> GetCurrentWeather(string city)
        {
            // Obtiene la clave de API desde el archivo de configuración
            string apiKey = _configuration["OpenWeatherMap:ApiKey"];

            // Construye la URL con los parámetros de la API
            string apiUrl = $"https://api.openweathermap.org/data/2.5/weather?q={city}&appid={apiKey}&lang=es&units=metric";

            try
            {
                // Hace la solicitud a la API de OpenWeatherMap
                var response = await _httpClient.GetStringAsync(apiUrl);

                // Retorna la respuesta de la API tal cual la recibimos (en formato JSON)
                return Ok(response);
            }
            catch (HttpRequestException e)
            {
                // Si hay un error al llamar a la API, retorna un mensaje de error
                return StatusCode(500, $"Error al obtener los datos del clima: {e.Message}");
            }
        }


    }
}
