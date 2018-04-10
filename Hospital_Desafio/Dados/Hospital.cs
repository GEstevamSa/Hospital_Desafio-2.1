using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Hospital_Desafio.Models;
using Microsoft.EntityFrameworkCore;

namespace Hospital_Desafio.Dados
{
    public class Hospital : DbContext
    {
        public Hospital(DbContextOptions<Hospital>options) : base(options)
        {
        }

        public DbSet<Medicos> Medicos { get; set; }
        public DbSet<Colecao> Colecaos { get; set; }
        public DbSet<Clinicas> Clinicas { get; set; }
        public DbSet<Departamento> Departamentos { get; set; }
        public DbSet<Supervisor> Supervisores { get; set; }
        public DbSet<TarefasInstrutor> TarefasInstrutors { get; set; }
        public DbSet<AtribuicaodeTarefas> AtribuicaodeTarefas { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Clinicas>().ToTable("Clinica");
            modelBuilder.Entity<Colecao>().ToTable("Colecao");
            modelBuilder.Entity<Medicos>().ToTable("Medico");
            modelBuilder.Entity<Departamento>().ToTable("Departamento");
            modelBuilder.Entity<Supervisor>().ToTable("Supervisor");
            modelBuilder.Entity<TarefasInstrutor>().ToTable("Tarefas");
            modelBuilder.Entity<AtribuicaodeTarefas>().ToTable("Atribuicoes");

            modelBuilder.Entity<AtribuicaodeTarefas>().HasKey(at => new { at.ClinicaID, at.SupervisorID });

        }
    }
}
