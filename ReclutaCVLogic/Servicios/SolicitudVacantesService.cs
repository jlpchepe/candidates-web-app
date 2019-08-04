using AppPersistence.Dtos;
using AppPersistence.Enums;
using AppPersistence.Repositories;
using ReclutaCVData;
using ReclutaCVData.Entidades;
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
            CrudRepository<SolicitudVacante, int> repository
        ) => this.repository = repository;

        private readonly CrudRepository<SolicitudVacante, int> repository;

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
        public async Task<Page<SolicitudVacante>> FindAll(
            int pageNumber,
            int pageSize
        ) =>
            await repository.Find(
                entity => entity,
                entity => true,
                entity => entity.FechaDeSolicitud,
                new Pageable(pageNumber, pageSize, OrderDirection.Descending)
            );

        public Task Insert(SolicitudVacante solicitudVacanteAInsertar) =>
            repository.Save(solicitudVacanteAInsertar);

        public Task Update(
            SolicitudVacante SolicitudVacante
        ) => repository.Save(SolicitudVacante);

        public Task<SolicitudVacante> FindById(int id) =>
            repository.FindById(id);

        public Task Delete(int id) =>
            repository.DeleteById(id);
    }
}