using Visor_Backend.DTOs;

namespace Visor_Backend.Services.CatalogoService
{
    public interface ICatalogoService
    {
        Task<List<CatalogoDto>> GetAll();
        void Add(CatalogoDto trabajo);
        void Delete(int id);
        void Update(CatalogoDto dto);
    }
}
