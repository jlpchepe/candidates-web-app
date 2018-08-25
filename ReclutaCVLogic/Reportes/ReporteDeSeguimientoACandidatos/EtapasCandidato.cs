using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReclutaCVLogic.Reportes.ReporteDeSeguimientoACandidatos
{
    public class EtapasCandidato
    { 
        public string NombreDelCandidato { get; set; }
        public DateTime FechaDeRegistro { get; set; }
        public DateTime FechaDeAnalisisDeCv { get; set; }
        public DateTime FechaDeLlamada { get; set; }
        public DateTime FechaDeExamen { get; set; }
        public DateTime FechaDeEntrevistas { get; set; }
        public DateTime FechaDeAnalisisDelCandidato { get; set; }
        public DateTime FechaDePropuestaEconomica { get; set; }
        public DateTime FechaDeIngreso { get; set; }


    }
}
