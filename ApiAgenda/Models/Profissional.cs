using System.Collections.ObjectModel;

namespace ApiAgenda.Models
{
    public class Profissional
    {
        public Profissional()
        { 
            Consulta = new Collection<Consulta>();        
        }
        public int Id { get; set; }
        public string Nome { get; set; } = string.Empty;
        public string Especialidade { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty ;     
        public ICollection<Consulta>? Consulta { get; set; }
    }
}
