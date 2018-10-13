using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReclutaCVLogic.Dtos
{
    /// <summary>
    /// DTO con la información de acerca de la l
    /// </summary>
    public class PrimeraLlamadaCandidatoConsultable
    {
        public PrimeraLlamadaCandidatoConsultable() { }
        public PrimeraLlamadaCandidatoConsultable(
            DateTime fecha, 
            string observaciones
        )
        {
            Fecha = fecha;
            Observaciones = observaciones;
        }

        public DateTime Fecha { get; set; }
        public string Observaciones { get; set; }
    }
}
