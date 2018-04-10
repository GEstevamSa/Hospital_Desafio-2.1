using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Hospital_Desafio.Models
{
    public class Clinicas
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]//Basicamente, esse atributo permite que você insira a chave primária do curso, em vez de fazer com que ela seja gerada pelo banco de dados.
        [Display(Name = "Number")]
        public int ClinicasID { get; set; }

        [StringLength(50, MinimumLength = 3)]
        public String NomeClinica { get; set; }

        [Range(0, 5)]
        public int Estrelas { get; set; }

        public int DepartamentoID { get; set; }

        public Departamento Departamento { get; set; }
        public ICollection<Colecao> Colecaos { get; set; }
        public ICollection<Clinicas> Clinica { get; set; }
    }  
}
