namespace ClinicaApi.DTOs
{
    public class PacienteUpdateDTO
    {
        public string? Nome { get; set; }
        public string? Email { get; set; }
        public string? Telefone { get; set; }
        public DateTime? DataNasc { get; set; }
    }
}