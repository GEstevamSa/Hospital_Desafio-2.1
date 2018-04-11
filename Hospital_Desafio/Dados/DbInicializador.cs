using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Hospital_Desafio.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;


namespace Hospital_Desafio.Dados
{
    public class DbInicializador
    {
        public static void Inicializador(Hospital hospital)
        {
            hospital.Database.EnsureCreated();

            //Procura por novos medicos
            if (hospital.Medicos.Any())
            {
                return;
            }

            var medicos = new Medicos[]
            {
                new Medicos{PrimeiroNome = "Guilherme",Sobrenome = "Estevam",ColecaoDate = DateTime.Parse("1996-04-01")},
                new Medicos{PrimeiroNome = "Geovana", Sobrenome = "Pazini",ColecaoDate = DateTime.Parse("1995-02-24")},
                new Medicos{PrimeiroNome = "Joselito",Sobrenome ="dos Santos",ColecaoDate = DateTime.Parse("1988-01-30")}
            };

            foreach (Medicos m in medicos)
            {
                hospital.Medicos.Add(m);
            }

            hospital.SaveChanges();

            var supervisor = new Supervisor[]
           {
                new Supervisor{Sobrenome= "kakarotto", PrimeiroNome = "Goku", Experiencia = DateTime.Parse("2000-10-25")},
                new Supervisor{Sobrenome = "Saiyan", PrimeiroNome = "Gohan", Experiencia = DateTime.Parse("2013-05-10")},
                new Supervisor{Sobrenome = "Dos Santos", PrimeiroNome = "Goten", Experiencia = DateTime.Parse("2016-08-01")}
           };

            foreach (Supervisor s in supervisor)
            {
                hospital.Supervisores.Add(s);
            }

            hospital.SaveChanges();

            var departamentos = new Departamento[]
            {
                new Departamento{Nome="Ocular", Despesas = 350000, DataInicio = DateTime.Parse("2011-05-20")},
                new Departamento{Nome="Dentaria", Despesas = 100000, DataInicio = DateTime.Parse("2011-05-20")},
                new Departamento{Nome="Cardiologica", Despesas = 550000, DataInicio = DateTime.Parse("2011-05-20")},
            };

            foreach(Departamento d in departamentos)
            {
                hospital.Departamentos.Add(d);
            }

            var clinicas = new Clinicas[]
            {
                new Clinicas{ClinicasID = 01,NomeClinica = "Clinica do Saber",Estrelas = 3},
                new Clinicas{ClinicasID = 02,NomeClinica = "Clinica do Querer",Estrelas = 4},
                new Clinicas{ClinicasID = 03,NomeClinica = "Clinica do Conhecimento",Estrelas = 5},
                new Clinicas{ClinicasID = 04,NomeClinica = "Clinica do Tanto Faz",Estrelas = 1}
            };

            foreach (Clinicas c in clinicas)
            {
                hospital.Clinicas.Add(c);
            }

            hospital.SaveChanges();

            var tarefasdosinstrutores = new TarefasInstrutor[]
            {
                new TarefasInstrutor {
                    SupervisorID = supervisor.Single( i => i.Sobrenome == "Saiyan").ID,
                    Lugar = "Smith 17" },
                new TarefasInstrutor {
                    SupervisorID = supervisor.Single( i => i.Sobrenome == "Kakarotto").ID,
                    Lugar = "Gowan 27" },
                new TarefasInstrutor {
                    SupervisorID = supervisor.Single( i => i.Sobrenome == "Dos Santos").ID,
                    Lugar = "Thompson 304" },
            };

            foreach (TarefasInstrutor o in tarefasdosinstrutores)
            {
                hospital.TarefasInstrutors.Add(o);
            }
           hospital.SaveChanges();

            var Tarefasatribuidas = new AtribuicaodeTarefas[]
            {
                new AtribuicaodeTarefas {
                    ClinicaID = clinicas.Single(c => c.NomeClinica == "Clinica do Saber" ).ClinicasID,
                    SupervisorID = supervisor.Single(i => i.Sobrenome == "kakarotto").ID
                    },
                new AtribuicaodeTarefas {
                    ClinicaID = clinicas.Single(c => c.NomeClinica == "Clinica do Querer" ).ClinicasID,
                    SupervisorID = supervisor.Single(i => i.Sobrenome == "Saiyan").ID
                    },
                new AtribuicaodeTarefas {
                    ClinicaID = clinicas.Single(c => c.NomeClinica == "Clinica do Conhecimento").ClinicasID,
                    SupervisorID = supervisor.Single(i => i.Sobrenome == "Dos Santos").ID
                    },
            };
            //comentario de teste
            foreach (AtribuicaodeTarefas at in Tarefasatribuidas)
            {
                hospital.AtribuicaodeTarefas.Add(at);
            }

            hospital.SaveChanges();

            var colecao = new Colecao[]
            {
                 new Colecao {
                    MedicosID = medicos.Single(s => s.Sobrenome == "Estevam").ID,
                    ClinicasID = clinicas.Single(c => c.NomeClinica == "Clinica do Conhecimento" ).ClinicasID
                },
                 new Colecao {
                    MedicosID = medicos.Single(s => s.Sobrenome == "dos Santos").ID,
                    ClinicasID = clinicas.Single(c => c.NomeClinica == "Clinica do Querer" ).ClinicasID
                },
                 new Colecao {
                    MedicosID = medicos.Single(s => s.Sobrenome == "Pazini").ID,
                    ClinicasID = clinicas.Single(c => c.NomeClinica == "Clinica do Saber" ).ClinicasID
                },

            };



            foreach (Colecao c in colecao)
            {
                var enrollmentInDataBase = hospital.Colecaos.Where(
                    s =>
                            s.Medicos.ID == c.MedicosID &&
                            s.Clinicas.ClinicasID == c.ClinicasID).SingleOrDefault();
                if (enrollmentInDataBase == null)
                {
                    hospital.Colecaos.Add(c);
                }
            }
            hospital.SaveChanges();
        }
    }
}
