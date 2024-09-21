using ApiAgenda.Context;
using ApiAgenda.IRepository;
using ApiAgenda.Models;
using Microsoft.EntityFrameworkCore;

namespace ApiAgenda.Repository
{
    public class ConsultaRepository : IConsultaRepository
    {
        private ApiAgendaDbContext _context;

        public ConsultaRepository(ApiAgendaDbContext context)
        {
            _context = context;
        }

        public async Task<Consulta> InserirAsync(Consulta Consulta)
        {
            var consulta = new Consulta
            {
                PacienteId = Consulta.PacienteId,
                ProfissionalId = Consulta.ProfissionalId,
                DataHora = Consulta.DataHora,
                Status = "Agendada"
            };

            _context.Consultas.Add(consulta);
            await _context.SaveChangesAsync();

            Consulta.Id = consulta.Id;
            return Consulta;
        }

        public async Task<IEnumerable<Consulta>> ObterTodasAsync()
        {
            return await _context.Consultas
                .Select(c => new Consulta
                {
                    Id = c.Id,
                    PacienteId = c.PacienteId,
                    ProfissionalId = c.ProfissionalId,
                    DataHora = c.DataHora,
                    Status = c.Status
                })
                .ToListAsync();
        }

        public async Task<Consulta> ObterPorIdAsync(int id)
        {
            var consulta = await _context.Consultas.FindAsync(id);

            if (consulta == null) return null;

            return new Consulta
            {
                Id = consulta.Id,
                PacienteId = consulta.PacienteId,
                ProfissionalId = consulta.ProfissionalId,
                DataHora = consulta.DataHora,
                Status = consulta.Status
            };
        }

        public async Task AtualizarAsync(Consulta Consulta)
        {
            var consulta = await _context.Consultas.FindAsync(Consulta.Id);

            if (consulta == null) return;

            consulta.PacienteId = Consulta.PacienteId;
            consulta.ProfissionalId = Consulta.ProfissionalId;
            consulta.DataHora = Consulta.DataHora;
            consulta.Status = Consulta.Status;

            _context.Consultas.Update(consulta);
            await _context.SaveChangesAsync();
        }

        public async Task DeletarAsync(int id)
        {
            var consulta = await _context.Consultas.FindAsync(id);

            if (consulta != null)
            {
                _context.Consultas.Remove(consulta);
                await _context.SaveChangesAsync();
            }
        }
    }
}
