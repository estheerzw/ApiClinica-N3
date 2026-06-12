using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using ClinicaApi.DTOs;
using ClinicaApi.Interfaces;

namespace ClinicaApi.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class ConsultasController : ControllerBase
    {
        private readonly IConsultaService _service;

        public ConsultasController(IConsultaService service)
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
            var consulta = _service.GetById(id);

            if (consulta == null)
                return NotFound();

            return Ok(consulta);
        }

        [HttpPost]
        public IActionResult Post(ConsultaCreateDTO dto)
        {
            var consulta = _service.Create(dto);

            if (consulta == null)
                return BadRequest();

            return Ok(consulta);
        }

        [Authorize(Roles = "admin")]
        [HttpPatch("{id}")]
        public IActionResult Patch(int id, ConsultaUpdateDTO dto)
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