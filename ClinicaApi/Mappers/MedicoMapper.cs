using ClinicaApi.DTOs;
using ClinicaApi.Models;
using ClinicaApi.Interfaces;

namespace ClinicaApi.Mappers
{
    public class MedicoMapper : IMedicoMapper
    {
        public Medico ToEntity(MedicoCreateDTO dto)
        {
            return new Medico
            {
                Nome = dto.Nome,
                Email = dto.Email,
                Telefone = dto.Telefone,
                CRM = dto.CRM
            };
        }

        public MedicoReadDTO ToReadDTO(Medico medico)
        {
            return new MedicoReadDTO
            {
                Id = medico.Id,
                Nome = medico.Nome,
                Email = medico.Email,
                Telefone = medico.Telefone,
                CRM = medico.CRM
            };
        }

        public void UpdateEntity(Medico medico, MedicoUpdateDTO dto)
        {
            if (dto.Nome != null)
                medico.Nome = dto.Nome;

            if (dto.Email != null)
                medico.Email = dto.Email;

            if (dto.Telefone != null)
                medico.Telefone = dto.Telefone;

            if (dto.CRM != null)
                medico.CRM = dto.CRM;
        }
    }
}