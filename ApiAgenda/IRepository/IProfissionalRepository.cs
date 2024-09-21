using ApiAgenda.Models;

namespace ApiAgenda.IRepository
{
    public interface IProfissionalRepository
    {
        Task<Profissional> InserirAsync(Profissional profissionalDTO);
        Task<IEnumerable<Profissional>> ObterTodosAsync();
        Task<Profissional?> ObterPorIdAsync(int id);
        Task AtualizarAsync(Profissional profissional);
        Task DeletarAsync(int id);
    }
}
