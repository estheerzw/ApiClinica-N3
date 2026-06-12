using ClinicaApi.Data;
using ClinicaApi.DTOs;
using ClinicaApi.Interfaces;

namespace ClinicaApi.Services
{
    public class MedicoService : IMedicoService
    {
        private readonly AppDbContext _context;
        private readonly IMedicoMapper _mapper;

        public MedicoService(
            AppDbContext context,
            IMedicoMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public IEnumerable<MedicoReadDTO> GetAll()
        {
            return _context.Medicos
                .Select(m => _mapper.ToReadDTO(m))
                .ToList();
        }

        public MedicoReadDTO GetById(int id)
        {
            var medico = _context.Medicos.Find(id);

            if (medico == null)
                return null;

            return _mapper.ToReadDTO(medico);
        }

        public MedicoReadDTO Create(MedicoCreateDTO dto)
        {
            var medico = _mapper.ToEntity(dto);

            _context.Medicos.Add(medico);
            _context.SaveChanges();

            return _mapper.ToReadDTO(medico);
        }

        public bool Update(int id, MedicoUpdateDTO dto)
        {
            var medico = _context.Medicos.Find(id);

            if (medico == null)
                return false;

            _mapper.UpdateEntity(medico, dto);

            _context.SaveChanges();

            return true;
        }

        public bool Delete(int id)
        {
            var medico = _context.Medicos.Find(id);

            if (medico == null)
                return false;

            _context.Medicos.Remove(medico);

            _context.SaveChanges();

            return true;
        }
    }
}