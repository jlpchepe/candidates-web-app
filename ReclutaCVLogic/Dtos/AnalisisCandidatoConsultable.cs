using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReclutaCVLogic.Dtos
{
    /// <summary>
    /// Analisis hecho a partir de la entrevista 
    /// </summary>
    public class AnalisisCandidatoConsultable
    {
        public AnalisisCandidatoConsultable() { }
        public AnalisisCandidatoConsultable( 
            DateTime fecha, 
            string observacionesRecursosHumanos, 
            string observacionesTecnicas, 
            bool aceptado
        )
        {
            Fecha = fecha;
            ObservacionesRecursosHumanos = observacionesRecursosHumanos;
            ObservacionesTecnicas = observacionesTecnicas;
            Aceptado = aceptado;
        }
        
        public DateTime Fecha { get; set; }
        public string ObservacionesRecursosHumanos { get; set; }
        public string ObservacionesTecnicas { get; set; }
        public bool Aceptado { get; set; }
    }
}