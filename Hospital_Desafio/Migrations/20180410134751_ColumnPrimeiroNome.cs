using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace Hospital_Desafio.Migrations
{
    public partial class ColumnPrimeiroNome : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Primeiro Nome",
                table: "Medico");

            migrationBuilder.AlterColumn<string>(
                name: "PrimeiroNome",
                table: "Medico",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 50,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "NomeClinica",
                table: "Clinica",
                maxLength: 50,
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "PrimeiroNome",
                table: "Medico",
                maxLength: 50,
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 50);

            migrationBuilder.AddColumn<string>(
                name: "PrimeiroNome",
                table: "Medico",
                maxLength: 50,
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "NomeClinica",
                table: "Clinica",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 50,
                oldNullable: true);
        }
    }
}
