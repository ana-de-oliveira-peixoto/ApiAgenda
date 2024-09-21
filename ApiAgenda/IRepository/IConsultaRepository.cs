using ApiAgenda.Models;

namespace ApiAgenda.IRepository
{
    public interface IConsultaRepository
    {
        Task<Consulta> InserirAsync(Consulta consultaDto);
        Task<IEnumerable<Consulta>> ObterTodasAsync();
        Task<Consulta> ObterPorIdAsync(int id);
        Task AtualizarAsync(Consulta consultaDto);
        Task DeletarAsync(int id);
    }
}
