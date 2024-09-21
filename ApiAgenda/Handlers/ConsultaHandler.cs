using ApiAgenda.IRepository;
using ApiAgenda.Models;

namespace ApiAgenda.Handler
{
    public class ConsultaHandler
    {
        private readonly IConsultaRepository _repository;

        public ConsultaHandler(IConsultaRepository consultaRepository)
        {
            _repository = consultaRepository;
        }

        public async Task<Consulta> AgendarConsultaAsync(Consulta Consulta)
        {
            return await _repository.InserirAsync(Consulta);
        }

        public async Task<IEnumerable<Consulta>> ListarConsultasAsync()
        {
            return await _repository.ObterTodasAsync();
        }

        public async Task<Consulta> ObterConsultaPorIdAsync(int id)
        {
            return await _repository.ObterPorIdAsync(id);
        }

        public async Task AlterarConsultaAsync(Consulta Consulta)
        {
            await _repository.AtualizarAsync(Consulta);
        }

        public async Task CancelarConsultaAsync(int id)
        {
            await _repository.DeletarAsync(id);
        }
    }
}
