using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Hospital_Desafio.Models
{
    public class Medicos
    {
        public int ID { get; set; }
        [StringLength(50,MinimumLength = 1)]
        [Display(Name = "Primeiro Nome")]
        public String PrimeiroNome { get; set; }
        [Required]
        [StringLength(50, ErrorMessage = "O Primeiro Nome não pode ser maior que 50 caracteres!")]
        [Column("Sobrenome")]
        [Display(Name ="Sobrenome")] 
        public String Sobrenome { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name ="Colecao Date")]
        public DateTime ColecaoDate { get; set; }
        [Display(Name ="Full Nome")]

        public String FullNome
        {
            get
            {
                return Sobrenome + ", " + PrimeiroNome;
            }
        }

        public ICollection<Colecao> Colecaos { get; set; }
    }
}
