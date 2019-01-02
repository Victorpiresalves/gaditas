using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Gaditas.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Alunos",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    NOME_COMPLETO = table.Column<string>(maxLength: 150, nullable: false),
                    DT_NASCIMENTO = table.Column<DateTime>(nullable: false),
                    CPF = table.Column<string>(maxLength: 14, nullable: false),
                    RG = table.Column<string>(maxLength: 12, nullable: false),
                    DT_CADASTRO = table.Column<DateTime>(nullable: false),
                    DT_ATUALIZACAO = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Alunos", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Modalidades",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    NOME = table.Column<string>(maxLength: 50, nullable: false),
                    ATIVO = table.Column<bool>(nullable: false),
                    DT_CADASTRO = table.Column<DateTime>(nullable: false),
                    DT_ATUALIZACAO = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Modalidades", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Planos",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    NOME = table.Column<string>(maxLength: 150, nullable: false),
                    VALOR = table.Column<decimal>(nullable: false),
                    QTD_MESES = table.Column<int>(nullable: false),
                    DT_CADASTRO = table.Column<DateTime>(nullable: false),
                    DT_ATUALIZACAO = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Planos", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Modalidades_Alunos",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ID_ALUNO = table.Column<int>(nullable: false),
                    ID_MODALIDADE = table.Column<int>(nullable: false),
                    DT_CADASTRO = table.Column<DateTime>(nullable: false),
                    DT_ATUALIZACAO = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Modalidades_Alunos", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Modalidades_Alunos_Alunos_ID_ALUNO",
                        column: x => x.ID_ALUNO,
                        principalTable: "Alunos",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Modalidades_Alunos_Modalidades_ID_MODALIDADE",
                        column: x => x.ID_MODALIDADE,
                        principalTable: "Modalidades",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Planos_Alunos",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ID_ALUNO = table.Column<int>(nullable: false),
                    ID_PLANO = table.Column<int>(nullable: false),
                    DT_INICIO = table.Column<DateTime>(nullable: false),
                    DT_CADASTRO = table.Column<DateTime>(nullable: false),
                    DT_ATUALIZACAO = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Planos_Alunos", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Planos_Alunos_Alunos_ID_ALUNO",
                        column: x => x.ID_ALUNO,
                        principalTable: "Alunos",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Planos_Alunos_Planos_ID_PLANO",
                        column: x => x.ID_PLANO,
                        principalTable: "Planos",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Pagamentos",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ID_ALUNO = table.Column<int>(nullable: false),
                    ID_PLANO_ALUNO = table.Column<int>(nullable: false),
                    VALOR = table.Column<decimal>(nullable: false),
                    NUM_PARCELA = table.Column<int>(nullable: false),
                    QTD_TOTAL_PARCELA = table.Column<int>(nullable: false),
                    DT_VENCIMENTO = table.Column<DateTime>(nullable: false),
                    DT_CADASTRO = table.Column<DateTime>(nullable: false),
                    DT_ATUALIZACAO = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pagamentos", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Pagamentos_Alunos_ID_ALUNO",
                        column: x => x.ID_ALUNO,
                        principalTable: "Alunos",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Pagamentos_Planos_Alunos_ID_PLANO_ALUNO",
                        column: x => x.ID_PLANO_ALUNO,
                        principalTable: "Planos_Alunos",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Modalidades_Alunos_ID_ALUNO",
                table: "Modalidades_Alunos",
                column: "ID_ALUNO");

            migrationBuilder.CreateIndex(
                name: "IX_Modalidades_Alunos_ID_MODALIDADE",
                table: "Modalidades_Alunos",
                column: "ID_MODALIDADE");

            migrationBuilder.CreateIndex(
                name: "IX_Pagamentos_ID_ALUNO",
                table: "Pagamentos",
                column: "ID_ALUNO");

            migrationBuilder.CreateIndex(
                name: "IX_Pagamentos_ID_PLANO_ALUNO",
                table: "Pagamentos",
                column: "ID_PLANO_ALUNO");

            migrationBuilder.CreateIndex(
                name: "IX_Planos_Alunos_ID_ALUNO",
                table: "Planos_Alunos",
                column: "ID_ALUNO");

            migrationBuilder.CreateIndex(
                name: "IX_Planos_Alunos_ID_PLANO",
                table: "Planos_Alunos",
                column: "ID_PLANO");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Modalidades_Alunos");

            migrationBuilder.DropTable(
                name: "Pagamentos");

            migrationBuilder.DropTable(
                name: "Modalidades");

            migrationBuilder.DropTable(
                name: "Planos_Alunos");

            migrationBuilder.DropTable(
                name: "Alunos");

            migrationBuilder.DropTable(
                name: "Planos");
        }
    }
}
