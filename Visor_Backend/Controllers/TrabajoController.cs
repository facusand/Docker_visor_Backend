﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using DB.Models;
using Microsoft.EntityFrameworkCore;
using System.Net;
using System.Diagnostics;
using Microsoft.AspNetCore.Authorization;
using Visor_Backend.Services.TrabajoService;
using Visor_Backend.DTOs;

namespace Visor_Backend.Controllers
{
    [Route("api/trabajo")]
    [ApiController]
    public class TrabajoController : ControllerBase
    {
        private readonly ITrabajoService _trabajoService;
        private readonly SolucionesContext _context;

        public TrabajoController(ITrabajoService trabajoService, SolucionesContext context)
        {
            _trabajoService = trabajoService;
            _context = context;
        }


        [HttpGet("list")]
        public async Task<IActionResult> List()
        {
            var trabajos = await _trabajoService.GetAll();
            return Ok(trabajos);
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var trabajo = _trabajoService.GetById(id);

            if (trabajo == null)
                return NotFound();

            return Ok(trabajo);
        }

        [HttpPost("create")]
        [Authorize(Roles = "admin")]
        public IActionResult AddTrabajo([FromForm] TrabajoDto dto)
        {
            try
            {
                if (dto == null)
                    return BadRequest("Datos invalidos");

                var files = Request.Form.Files;
                if (files.Count > 0)
                {
                    dto.Images = files;
                }

                _trabajoService.Add(dto);
                //await _context.Trabajos.AddAsync(trabajo);
                //await _context.SaveChangesAsync();
                return Ok(new { HttpStatusCode.Created, message = "Creado con éxito" });
            }
            catch (Exception ex)
            {
                return BadRequest($"Ocurrió un error al crear. {ex.Message}");
            }
        }

        [HttpDelete("delete/{id}")]
        [Authorize(Roles = "admin")]
        public IActionResult Delete(int id)
        {
            try
            {
                _trabajoService.Delete(id);

                return Ok(new { HttpStatusCode.Accepted, message = "Eliminado con éxito" });
            }
            catch (Exception ex)
            {
                return BadRequest($"Ocurrión un error al eliminar. {ex.Message}");
            }
        }

        [HttpPost("update")]
        public IActionResult Update([FromForm] TrabajoDto dto)
        {
            try
            {
                var files = Request.Form.Files;
                if (dto == null)
                    return BadRequest("Datos invalidos");

                if (files.Count > 0)
                {
                    dto.Images = files;
                }

                _trabajoService.Update(dto);

                return Ok(new { HttpStatusCode.Accepted, message = "Actualizado con éxito" });
            }
            catch (Exception ex)
            {
                return BadRequest($"Ocurrió un error en la actualización. {ex.Message}");
            }
        }

        [HttpPost("updateWithDeletedImages")]
        public IActionResult UpdateWithDeletedImages([FromForm] TrabajoDto dto)
        {
            try
            {
                var files = Request.Form.Files;
                if (dto == null)
                    return BadRequest("Datos invalidos");

                if (files.Count > 0)
                {
                    dto.Images = files;
                }

                _trabajoService.UpdateWithDeletedImages(dto);

                return Ok(new { HttpStatusCode.Accepted, message = "Actualizado con éxito" });
            }
            catch (Exception ex)
            {
                return BadRequest($"Ocurrió un error en la actualización. {ex.Message}");
            }
        }
    }
}
