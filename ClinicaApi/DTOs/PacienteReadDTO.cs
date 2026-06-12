namespace ClinicaApi.DTOs
{
    public class PacienteReadDTO
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Telefone { get; set; }
        public DateTime DataNasc { get; set; }
        public string Cpf { get; set; }
    }
}