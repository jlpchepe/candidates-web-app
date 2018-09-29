using ReclutaCVData;
using ReclutaCVData.Entidades;
using ReclutaCVLogic.Dtos;
using System;
using System.Collections.Generic;
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
        readonly Func<Db> db;

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

        /// <summary>
        /// Obtiene un DTO con toda la información actual acerca del seguimiento del candidato
        /// </summary>
        /// <returns></returns>
        public Task<EtapasCandidatoConsultable> ObtenerInformacionEtapasCandidato(int candidatoId)
        {
            return Task.FromResult(
                new EtapasCandidatoConsultable(
                    candidatoId,
                    new EvaluacionCurriculumCandidatoConsultable(
                        DateTime.Now,
                        null
                    ),
                    new PrimeraLlamadaCandidatoConsultable(
                        DateTime.Now,
                        null
                    ),
                    new List<ExamenCandidatoConsultable>
                    {
                        new ExamenCandidatoConsultable(1, TipoExamenCandidato.AdministradorDeProyectos, DateTime.Now, 100, "Ninguna"),
                        new ExamenCandidatoConsultable(2, TipoExamenCandidato.Analista, DateTime.Now, 60, "Ninguna"),
                    },
                    new EntrevistaCandidatoConsultable(
                        DateTime.Now,
                        null
                    ),
                    new AnalisisCandidatoConsultable(
                        DateTime.Now,
                        null,
                        null,
                        false
                    ),
                    new LlamadaPropuestaEconomicaCandidatoConsultable(
                        DateTime.Now,
                        null,
                        false,
                        10000
                    )
                )
             );
        }
    }
}
