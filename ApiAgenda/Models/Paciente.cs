using System.Collections.ObjectModel;

namespace ApiAgenda.Models
{
    public class Paciente
    {
        public Paciente()
        {
            Consulta = new Collection<Consulta>();
        }
        public int Id { get; set; }
        public string Nome { get; set; } = string.Empty;
        public string DataNascimento { get; set; }
        public string Telefone { get; set; } = string.Empty;
        public ICollection<Consulta>? Consulta { get; set; }

    }
}
