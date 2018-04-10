using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Hospital_Desafio.Models
{
    public class Supervisor
    {
        [Key]
        public int ID { get; set; }

        [Required]
        [Display(Name = "Sobrenome")]
        [StringLength(50)]
        public string Sobrenome { get; set; }
         
        [Required]
        [Column("PrimeiroNome")]
        [Display(Name = "Primeiro Nome")]
        [StringLength(50)]
        public string FirstMidName { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "Tempo de Casa")]
        public DateTime Experiencia { get; set; }

        [Display(Name = "Full Name")]
        public string FullName
        {
            get { return Sobrenome + ", " + FirstMidName; }
        }

        public ICollection<AtribuicaodeTarefas> AtribuicaodeTarefas { get; set; }
        public TarefasInstrutor TarefasInstrutor { get; set; }
    }
}
