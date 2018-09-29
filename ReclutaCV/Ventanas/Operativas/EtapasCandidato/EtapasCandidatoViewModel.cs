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

        public bool TieneEvaluacionCurriculum => this.EvaluacionCurriculum != null;
        public EvaluacionCurriculumCandidatoConsultable EvaluacionCurriculum => this.Model?.EvaluacionCurriculum;

        public bool TienePrimeraLlamada => this.PrimeraLlamada != null;
        public PrimeraLlamadaCandidatoConsultable PrimeraLlamada => this.Model?.PrimeraLlamada;

        public bool TieneExamenes => this.Examenes != null;
        public IReadOnlyCollection<ExamenCandidatoConsultable> Examenes => this.Model?.Examenes;

        public bool TieneEntrevista => this.Entrevista != null;
        public EntrevistaCandidatoConsultable Entrevista => this.Model?.Entrevista;

        public bool TieneAnalisis => this.Analisis != null;
        public AnalisisCandidatoConsultable Analisis => this.Model?.Analisis;

        public bool TieneLlamadaPropuestaEconomica => this.LlamadaPropuestaEconomica != null;
        public LlamadaPropuestaEconomicaCandidatoConsultable LlamadaPropuestaEconomica => this.Model?.LlamadaPropuestaEconomica;
        
        public async Task CargarExistenteYAbrirVentana(
            int candidatoId
        )
        {
            this.Model = await this.etapasCandidatoService.ObtenerInformacionEtapasCandidato(candidatoId);
            this.AbrirVentana();
        }
    }
}
