using ClinicaApi.DTOs;
using ClinicaApi.Models;

namespace ClinicaApi.Interfaces
{
    public interface IConsultaMapper
    {
        Consulta ToEntity(ConsultaCreateDTO dto);

        ConsultaReadDTO ToReadDTO(Consulta consulta);

        void UpdateEntity(Consulta consulta, ConsultaUpdateDTO dto);
    }
}