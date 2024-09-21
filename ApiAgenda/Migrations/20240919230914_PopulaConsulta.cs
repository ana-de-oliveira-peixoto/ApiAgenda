using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ApiAgenda.Migrations
{
    /// <inheritdoc />
    public partial class PopulaConsulta : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder mb)
        {
            mb.Sql("Insert into Consultas(DataHora, Status, PacienteId, ProfissionalId) Values('2024-09-21 14:30:00', 0,1,1)");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder mb)
        {
            mb.Sql("Delete into Consultas");
        }
    }
}
