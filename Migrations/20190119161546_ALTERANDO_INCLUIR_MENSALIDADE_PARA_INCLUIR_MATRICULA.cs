using Microsoft.EntityFrameworkCore.Migrations;

namespace Gaditas.Migrations
{
    public partial class ALTERANDO_INCLUIR_MENSALIDADE_PARA_INCLUIR_MATRICULA : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "INCLUIR_MENSALIDADE",
                table: "Planos_Alunos",
                newName: "INCLUIR_MATRICULA");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "INCLUIR_MATRICULA",
                table: "Planos_Alunos",
                newName: "INCLUIR_MENSALIDADE");
        }
    }
}
