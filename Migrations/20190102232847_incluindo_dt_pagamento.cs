using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Gaditas.Migrations
{
    public partial class incluindo_dt_pagamento : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "DT_PAGAMENTO",
                table: "Pagamentos",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DT_PAGAMENTO",
                table: "Pagamentos");
        }
    }
}
