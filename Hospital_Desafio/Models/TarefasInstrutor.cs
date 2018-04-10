 using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Hospital_Desafio.Models
{
    public class TarefasInstrutor
    {
        [Key]
        public int SupervisorID { get; set; }
        [StringLength(50)]
        [Display(Name ="Lugar de Trabalho")]
        public String Lugar { get; set; }
        
        public Supervisor Supervisor { get; set; }
    }
}
