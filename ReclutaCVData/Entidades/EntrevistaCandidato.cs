
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReclutaCVData.Entidades
{
    public class EntrevistaCandidato
    {
        [Key]
        [ForeignKey(nameof(PrimeraLlamadaCandidato))]
        public int PrimeraLlamadaCandidatoId { get; set; }
        public PrimeraLlamadaCandidato PrimeraLlamadaCandidato { get; set; }

        public DateTime Fecha { get; set; }

        public string Observaciones { get; set; }
    }
}
