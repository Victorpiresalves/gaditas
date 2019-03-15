using Microsoft.EntityFrameworkCore.Migrations;

namespace Gaditas.Migrations
{
    public partial class incluir_mensalidade_plano : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "INCLUIR_MENSALIDADE",
                table: "Planos_Alunos",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "INCLUIR_MENSALIDADE",
                table: "Planos_Alunos");
        }
    }
}
