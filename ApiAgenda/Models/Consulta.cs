namespace ApiAgenda.Models
{
    public class Consulta
    {
        public int Id { get; set; }
        public DateTime DataHora { get; set; }
        public string Status { get; set; } = string.Empty;
        public int PacienteId { get; set; }
        public int ProfissionalId { get; set;}
        public Paciente? Paciente { get; set; }
        public Profissional? Profissional { get; set; }


    }
}
