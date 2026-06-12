using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using ClinicaApi.DTOs;
using ClinicaApi.Interfaces;

namespace ClinicaApi.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class MedicosController : ControllerBase
    {
        private readonly IMedicoService _service;

        public MedicosController(IMedicoService service)
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
            var medico = _service.GetById(id);

            if (medico == null)
                return NotFound();

            return Ok(medico);
        }

        [HttpPost]
        public IActionResult Post(MedicoCreateDTO dto)
        {
            var medico = _service.Create(dto);

            return Ok(medico);
        }

        [Authorize(Roles = "admin")]
        [HttpPatch("{id}")]
        public IActionResult Patch(int id, MedicoUpdateDTO dto)
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