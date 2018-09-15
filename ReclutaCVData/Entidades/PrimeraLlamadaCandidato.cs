using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReclutaCVData.Entidades
{
    public class PrimeraLlamadaCandidato
    {
        [Key]
        [ForeignKey(nameof(EvaluacionCurriculumCandidato))]
        public int EvaluacionCurriculumCandidatoId { get; set; }
        public EvaluacionCurriculumCandidato EvaluacionCurriculumCandidato { get; set; }

        public DateTime Fecha { get; set; }

        public string Observaciones { get; set; }
    }
}
