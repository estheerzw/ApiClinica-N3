using ClinicaApi.DTOs;

namespace ClinicaApi.Interfaces
{
    public interface IMedicoService
    {
        IEnumerable<MedicoReadDTO> GetAll();

        MedicoReadDTO GetById(int id);

        MedicoReadDTO Create(MedicoCreateDTO dto);

        bool Update(int id, MedicoUpdateDTO dto);

        bool Delete(int id);
    }
}