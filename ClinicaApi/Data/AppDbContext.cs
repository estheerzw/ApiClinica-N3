using Microsoft.EntityFrameworkCore;
using ClinicaApi.Models;

namespace ClinicaApi.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        public DbSet<Paciente> Pacientes { get; set; }

        public DbSet<Medico> Medicos { get; set; }

        public DbSet<Consulta> Consultas { get; set; }

        public DbSet<Usuario> Usuarios { get; set; }
    }
}