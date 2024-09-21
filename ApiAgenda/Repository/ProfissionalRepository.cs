using ApiAgenda.Context;
using ApiAgenda.IRepository;
using ApiAgenda.Models;
using Microsoft.EntityFrameworkCore;

namespace ApiAgenda.Repository
{
    public class ProfissionalRepository : IProfissionalRepository
    {
        private ApiAgendaDbContext _context;

        public ProfissionalRepository(ApiAgendaDbContext context)
        {
            _context = context;
        }
        public async Task<Profissional> InserirAsync(Profissional profissionalDto)
        {
            var profissional= new Profissional
            {
                Nome = profissionalDto.Nome,
                Especialidade = profissionalDto.Especialidade,
                Email = profissionalDto.Email,
                
            };
            _context.Profissionais.Add(profissional);
            _context.SaveChanges();
            return profissional;
        }
        public async Task<IEnumerable<Profissional>> ObterTodosAsync()
        {
            return await _context.Profissionais
            .Select(p => new Profissional
            {
                Id = p.Id,
                Nome = p.Nome,
                Especialidade= p.Especialidade,
                Email = p.Email
                
            }).ToListAsync();
            
        }
        public async Task<Profissional> ObterPorIdAsync(int id)
        {
            var profissional = await _context.Profissionais.FindAsync(id);

            if (profissional == null) return null;

            return new Profissional
            {
                Id = profissional.Id,
                Nome = profissional.Nome,
                Especialidade = profissional.Especialidade,
                Email = profissional.Email

            };
        }
        public async Task AtualizarAsync(Profissional profissionalDto)
        {
            var profissional = await _context.Profissionais.FindAsync(profissionalDto);
            if (profissional == null) return;

            profissional.Nome = profissionalDto.Nome;
            profissional.Especialidade = profissionalDto.Especialidade;
            profissional.Email = profissionalDto.Email;

            _context.Profissionais.Update(profissional);
            await _context.SaveChangesAsync();
        }
        public async Task DeletarAsync(int id)
        {
            var profissional = await _context.Profissionais.FindAsync(id);

            if (profissional != null)
            {
                _context.Profissionais.Remove(profissional);
                await _context.SaveChangesAsync();
            }
        }
    }
}
