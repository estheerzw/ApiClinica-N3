using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using ClinicaApi.DTOs;
using ClinicaApi.Interfaces;

namespace ClinicaApi.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class PacientesController : ControllerBase
    {
        private readonly IPacienteService _service;

        public PacientesController(IPacienteService service)
        {
            _service = service;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_service.GetAll());
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var paciente = _service.GetById(id);

            if (paciente == null)
                return NotFound();

            return Ok(paciente);
        }

        [HttpPost]
        public IActionResult Post(PacienteCreateDTO dto)
        {
            var paciente = _service.Create(dto);

            return Ok(paciente);
        }

        [Authorize(Roles = "admin")]
        [HttpPatch("{id}")]
        public IActionResult Patch(int id, PacienteUpdateDTO dto)
        {
            bool atualizado = _service.Update(id, dto);

            if (!atualizado)
                return NotFound();

            return NoContent();
        }

        [Authorize(Roles = "admin")]
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            bool removido = _service.Delete(id);

            if (!removido)
                return NotFound();

            return NoContent();
        }
    }
}