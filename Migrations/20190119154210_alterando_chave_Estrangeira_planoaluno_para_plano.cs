using Microsoft.EntityFrameworkCore.Migrations;

namespace Gaditas.Migrations
{
    public partial class alterando_chave_Estrangeira_planoaluno_para_plano : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Pagamentos_Planos_Alunos_ID_PLANO_ALUNO",
                table: "Pagamentos");

            migrationBuilder.RenameColumn(
                name: "ID_PLANO_ALUNO",
                table: "Pagamentos",
                newName: "ID_PLANO");

            migrationBuilder.RenameIndex(
                name: "IX_Pagamentos_ID_PLANO_ALUNO",
                table: "Pagamentos",
                newName: "IX_Pagamentos_ID_PLANO");

            migrationBuilder.AddForeignKey(
                name: "FK_Pagamentos_Planos_ID_PLANO",
                table: "Pagamentos",
                column: "ID_PLANO",
                principalTable: "Planos",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Pagamentos_Planos_ID_PLANO",
                table: "Pagamentos");

            migrationBuilder.RenameColumn(
                name: "ID_PLANO",
                table: "Pagamentos",
                newName: "ID_PLANO_ALUNO");

            migrationBuilder.RenameIndex(
                name: "IX_Pagamentos_ID_PLANO",
                table: "Pagamentos",
                newName: "IX_Pagamentos_ID_PLANO_ALUNO");

            migrationBuilder.AddForeignKey(
                name: "FK_Pagamentos_Planos_Alunos_ID_PLANO_ALUNO",
                table: "Pagamentos",
                column: "ID_PLANO_ALUNO",
                principalTable: "Planos_Alunos",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
