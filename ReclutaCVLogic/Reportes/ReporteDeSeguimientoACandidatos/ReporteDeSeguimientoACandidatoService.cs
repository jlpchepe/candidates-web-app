using ReclutaCVData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReclutaCVLogic.Reportes.ReporteDeSeguimientoACandidatos
{
    public class ReporteDeSeguimientoACandidatoService
    {
        public ReporteDeSeguimientoACandidatoService(
            Func<Db> db
        )
        {
            this.db = db;
        }

        private readonly Func<Db> db;

        public void GenerarReporte()
        {
            using (var c = this.db())
            {
                var reporte = new ReporteDeSeguimientoACandidatos(
                    c.Candidato.Count(),
                    c.EvaluacionCurriculumCandidato.Where(evaluacionCandidato => evaluacionCandidato.CumplioConPerfil).Count(),
                    c.PrimeraLlamadaCandidato.Where(PrimeraLlamadaCandidato => PrimeraLlamadaCandidato.ContinuoConElProceso).Count(),
                    c.ExamenCandidato.Count(),
                    c.EntrevistaCandidato.Count (),
                    c.AnalisisCandidato.Count (),
                    c.AnalisisCandidato.Where(AnalisisCandidato => AnalisisCandidato.Aceptado). Count(),
                    c.ContratacionCandidato.Count(),
                    c.EvaluacionCurriculumCandidato.Where(evaluacionCandidato => !evaluacionCandidato.CumplioConPerfil).Count(),
                    c.PrimeraLlamadaCandidato.Where(PrimeraLlamadaCandidato => !PrimeraLlamadaCandidato.ContinuoConElProceso).Count(),
                    c.Candidato.Where(candidato => candidato.PrimeraLlamada.ContinuoConElProceso && candidato.Examenes.Count() == 0).Count(),
                    c.Candidato.Where(candidato => candidato.Examenes.Count() >0 && candidato.Entrevista == null).Count(),
                    c.Candidato.Where(candidato => candidato.Entrevista != null && candidato.Analisis == null).Count(),
                    c.Candidato.Where(candidato => candidato.Rechazado).Count(),
                    c.Candidato.Where(candidato => candidato.LlamadaPropuestaEconomica.CandidatoAcepto == false).Count(),
                    c.Candidato.Where(candidato => candidato.LlamadaPropuestaEconomica.CandidatoAcepto == true).Count(),
                    null
                );
            }
        }
    }
}
