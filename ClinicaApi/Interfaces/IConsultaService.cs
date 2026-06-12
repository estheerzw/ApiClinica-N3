using ClinicaApi.DTOs;

namespace ClinicaApi.Interfaces
{
    public interface IConsultaService
    {
        IEnumerable<ConsultaReadDTO> GetAll();

        ConsultaReadDTO GetById(int id);

        ConsultaReadDTO Create(ConsultaCreateDTO dto);

        bool Update(int id, ConsultaUpdateDTO dto);

        bool Delete(int id);
    }
}