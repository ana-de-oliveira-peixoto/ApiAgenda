using ApiAgenda.Models;

namespace ApiAgenda.Repository
{
    public interface IPacienteRepository
    {
        Task<Paciente> InserirAsync(Paciente paciente);
        Task<IEnumerable<Paciente>> ObterTodosAsync();
        Task<Paciente?> ObterPorIdAsync(int id);
        Task AtualizarAsync(Paciente pacienteDto);
        Task DeletarAsync(int id);
    }
}
