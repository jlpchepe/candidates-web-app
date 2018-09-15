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
        public async Task<EtapasCandidatoConsultable> ObtenerInformacionEtapasCandidato(
            int candidatoId
        )
        {
            return null;
        }
    }
}
