using ClinicaApi.DTOs;
using ClinicaApi.Models;

namespace ClinicaApi.Interfaces
{
    public interface IMedicoMapper
    {
        Medico ToEntity(MedicoCreateDTO dto);

        MedicoReadDTO ToReadDTO(Medico medico);

        void UpdateEntity(Medico medico, MedicoUpdateDTO dto);
    }
}