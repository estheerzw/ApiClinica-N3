using ClinicaApi.DTOs;
using ClinicaApi.Models;
using ClinicaApi.Interfaces;

namespace ClinicaApi.Mappers
{
    public class PacienteMapper : IPacienteMapper
    {
        public Paciente ToEntity(PacienteCreateDTO dto)
        {
            return new Paciente
            {
                Nome = dto.Nome,
                Email = dto.Email,
                Telefone = dto.Telefone,
                DataNasc = dto.DataNasc,
                Cpf = dto.Cpf
            };
        }

        public PacienteReadDTO ToReadDTO(Paciente paciente)
        {
            return new PacienteReadDTO
            {
                Id = paciente.Id,
                Nome = paciente.Nome,
                Email = paciente.Email,
                Telefone = paciente.Telefone,
                DataNasc = paciente.DataNasc,
                Cpf = paciente.Cpf
            };
        }

        public void UpdateEntity(Paciente paciente, PacienteUpdateDTO dto)
        {
            if (dto.Nome != null)
                paciente.Nome = dto.Nome;

            if (dto.Email != null)
                paciente.Email = dto.Email;

            if (dto.Telefone != null)
                paciente.Telefone = dto.Telefone;

            if (dto.DataNasc.HasValue)
                paciente.DataNasc = dto.DataNasc.Value;
        }
    }
}