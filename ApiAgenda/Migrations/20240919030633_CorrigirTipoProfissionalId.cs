using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ApiAgenda.Migrations
{
    /// <inheritdoc />
    public partial class CorrigirTipoProfissionalId : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Consultas_Profissionais_ProfissionalId1",
                table: "Consultas");

            migrationBuilder.DropIndex(
                name: "IX_Consultas_ProfissionalId1",
                table: "Consultas");

            migrationBuilder.DropColumn(
                name: "ProfissionalId1",
                table: "Consultas");

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "Profissionais",
                type: "int",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint")
                .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn)
                .OldAnnotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn);

            migrationBuilder.CreateIndex(
                name: "IX_Consultas_ProfissionalId",
                table: "Consultas",
                column: "ProfissionalId");

            migrationBuilder.AddForeignKey(
                name: "FK_Consultas_Profissionais_ProfissionalId",
                table: "Consultas",
                column: "ProfissionalId",
                principalTable: "Profissionais",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Consultas_Profissionais_ProfissionalId",
                table: "Consultas");

            migrationBuilder.DropIndex(
                name: "IX_Consultas_ProfissionalId",
                table: "Consultas");

            migrationBuilder.AlterColumn<long>(
                name: "Id",
                table: "Profissionais",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn)
                .OldAnnotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn);

            migrationBuilder.AddColumn<long>(
                name: "ProfissionalId1",
                table: "Consultas",
                type: "bigint",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Consultas_ProfissionalId1",
                table: "Consultas",
                column: "ProfissionalId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Consultas_Profissionais_ProfissionalId1",
                table: "Consultas",
                column: "ProfissionalId1",
                principalTable: "Profissionais",
                principalColumn: "Id");
        }
    }
}
