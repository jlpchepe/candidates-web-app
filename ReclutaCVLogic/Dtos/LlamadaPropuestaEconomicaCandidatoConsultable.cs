using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReclutaCVLogic.Dtos
{
    /// <summary>
    /// La información de la llamada que se hizo a un candidato que fue previamente aceptado
    /// </summary>
    public class LlamadaPropuestaEconomicaCandidatoConsultable
    {
        public LlamadaPropuestaEconomicaCandidatoConsultable() { }
        public LlamadaPropuestaEconomicaCandidatoConsultable(
            DateTime fecha, 
            string observaciones, 
            bool candidatoAcepto, 
            decimal? sueldoOfrecido
        )
        {
            Fecha = fecha;
            Observaciones = observaciones;
            CandidatoAcepto = candidatoAcepto;
            SueldoOfrecido = sueldoOfrecido;
        }

        public DateTime Fecha { get; set; }
        public string Observaciones { get; set; }
        public bool? CandidatoAcepto { get; set; }
        public decimal? SueldoOfrecido { get; set; }
    }
}
