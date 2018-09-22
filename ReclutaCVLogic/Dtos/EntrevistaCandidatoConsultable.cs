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
            string observaciones, 
            DateTime fecha
        )
        {
            Observaciones = observaciones;
            Fecha = fecha;
        }
        
        public string Observaciones { get; set; }
        public DateTime Fecha { get; set; }
    }
}
