using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Visor_Backend.DTOs;
using Visor_Backend.Handlers;
using Visor_Backend.Services.LoginService;

namespace Visor_Backend.Controllers
{
    [Route("api/login")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly ILoginService _loginService;
        private JwtHandler _jwtHandler;
        public LoginController(ILoginService loginService, JwtHandler jwtHandler)
        {
            _loginService = loginService;
            _jwtHandler = jwtHandler;
        }

        [HttpPost]
        public IActionResult Login(UserDTO userLogin)
        {
            var user = _loginService.CheckUser(userLogin);
            if (user != null)
            {
                //Crear Token
                var token = _jwtHandler.Generate(user);
                return Ok(token);
            }
            else

                return NotFound("Usuario no encontrado");
        }
    }
}
