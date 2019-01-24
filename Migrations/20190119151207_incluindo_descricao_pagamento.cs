using Microsoft.EntityFrameworkCore.Migrations;

namespace Gaditas.Migrations
{
    public partial class incluindo_descricao_pagamento : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "DESCRICAO",
                table: "Pagamentos",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DESCRICAO",
                table: "Pagamentos");
        }
    }
}
