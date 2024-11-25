using DB.Models;
using Microsoft.AspNetCore.Mvc;
using Visor_Backend.DTOs;

namespace Visor_Backend.Services.TrabajoService
{
    public interface ITrabajoService
    {
        Task<List<TrabajoDto>> GetAll();
        void Add(TrabajoDto trabajo);
        void Delete(int id);

        void Update(TrabajoDto dto);
        void UpdateWithDeletedImages(TrabajoDto dto);
        TrabajoDto GetById(int id);
    }
}
