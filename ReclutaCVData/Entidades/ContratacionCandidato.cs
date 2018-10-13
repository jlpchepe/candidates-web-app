using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReclutaCVData.Entidades
{
    public class ContratacionCandidato
    {
        public DateTime FechaDeContratacion { get; set; } = DateTime.Now;
        public string NivelDelCandidato { get; set; }
        public string Observaciones { get; set; }


    }
}
