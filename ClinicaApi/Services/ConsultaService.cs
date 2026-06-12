using ClinicaApi.Data;
using ClinicaApi.DTOs;
using ClinicaApi.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace ClinicaApi.Services
{
    public class ConsultaService : IConsultaService
    {
        private readonly AppDbContext _context;
        private readonly IConsultaMapper _mapper;

        public ConsultaService(
            AppDbContext context,
            IConsultaMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public IEnumerable<ConsultaReadDTO> GetAll()
        {
            return _context.Consultas
                .Include(c => c.Paciente)
                .Include(c => c.Medico)
                .ToList()
                .Select(c => _mapper.ToReadDTO(c));
        }

        public ConsultaReadDTO GetById(int id)
        {
            var consulta = _context.Consultas
                .Include(c => c.Paciente)
                .Include(c => c.Medico)
                .FirstOrDefault(c => c.Id == id);

            if (consulta == null)
                return null;

            return _mapper.ToReadDTO(consulta);
        }

        public ConsultaReadDTO Create(ConsultaCreateDTO dto)
        {
            var consulta = _mapper.ToEntity(dto);

            _context.Consultas.Add(consulta);
            _context.SaveChanges();

            consulta = _context.Consultas
                .Include(c => c.Paciente)
                .Include(c => c.Medico)
                .First(c => c.Id == consulta.Id);

            return _mapper.ToReadDTO(consulta);
        }

        public bool Update(int id, ConsultaUpdateDTO dto)
        {
            var consulta = _context.Consultas.Find(id);

            if (consulta == null)
                return false;

            _mapper.UpdateEntity(consulta, dto);

            _context.SaveChanges();

            return true;
        }

        public bool Delete(int id)
        {
            var consulta = _context.Consultas.Find(id);

            if (consulta == null)
                return false;

            _context.Consultas.Remove(consulta);

            _context.SaveChanges();

            return true;
        }
    }
}