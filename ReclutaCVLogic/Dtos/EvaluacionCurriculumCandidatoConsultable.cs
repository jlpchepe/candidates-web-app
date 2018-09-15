using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReclutaCVLogic.Dtos
{
    /// <summary>
    /// Innformación especificado sobre la evaluación que tuvo un candidato de su CV
    /// </summary>
    public class EvaluacionCurriculumCandidatoConsultable
    {
        public EvaluacionCurriculumCandidatoConsultable(
            DateTime fechaEvaluacion,
            string observaciones
        )
        {
            FechaEvaluacion = fechaEvaluacion;
            Observaciones = observaciones;
        }

        public DateTime FechaEvaluacion { get; set; }
        public string Observaciones { get; set; }
    }
}
