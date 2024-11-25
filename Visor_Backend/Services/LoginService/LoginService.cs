using DB.Models;
using Visor_Backend.Handlers;
using Visor_Backend.DTOs;

namespace Visor_Backend.Services.LoginService
{
    public class LoginService : ILoginService
    {
        private SolucionesContext _context;
        public LoginService(SolucionesContext context)
        {
            _context = context;
        }

        public User CheckUser(UserDTO userLogin)
        {
            var currentUser = _context.Users.FirstOrDefault(user => user.Username.ToLower() == userLogin.Username.ToLower()
                    && user.Password == userLogin.Password);

            if (currentUser != null)
            {
                return currentUser;
            }
            else
            {
                return null;
            }
        }
    }
}
