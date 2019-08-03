using ReclutaCVData;
using ReclutaCVData.Entidades;
using ReclutaCVLogic.Dtos;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReclutaCVLogic.Servicios
{
    /// <summary>
    /// 

    /// </summary>
    public class EtapasCandidatoService
    {
        public EtapasCandidatoService(
            Func<Db> db
        )
        {
            this.db = db;
        }
        private readonly Func<Db> db;

        public async Task RegistrarEvaluacionCurriculumCandidato(
            int candidatoId,
            DateTime fechaEvaluacion,
            string observaciones
        )
        {
            using (var c = this.db())
            {
                c.EvaluacionCurriculumCandidato.Add(
                    new EvaluacionCurriculumCandidato(
                        candidatoId,
                        fechaEvaluacion,
                        observaciones
                    )
                );

                await c.SaveChangesAsync();
            }
        }

        public Task ObtenerInformacionEtapasCandidato(
            int candidatoId,
            EvaluacionCurriculumCandidatoConsultable evaluacionCurriculumCandidato,
            PrimeraLlamadaCandidatoConsultable primeraLlamadaCandidato,
            IReadOnlyCollection<ExamenCandidatoConsultable> examenes,
            EntrevistaCandidatoConsultable entrevista,
            AnalisisCandidatoConsultable analisisCandidato,
            LlamadaPropuestaEconomicaCandidatoConsultable llamadaPropuestaEconomica
        )
        {
            //TODO
            return Task.FromResult(0);
        }


        /// <summary>
        /// Obtiene un DTO con toda la información actual acerca del seguimiento del candidato
        /// </summary>
        /// <returns></returns>
        public async Task<EtapasCandidatoConsultable> ObtenerInformacionEtapasCandidato(int candidatoId)
        {
            using (var c = this.db())
            {
                return new EtapasCandidatoConsultable(
                    candidatoId,
                    await c.EvaluacionCurriculumCandidato
                        .Where(x => x.CandidatoId == candidatoId)
                        .Select(x => 
                            new EvaluacionCurriculumCandidatoConsultable()
                            {
                                FechaEvaluacion = x.FechaEvaluacion,
                                Observaciones = x.Observaciones
                            }
                        ).FirstOrDefaultAsync(),
                    await c.PrimeraLlamadaCandidato
                        .Where(x => x.CandidatoId == candidatoId)
                        .Select(x => 
                            new PrimeraLlamadaCandidatoConsultable()
                            {
                                Fecha = x.Fecha,
                                Observaciones = x.Observaciones
                            }
                        )
                        .FirstOrDefaultAsync(),
                    await c.ExamenCandidato
                        .Where(x => x.CandidatoId == candidatoId)
                        .Select(x =>
                            new ExamenCandidatoConsultable()
                            {
                                Id = x.Id,
                                Calificacion = x.Calificacion,
                                Fecha = x.Fecha,
                                Observaciones = x.Observaciones,
                                Tipo = x.Tipo
                            }
                        )
                        .ToListAsync(),
                    await c.EntrevistaCandidato
                        .Where(x => x.CandidatoId == candidatoId)
                        .Select(x =>
                            new EntrevistaCandidatoConsultable()
                            {
                                Fecha = x.Fecha,
                                Observaciones = x.Observaciones
                            }
                        )
                        .FirstOrDefaultAsync(),
                    await c.AnalisisCandidato
                        .Where(x => x.CandidatoId == candidatoId)
                        .Select(x =>
                            new AnalisisCandidatoConsultable()
                            {
                                Aceptado = x.Aceptado,
                                Fecha = x.Fecha,
                                ObservacionesRecursosHumanos = x.ObservacionesRecursosHumanos,
                                ObservacionesTecnicas = x.ObservacionesTecnicas
                            }
                        )
                        .FirstOrDefaultAsync(),
                    await c.LlamadaPropuestaEconomicaCandidato
                        .Where(x => x.CandidatoId == candidatoId)
                        .Select(x =>
                            new LlamadaPropuestaEconomicaCandidatoConsultable()
                            {
                                CandidatoAcepto = x.CandidatoAcepto,
                                Fecha = x.Fecha,
                                Observaciones = x.Observaciones,
                                SueldoOfrecido = x.SueldoOfrecido
                            }
                        )
                        .FirstOrDefaultAsync()
                );
            }
        }
    }
}
