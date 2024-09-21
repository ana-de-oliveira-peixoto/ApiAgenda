using ApiAgenda.IRepository;
using ApiAgenda.Models;
using ApiAgenda.Repository;

namespace ApiAgenda.Handler
{
    public class ProfissionalHandler
    {
        private readonly IProfissionalRepository _repository;

        public ProfissionalHandler(IProfissionalRepository repository)
        {
            _repository = repository;
        }
        public async Task<Profissional> CriarProfissionalAsync(Profissional profissional)
        {
            return await _repository.InserirAsync(profissional);
        }

        public async Task<IEnumerable<Profissional>> ObterTodosAsync()
        {
            return await _repository.ObterTodosAsync();
        }

        public async Task<Profissional?> ObterPorIdAsync(int id)
        {
            return await _repository.ObterPorIdAsync(id);
        }

        public async Task AtualizarProfissionalAsync(Profissional profissional)
        {
            await _repository.AtualizarAsync(profissional);
        }

        public async Task DeletarProfissionalAsync(int id)
        {
            await _repository.DeletarAsync(id);
        }

    }
}
