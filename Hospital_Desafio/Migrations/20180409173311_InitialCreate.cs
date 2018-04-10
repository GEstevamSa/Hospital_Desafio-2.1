using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace Hospital_Desafio.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Clinica",
                columns: table => new
                {
                    ClinicasID = table.Column<int>(nullable: false),
                    Estrelas = table.Column<int>(nullable: false),
                    NomeClinica = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clinica", x => x.ClinicasID);
                });

            migrationBuilder.CreateTable(
                name: "Medico",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ColecaoDate = table.Column<DateTime>(nullable: false),
                    PrimeiroNome = table.Column<string>(nullable: true),
                    Sobrenome = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Medico", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Colecao",
                columns: table => new
                {
                    ColecaoID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ClinicasID = table.Column<int>(nullable: false),
                    MedicosID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Colecao", x => x.ColecaoID);
                    table.ForeignKey(
                        name: "FK_Colecao_Clinica_ClinicasID",
                        column: x => x.ClinicasID,
                        principalTable: "Clinica",
                        principalColumn: "ClinicasID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Colecao_Medico_MedicosID",
                        column: x => x.MedicosID,
                        principalTable: "Medico",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Colecao_ClinicasID",
                table: "Colecao",
                column: "ClinicasID");

            migrationBuilder.CreateIndex(
                name: "IX_Colecao_MedicosID",
                table: "Colecao",
                column: "MedicosID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Colecao");

            migrationBuilder.DropTable(
                name: "Clinica");

            migrationBuilder.DropTable(
                name: "Medico");
        }
    }
}
