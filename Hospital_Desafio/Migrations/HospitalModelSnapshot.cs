﻿// <auto-generated />
using Hospital_Desafio.Dados;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.Storage.Internal;
using System;

namespace Hospital_Desafio.Migrations
{
    [DbContext(typeof(Hospital))]
    partial class HospitalModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.0.2-rtm-10011")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Hospital_Desafio.Models.AtribuicaodeTarefas", b =>
                {
                    b.Property<int>("ClinicaID");

                    b.Property<int>("SupervisorID");

                    b.Property<int?>("ClinicasID");

                    b.HasKey("ClinicaID", "SupervisorID");

                    b.HasIndex("ClinicasID");

                    b.HasIndex("SupervisorID");

                    b.ToTable("Atribuicoes");
                });

            modelBuilder.Entity("Hospital_Desafio.Models.Clinicas", b =>
                {
                    b.Property<int>("ClinicasID");

                    b.Property<int?>("ClinicasID");

                    b.Property<int>("DepartamentoID");

                    b.Property<int>("Estrelas");

                    b.Property<string>("NomeClinica")
                        .HasMaxLength(50);

                    b.HasKey("ClinicasID");

                    b.HasIndex("ClinicasID");

                    b.HasIndex("DepartamentoID");

                    b.ToTable("Clinica");
                });

            modelBuilder.Entity("Hospital_Desafio.Models.Colecao", b =>
                {
                    b.Property<int>("ColecaoID")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("ClinicasID");

                    b.Property<int>("MedicosID");

                    b.HasKey("ColecaoID");

                    b.HasIndex("ClinicasID");

                    b.HasIndex("MedicosID");

                    b.ToTable("Colecao");
                });

            modelBuilder.Entity("Hospital_Desafio.Models.Departamento", b =>
                {
                    b.Property<int>("DepartamentoID")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("DataInicio");

                    b.Property<decimal>("Despesas")
                        .HasColumnType("Dinheiro");

                    b.Property<string>("Nome")
                        .HasMaxLength(50);

                    b.Property<int?>("SupervisorID");

                    b.HasKey("DepartamentoID");

                    b.HasIndex("SupervisorID");

                    b.ToTable("Departamento");
                });

            modelBuilder.Entity("Hospital_Desafio.Models.Medicos", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("ColecaoDate");

                    b.Property<string>("PrimeiroNome")
                        .HasMaxLength(50);

                    b.Property<string>("Sobrenome")
                        .IsRequired()
                        .HasColumnName("Sobrenome")
                        .HasMaxLength(50);

                    b.HasKey("ID");

                    b.ToTable("Medico");
                });

            modelBuilder.Entity("Hospital_Desafio.Models.Supervisor", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("Experiencia");

                    b.Property<string>("FirstMidName")
                        .IsRequired()
                        .HasColumnName("PrimeiroNome")
                        .HasMaxLength(50);

                    b.Property<string>("Sobrenome")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.HasKey("ID");

                    b.ToTable("Supervisor");
                });

            modelBuilder.Entity("Hospital_Desafio.Models.TarefasInstrutor", b =>
                {
                    b.Property<int>("SupervisorID");

                    b.Property<string>("Lugar")
                        .HasMaxLength(50);

                    b.HasKey("SupervisorID");

                    b.ToTable("Tarefas");
                });

            modelBuilder.Entity("Hospital_Desafio.Models.AtribuicaodeTarefas", b =>
                {
                    b.HasOne("Hospital_Desafio.Models.Clinicas", "Clinicas")
                        .WithMany()
                        .HasForeignKey("ClinicasID");

                    b.HasOne("Hospital_Desafio.Models.Supervisor", "Supervisor")
                        .WithMany("AtribuicaodeTarefas")
                        .HasForeignKey("SupervisorID")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Hospital_Desafio.Models.Clinicas", b =>
                {
                    b.HasOne("Hospital_Desafio.Models.Clinicas")
                        .WithMany("Clinica")
                        .HasForeignKey("ClinicasID");

                    b.HasOne("Hospital_Desafio.Models.Departamento", "Departamento")
                        .WithMany("Clinicas")
                        .HasForeignKey("DepartamentoID")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Hospital_Desafio.Models.Colecao", b =>
                {
                    b.HasOne("Hospital_Desafio.Models.Clinicas", "Clinicas")
                        .WithMany("Colecaos")
                        .HasForeignKey("ClinicasID")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Hospital_Desafio.Models.Medicos", "Medicos")
                        .WithMany("Colecaos")
                        .HasForeignKey("MedicosID")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Hospital_Desafio.Models.Departamento", b =>
                {
                    b.HasOne("Hospital_Desafio.Models.Supervisor", "Adm")
                        .WithMany()
                        .HasForeignKey("SupervisorID");
                });

            modelBuilder.Entity("Hospital_Desafio.Models.TarefasInstrutor", b =>
                {
                    b.HasOne("Hospital_Desafio.Models.Supervisor", "Supervisor")
                        .WithOne("TarefasInstrutor")
                        .HasForeignKey("Hospital_Desafio.Models.TarefasInstrutor", "SupervisorID")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
