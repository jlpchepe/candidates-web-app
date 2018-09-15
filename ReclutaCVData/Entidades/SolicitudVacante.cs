using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReclutaCVData.Entidades
{
    public class SolicitudVacante
    {
        public int CantidadDeVacantes { get; set; }
        public RolCandidato RolVacante { get; set; }
        public DateTime FechaDeSolicitud { get; set; }


      
    }
}
