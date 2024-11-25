using Visor_Backend.DTOs;

namespace Visor_Backend.Services.PubliImageService
{
    public interface IPubliImageService
    {
        Task<List<PubliImageDto>> GetAll();
        void Add(PubliImageDto publiImage);
        void Delete(int id);
        void Update(PubliImageDto dto);
    }
}
