using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ApiAgenda.Migrations
{
    /// <inheritdoc />
    public partial class PopulaProfissional : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder mb)
        {
            mb.Sql("Insert into Profissionais(Nome, Especialidade, Email) Values('Retana Santos', 'Ginecologista', 'renatasantos@gmail.com')");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder mb)
        {
            mb.Sql("Detele from Profissionais");
        }
    }
}
