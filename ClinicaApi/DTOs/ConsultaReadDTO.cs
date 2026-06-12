namespace ClinicaApi.DTOs
{
    public class ConsultaReadDTO
    {
        public int Id { get; set; }
        public int PacienteId { get; set; }
        public string NomePaciente { get; set; } = string.Empty;
        public int MedicoId { get; set; }
        public string NomeMedico { get; set; } = string.Empty;
        public DateTime DataHora { get; set; }
    }
}