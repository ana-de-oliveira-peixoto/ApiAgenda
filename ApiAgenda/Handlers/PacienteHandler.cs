using ApiAgenda.Models;
using ApiAgenda.Repository;
using Microsoft.AspNetCore.Mvc;

namespace ApiAgenda.Handler
{
    public class PacienteHandler
    {
        private readonly IPacienteRepository _repository;

        public PacienteHandler(IPacienteRepository repository)
        {
            _repository = repository;
        }

        public async Task<Paciente> CriarPacienteAsync(Paciente paciente)
        {
            return await _repository.InserirAsync(paciente);
        }

        public async Task<IEnumerable<Paciente>> ObterTodosAsync()
        {
            return await _repository.ObterTodosAsync();
        }

        public async Task<Paciente?> ObterPorIdAsync(int id)
        {
            return await _repository.ObterPorIdAsync(id);
        }

        public async Task AtualizarPacienteAsync(Paciente paciente)
        {
            await _repository.AtualizarAsync(paciente);
        }

        public async Task DeletarPacienteAsync(int id)
        {
            await _repository.DeletarAsync(id);
        }

    }
}