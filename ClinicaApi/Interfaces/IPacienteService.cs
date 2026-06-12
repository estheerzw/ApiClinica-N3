using ClinicaApi.DTOs;

namespace ClinicaApi.Interfaces
{
    public interface IPacienteService
    {
        IEnumerable<PacienteReadDTO> GetAll();
        PacienteReadDTO GetById(int id);
        PacienteReadDTO Create(PacienteCreateDTO dto);
        bool Update(int id, PacienteUpdateDTO dto);
        bool Delete(int id);
    }
}