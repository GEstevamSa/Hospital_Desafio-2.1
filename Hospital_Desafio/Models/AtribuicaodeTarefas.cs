using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Hospital_Desafio.Models
{
    public class AtribuicaodeTarefas
    {
        public int SupervisorID { get; set; }
        public int ClinicaID { get; set; }
        public Supervisor Supervisor { get; set; }
        public Clinicas Clinicas { get; set; }
    }
}
