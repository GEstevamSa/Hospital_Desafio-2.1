using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace Hospital_Desafio.Migrations
{
    public partial class ComplexDataModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "PrimeiroNome",
                table: "Medico",
                maxLength: 50,
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 50);

            migrationBuilder.AddColumn<string>(
                name: "Sobrenome",
                table: "Medico",
                maxLength: 50,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "ClinicasID",
                table: "Clinica",
                nullable: true);

            //usado mais abaixo na criacao da tabela departamento
            //migrationBuilder.AddColumn<int>( 
                //name: "DepartamentoID",
                //table: "Clinica",
                //nullable: false,
                //defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Supervisor",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Experiencia = table.Column<DateTime>(nullable: false),
                    PrimeiroNome = table.Column<string>(maxLength: 50, nullable: false),
                    Sobrenome = table.Column<string>(maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Supervisor", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Atribuicoes",
                columns: table => new
                {
                    ClinicaID = table.Column<int>(nullable: false),
                    SupervisorID = table.Column<int>(nullable: false),
                    ClinicasID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Atribuicoes", x => new { x.ClinicaID, x.SupervisorID });
                    table.ForeignKey(
                        name: "FK_Atribuicoes_Clinica_ClinicasID",
                        column: x => x.ClinicasID,
                        principalTable: "Clinica",
                        principalColumn: "ClinicasID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Atribuicoes_Supervisor_SupervisorID",
                        column: x => x.SupervisorID,
                        principalTable: "Supervisor",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Departamento",
                columns: table => new
                {
                    DepartamentoID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    DataInicio = table.Column<DateTime>(nullable: false),
                    Despesas = table.Column<decimal>(type: "Dinheiro", nullable: false),
                    Nome = table.Column<string>(maxLength: 50, nullable: true),
                    SupervisorID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Departamento", x => x.DepartamentoID);
                    table.ForeignKey(
                        name: "FK_Departamento_Supervisor_SupervisorID",
                        column: x => x.SupervisorID,
                        principalTable: "Supervisor",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.Sql("INSERT INTO dbo.Department (Nome, Despesas, DataInicio) VALUES ('Temp', 0.00, GETDATE())");
            // Default value for FK points to department created above, with
            // defaultValue changed to 1 in following AddColumn statement.

            migrationBuilder.AddColumn<int>(
                name: "DepartmentoID",
                table: "Clinica",
                nullable: false,
                defaultValue: 1);

            migrationBuilder.CreateTable(
                name: "Tarefas",
                columns: table => new
                {
                    SupervisorID = table.Column<int>(nullable: false),
                    Lugar = table.Column<string>(maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tarefas", x => x.SupervisorID);
                    table.ForeignKey(
                        name: "FK_Tarefas_Supervisor_SupervisorID",
                        column: x => x.SupervisorID,
                        principalTable: "Supervisor",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Clinica_ClinicasID",
                table: "Clinica",
                column: "ClinicasID");

            migrationBuilder.CreateIndex(
                name: "IX_Clinica_DepartamentoID",
                table: "Clinica",
                column: "DepartamentoID");

            migrationBuilder.CreateIndex(
                name: "IX_Atribuicoes_ClinicasID",
                table: "Atribuicoes",
                column: "ClinicasID");

            migrationBuilder.CreateIndex(
                name: "IX_Atribuicoes_SupervisorID",
                table: "Atribuicoes",
                column: "SupervisorID");

            migrationBuilder.CreateIndex(
                name: "IX_Departamento_SupervisorID",
                table: "Departamento",
                column: "SupervisorID");

            migrationBuilder.AddForeignKey(
                name: "FK_Clinica_Clinica_ClinicasID",
                table: "Clinica",
                column: "ClinicasID",
                principalTable: "Clinica",
                principalColumn: "ClinicasID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Clinica_Departamento_DepartamentoID",
                table: "Clinica",
                column: "DepartamentoID",
                principalTable: "Departamento",
                principalColumn: "DepartamentoID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Clinica_Clinica_ClinicasID",
                table: "Clinica");

            migrationBuilder.DropForeignKey(
                name: "FK_Clinica_Departamento_DepartamentoID",
                table: "Clinica");

            migrationBuilder.DropTable(
                name: "Atribuicoes");

            migrationBuilder.DropTable(
                name: "Departamento");

            migrationBuilder.DropTable(
                name: "Tarefas");

            migrationBuilder.DropTable(
                name: "Supervisor");

            migrationBuilder.DropIndex(
                name: "IX_Clinica_ClinicasID",
                table: "Clinica");

            migrationBuilder.DropIndex(
                name: "IX_Clinica_DepartamentoID",
                table: "Clinica");

            migrationBuilder.DropColumn(
                name: "Sobrenome",
                table: "Medico");

            migrationBuilder.DropColumn(
                name: "ClinicasID",
                table: "Clinica");

            migrationBuilder.DropColumn(
                name: "DepartamentoID",
                table: "Clinica");

            migrationBuilder.AlterColumn<string>(
                name: "PrimeiroNome",
                table: "Medico",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 50,
                oldNullable: true);
        }
    }
}
