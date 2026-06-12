using ClinicaApi.DTOs;
using ClinicaApi.Models;
using ClinicaApi.Interfaces;

namespace ClinicaApi.Mappers
{
    public class ConsultaMapper : IConsultaMapper
    {
        public Consulta ToEntity(ConsultaCreateDTO dto)
        {
            return new Consulta
            {
                PacienteId = dto.PacienteId,
                MedicoId = dto.MedicoId,
                DataHora = dto.DataHora
            };
        }

        public ConsultaReadDTO ToReadDTO(Consulta consulta)
        {
            return new ConsultaReadDTO
            {
                Id = consulta.Id,
                PacienteId = consulta.PacienteId,
                NomePaciente = consulta.Paciente?.Nome ?? "",
                MedicoId = consulta.MedicoId,
                NomeMedico = consulta.Medico?.Nome ?? "",
                DataHora = consulta.DataHora
            };
        }

        public void UpdateEntity(Consulta consulta, ConsultaUpdateDTO dto)
        {
            if (dto.PacienteId.HasValue)
                consulta.PacienteId = dto.PacienteId.Value;

            if (dto.MedicoId.HasValue)
                consulta.MedicoId = dto.MedicoId.Value;

            if (dto.DataHora.HasValue)
                consulta.DataHora = dto.DataHora.Value;
        }
    }
}