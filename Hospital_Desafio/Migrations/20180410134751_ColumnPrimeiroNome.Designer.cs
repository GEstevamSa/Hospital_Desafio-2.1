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
    [Migration("20180410134751_ColumnPrimeiroNome")]
    partial class ColumnPrimeiroNome
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.0.2-rtm-10011")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Hospital_Desafio.Models.Clinicas", b =>
                {
                    b.Property<int>("ClinicasID");

                    b.Property<int>("Estrelas");

                    b.Property<string>("NomeClinica")
                        .HasMaxLength(50);

                    b.HasKey("ClinicasID");

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

            modelBuilder.Entity("Hospital_Desafio.Models.Medicos", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("ColecaoDate");

                    b.Property<string>("PrimeiroNome")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<string>("Sobrenome")
                        .IsRequired()
                        .HasColumnName("PrimeiroNome")
                        .HasMaxLength(50);

                    b.HasKey("ID");

                    b.ToTable("Medico");
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
#pragma warning restore 612, 618
        }
    }
}
