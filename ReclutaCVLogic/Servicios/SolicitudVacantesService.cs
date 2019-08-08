using AppPersistence.Dtos;
using AppPersistence.Enums;
using AppPersistence.Repositories;
using ReclutaCVData;
using ReclutaCVData.Entidades;
using ReclutaCVLogic.Dtos;
using ReclutaCVLogic.Reportes;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReclutaCVLogic.Servicios
{
    public class SolicitudVacantesService
    {
        public SolicitudVacantesService(
            CrudRepository<SolicitudVacante, int> repository,
            GeneradorReporteSolicitudVacantes generadorReporteSolicitudVacantes
        )
        {
            this.repository = repository;
            this.generadorReporteSolicitudVacantes = generadorReporteSolicitudVacantes;
        }

        private readonly CrudRepository<SolicitudVacante, int> repository;
        private readonly GeneradorReporteSolicitudVacantes generadorReporteSolicitudVacantes;

        /// <summary>
        /// Obtiene todos las solicitudes existentes
        /// </summary>
        public async Task<IReadOnlyCollection<SolicitudVacante>> FindAll() =>
            await repository.Find(
                entity => entity,
                entity => true,
                entity => entity.FechaDeSolicitud,
                OrderDirection.Descending
            );

        /// <summary>
        /// Obtiene todos las solicitudes existentes
        /// </summary>
        public Task<Page<SolicitudVacante>> FindAll(
            int pageNumber,
            int pageSize,
            string busqueda,
            RolCandidato? puestoSolicitado
        )
        {
            var fixedBusqueda = busqueda ?? "";
            var puestoSolicitadoNotSet = puestoSolicitado == null;

            return repository.Find(
                entity => entity,
                entity => (
                    (
                        entity.FolioCapitalHumano.ToString().Contains(fixedBusqueda) ||
                        entity.NombreDelSolicitante.ToLower().Contains(fixedBusqueda.ToLower())
                    ) &&
                    (
                        puestoSolicitadoNotSet ||
                        entity.PuestoSolicitado == puestoSolicitado
                    )
                ),
                entity => entity.FechaDeSolicitud,
                new Pageable(pageNumber, pageSize, OrderDirection.Descending)
            );
        }

        public async Task<Reporte> GetReporteSolicitudes(
            string busqueda, 
            RolCandidato? puestoSolicitado
        )
        {
            var solicitudes = (await FindAll(0, int.MaxValue, busqueda, puestoSolicitado))
                .Items
                .Select(x => new FilaReporteSolicitudVacante(
                    x.Id,
                    x.FolioCapitalHumano,
                    x.FechaDeSolicitud,
                    x.Motivo,
                    x.EspecifiqueMotivo,
                    x.NombreDelSolicitante,
                    x.PuestoDelSolicitante,
                    x.AreaDelSolicitante,
                    x.EspecifiqueAreaDelSolicitante,
                    x.Sueldo,
                    x.TipoDeContrato,
                    x.EspecifiqueTipoDeContrato,
                    x.Estatus,
                    x.PuestoSolicitado,
                    x.EspecifiquePuestoSolicitado,
                    x.PuestoSolicitadoNivel,
                    x.NombreDelJefeInmediato,
                    x.Proyecto,
                    x.NivelIdiomaIngles,
                    x.EdadRango,
                    x.EstadoCivil,
                    x.FechaEstimadaDeIngreso,
                    x.ExperienciaLaboral,
                    x.CompetenciasOHabilidades,
                    x.CertificacionesNecesarias,
                    x.TipoDeEvaluacion,
                    x.Observaciones
                ))
                .ToList();

            return await generadorReporteSolicitudVacantes.GenerarReporteSolicitudVacantes(solicitudes);
        }

        public async Task<int> Insert(SolicitudVacante solicitudVacanteAInsertar) {
            await repository.Save(solicitudVacanteAInsertar);

            return solicitudVacanteAInsertar.Id;
        }

        public Task Update(
            SolicitudVacante SolicitudVacante
        ) => repository.Save(SolicitudVacante);

        public Task<SolicitudVacante> FindById(int id) =>
            repository.FindById(id);

        public Task Delete(int id) =>
            repository.DeleteById(id);
    }
}