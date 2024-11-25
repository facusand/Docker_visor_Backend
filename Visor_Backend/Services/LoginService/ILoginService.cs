using DB.Models;
using Visor_Backend.DTOs;

namespace Visor_Backend.Services.LoginService
{
    public interface ILoginService
    {
        User CheckUser(UserDTO user);
    }
}
