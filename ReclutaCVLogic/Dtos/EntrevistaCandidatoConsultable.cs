using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReclutaCVLogic.Dtos
{
    /// <summary>
    /// Entrevista de un candidato
    /// </summary>
    public class EntrevistaCandidatoConsultable
    {
        public EntrevistaCandidatoConsultable(
            DateTime fecha,
            string observaciones
        )
        {
            Observaciones = observaciones;
            Fecha = fecha;
        }
        
        public DateTime Fecha { get; set; }
        public string Observaciones { get; set; }
    }
}
