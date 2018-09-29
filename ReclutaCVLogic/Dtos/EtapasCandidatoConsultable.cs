using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReclutaCVLogic.Dtos
{
    /// <summary>
    /// Información del seguimiento de las etapas por las que pasa un candidato determinado
    /// </summary>
    public class EtapasCandidatoConsultable
    {
        public EtapasCandidatoConsultable() { }

        public EtapasCandidatoConsultable(
            int candidatoId, 
            EvaluacionCurriculumCandidatoConsultable evaluacionCurriculum, 
            PrimeraLlamadaCandidatoConsultable primeraLlamada, 
            IReadOnlyCollection<ExamenCandidatoConsultable> examenes, 
            EntrevistaCandidatoConsultable entrevista, 
            AnalisisCandidatoConsultable analisis, 
            LlamadaPropuestaEconomicaCandidatoConsultable llamadaPropuestaEconomica
        )
        {
            CandidatoId = candidatoId;
            EvaluacionCurriculum = evaluacionCurriculum;
            PrimeraLlamada = primeraLlamada;
            Examenes = examenes;
            Entrevista = entrevista;
            Analisis = analisis;
            LlamadaPropuestaEconomica = llamadaPropuestaEconomica;
        }

        public int CandidatoId { get; }

        /// <summary>
        /// Información sobre la evaluación de un candidato, o null si el candidato aun no ha sido evaluado
        /// </summary>
        public EvaluacionCurriculumCandidatoConsultable EvaluacionCurriculum { get; }
        public PrimeraLlamadaCandidatoConsultable PrimeraLlamada { get; }
        /// <summary>
        /// Información de los examenes que ha realizado el candidato, si el candidato no ha realizado ningun examen esta lista estará vacía
        /// </summary>
        public IReadOnlyCollection<ExamenCandidatoConsultable> Examenes { get;  }
        public EntrevistaCandidatoConsultable Entrevista { get; }
        public AnalisisCandidatoConsultable Analisis { get; }
        public LlamadaPropuestaEconomicaCandidatoConsultable LlamadaPropuestaEconomica { get; }
    }
}
