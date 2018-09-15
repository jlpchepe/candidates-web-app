using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReclutaCVData.Entidades
{
    public class SolicitudVacante
    {
        [Key]
        public int Id { get; set; }

        public int CantidadDeVacantes { get; set; }
        public RolCandidato RolVacante { get; set; }
        public DateTime FechaDeSolicitud { get; set; }
    }
}
