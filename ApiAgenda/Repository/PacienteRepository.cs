using ApiAgenda.Context;
using ApiAgenda.Models;
using Microsoft.EntityFrameworkCore;

namespace ApiAgenda.Repository
{
    public class PacienteRepository : IPacienteRepository
    {
        private ApiAgendaDbContext _context;

        public PacienteRepository(ApiAgendaDbContext context)
        {
            _context = context;
        }
        public async Task<Paciente> InserirAsync(Paciente pacienteDto)
        {
            var paciente = new Paciente
            {
                Nome = pacienteDto.Nome,
                DataNascimento = pacienteDto.DataNascimento,
                Telefone = pacienteDto.Telefone
            };
            _context.Pacientes.Add(paciente);
            _context.SaveChanges();
            return paciente;
        }
        public async Task<IEnumerable<Paciente>> ObterTodosAsync()
        {
            return await _context.Pacientes
            .Select(p => new Paciente
            {
                Id = p.Id,
                Nome = p.Nome,
                DataNascimento = p.DataNascimento,
                Telefone = p.Telefone
            })
            .ToListAsync();
        }
        public async Task<Paciente?> ObterPorIdAsync(int id)
        {
            var paciente = await _context.Pacientes.FindAsync(id);

            if (paciente == null) return null;

            return new Paciente
            {
                Id = paciente.Id,
                Nome = paciente.Nome,
                DataNascimento = paciente.DataNascimento,
                Telefone= paciente.Telefone
            };
        }
        public async Task AtualizarAsync(Paciente pacienteDto)
        {
            var paciente = await _context.Pacientes.FindAsync(pacienteDto);
            if (paciente == null) return;

            paciente.Nome = pacienteDto.Nome;
            paciente.DataNascimento = pacienteDto.DataNascimento;
            paciente.Telefone = pacienteDto.Telefone;

            _context.Pacientes.Update(paciente);
            await _context.SaveChangesAsync();
        }
        public async Task DeletarAsync(int id)
        {
            var paciente = await _context.Pacientes.FindAsync(id);

            if (paciente != null)
            {
                _context.Pacientes.Remove(paciente);
                await _context.SaveChangesAsync();
            }
        }
    }
}
