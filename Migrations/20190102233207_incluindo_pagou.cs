using Microsoft.EntityFrameworkCore.Migrations;

namespace Gaditas.Migrations
{
    public partial class incluindo_pagou : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "PAGOU",
                table: "Pagamentos",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PAGOU",
                table: "Pagamentos");
        }
    }
}
