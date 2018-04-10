using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Hospital_Desafio.Models
{
    public class Departamento
    {

        public int DepartamentoID { get; set; }

        [StringLength(50, MinimumLength = 1)]
        public String Nome { get; set; }

        [DataType(DataType.Currency)]
        [Column(TypeName = "Dinheiro")]
        public decimal Despesas { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "Data Inicio")]
        public DateTime DataInicio { get; set; }

        public int? SupervisorID { get; set; }

        public Supervisor Adm { get; set; }
        public ICollection<Clinicas> Clinicas { get; set; }
    }
}
