namespace ClinicaApi.Models
{
    public class Consulta
    {
        public int Id { get; set; }

        public int PacienteId { get; set; }
        public Paciente Paciente { get; set; } = null!;

        public int MedicoId { get; set; }
        public Medico Medico { get; set; } = null!;

        public DateTime DataHora { get; set; }
    }
}