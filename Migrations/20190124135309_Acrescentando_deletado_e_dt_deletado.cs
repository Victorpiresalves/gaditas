using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Gaditas.Migrations
{
    public partial class Acrescentando_deletado_e_dt_deletado : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "DELETADO",
                table: "Planos_Alunos",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "DT_DELETADO",
                table: "Planos_Alunos",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "DELETADO",
                table: "Planos",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "DT_DELETADO",
                table: "Planos",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "DELETADO",
                table: "Pagamentos",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "DT_DELETADO",
                table: "Pagamentos",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "DELETADO",
                table: "Modalidades_Alunos",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "DT_DELETADO",
                table: "Modalidades_Alunos",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "DELETADO",
                table: "Modalidades",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "DT_DELETADO",
                table: "Modalidades",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "DELETADO",
                table: "Alunos",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "DT_DELETADO",
                table: "Alunos",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DELETADO",
                table: "Planos_Alunos");

            migrationBuilder.DropColumn(
                name: "DT_DELETADO",
                table: "Planos_Alunos");

            migrationBuilder.DropColumn(
                name: "DELETADO",
                table: "Planos");

            migrationBuilder.DropColumn(
                name: "DT_DELETADO",
                table: "Planos");

            migrationBuilder.DropColumn(
                name: "DELETADO",
                table: "Pagamentos");

            migrationBuilder.DropColumn(
                name: "DT_DELETADO",
                table: "Pagamentos");

            migrationBuilder.DropColumn(
                name: "DELETADO",
                table: "Modalidades_Alunos");

            migrationBuilder.DropColumn(
                name: "DT_DELETADO",
                table: "Modalidades_Alunos");

            migrationBuilder.DropColumn(
                name: "DELETADO",
                table: "Modalidades");

            migrationBuilder.DropColumn(
                name: "DT_DELETADO",
                table: "Modalidades");

            migrationBuilder.DropColumn(
                name: "DELETADO",
                table: "Alunos");

            migrationBuilder.DropColumn(
                name: "DT_DELETADO",
                table: "Alunos");
        }
    }
}
