using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReclutaCVData.Entidades
{
    public class EvaluacionCurriculumCandidato
    {
        public EvaluacionCurriculumCandidato(
            int candidatoId,  
            DateTime fechaEvaluacion, 
            string observaciones
        )
        {
            CandidatoId = candidatoId;
            FechaEvaluacion = fechaEvaluacion;
            Observaciones = observaciones;
        }

        /// <summary>
        /// Candidato al cual se le evaluo el CV
        /// </summary>
        [Key]
        [ForeignKey(nameof(Candidato))]
        public int CandidatoId { get; set; }
        public Candidato Candidato { get; set; }
        
        public DateTime FechaEvaluacion { get; set; }

        public string Observaciones { get; set; }
    }
}
