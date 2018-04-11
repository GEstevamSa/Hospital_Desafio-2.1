using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hospital_Desafio.Models.HospitalViewsModels
{
    public class SupervisorIndexMode
    {
        public IEnumerable<Supervisor> Supervisores { get; set; }
        public IEnumerable<Clinicas> Clinicas { get; set; }
        public IEnumerable<Colecao> Colecaos { get; set; }
    }
}
