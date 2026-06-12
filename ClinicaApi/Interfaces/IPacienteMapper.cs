using ClinicaApi.DTOs;
using ClinicaApi.Models;

namespace ClinicaApi.Interfaces
{
    public interface IPacienteMapper
    {
        Paciente ToEntity(PacienteCreateDTO dto);
        PacienteReadDTO ToReadDTO(Paciente paciente);
        void UpdateEntity(Paciente paciente, PacienteUpdateDTO dto);
    }
}