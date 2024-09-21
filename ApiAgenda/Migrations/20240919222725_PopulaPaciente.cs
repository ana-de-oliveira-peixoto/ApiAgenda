using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ApiAgenda.Migrations
{
    /// <inheritdoc />
    public partial class PopulaPaciente : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder mb)
        {
            mb.Sql("Insert into Pacientes(Nome, DataNascimento, Telefone) Values('Ana Peixoto','1999-08-31', '123456789')");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder mb)
        {
            mb.Sql("Delete from Pacientes");
        }
    }
}
