using ApiAgenda.Models;
using Microsoft.EntityFrameworkCore;

namespace ApiAgenda.Context
{
    public class ApiAgendaDbContext : DbContext 
    {
        public ApiAgendaDbContext(DbContextOptions<ApiAgendaDbContext> options) : base(options) { }
        public DbSet<Paciente> Pacientes { get; set; }
        public DbSet<Profissional> Profissionais { get; set; }
        public DbSet<Consulta> Consultas { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }

    }
}
