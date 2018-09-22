using ReclutaCV.Base.Edit;
using ReclutaCV.Base.Window;
using ReclutaCVLogic.Dtos;
using ReclutaCVLogic.Servicios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReclutaCV.Ventanas.Operativas.EtapasCandidato
{
    public class EtapasCandidatoViewModel : WindowViewModel<EtapasCandidatoView>
    {
        public EtapasCandidatoViewModel(
            EtapasCandidatoService etapasCandidatoService
        )
        {
            this.etapasCandidatoService = etapasCandidatoService;
        }
        readonly EtapasCandidatoService etapasCandidatoService;

        private EtapasCandidatoConsultable Model { get; set; }

        public EvaluacionCurriculumCandidatoConsultable EvaluacionCurriculum => this.Model?.EvaluacionCurriculum;
        public PrimeraLlamadaCandidatoConsultable PrimeraLlamada => this.Model?.PrimeraLlamada;
        public IReadOnlyCollection<ExamenCandidatoConsultable> Examenes => this.Model?.Examenes;
        public EntrevistaCandidatoConsultable Entrevista => this.Model?.Entrevista;
        public AnalisisCandidatoConsultable Analisis => this.Model?.Analisis;
        public LlamadaPropuestaEconomicaCandidatoConsultable LlamadaPropuestaEconomica => this.Model?.LlamadaPropuestaEconomica;
        
        public override Task<EtapasCandidatoConsultable> CargarExistenteYAbrirVentana(
            int cantidatoId
        )
        {
            
        }
    }
}
