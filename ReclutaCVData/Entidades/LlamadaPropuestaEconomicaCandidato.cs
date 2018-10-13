using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReclutaCVData.Entidades
{
    public class LlamadaPropuestaEconomicaCandidato
    {
        [Key]
        [ForeignKey(nameof(Candidato))]
        public int CandidatoId { get; set; }
        public Candidato Candidato { get; set; }

        public DateTime Fecha { get; set; }

        public string Observaciones { get; set; }
        public bool? CandidatoAcepto { get; set; }
        public decimal? SueldoOfrecido { get; set; }
    }
}
