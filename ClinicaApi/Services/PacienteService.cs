using ClinicaApi.Data;
using ClinicaApi.DTOs;
using ClinicaApi.Interfaces;

namespace ClinicaApi.Services
{
    public class PacienteService : IPacienteService
    {
        private readonly AppDbContext _context;
        private readonly IPacienteMapper _mapper;

        public PacienteService(
            AppDbContext context,
            IPacienteMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public IEnumerable<PacienteReadDTO> GetAll()
        {
            return _context.Pacientes
                .Select(p => _mapper.ToReadDTO(p))
                .ToList();
        }

        public PacienteReadDTO GetById(int id)
        {
            var paciente = _context.Pacientes.Find(id);

            if (paciente == null)
                return null;

            return _mapper.ToReadDTO(paciente);
        }

        public PacienteReadDTO Create(PacienteCreateDTO dto)
        {
            var paciente = _mapper.ToEntity(dto);

            _context.Pacientes.Add(paciente);
            _context.SaveChanges();

            return _mapper.ToReadDTO(paciente);
        }

        public bool Update(int id, PacienteUpdateDTO dto)
        {
            var paciente = _context.Pacientes.Find(id);

            if (paciente == null)
                return false;

            _mapper.UpdateEntity(paciente, dto);

            _context.SaveChanges();

            return true;
        }

        public bool Delete(int id)
        {
            var paciente = _context.Pacientes.Find(id);

            if (paciente == null)
                return false;

            _context.Pacientes.Remove(paciente);

            _context.SaveChanges();

            return true;
        }
    }
}