using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Hospital_Desafio.Models
{
    public class Colecao
    {
        public int ColecaoID { get; set; }
        public int ClinicasID { get; set; }
        public int MedicosID { get; set; }

        public Medicos Medicos { get; set; }
        public Clinicas Clinicas { get; set; }

    }
}
