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
    public class CandidatoService
    {
        public CandidatoService(
            CrudRepository<Candidato, int> repository
        ) => this.repository = repository;

        private readonly CrudRepository<Candidato, int> repository;

        /// <summary>
        /// Obtiene todos los candidatos existentes
        /// </summary>
        public async Task<IReadOnlyCollection<Candidato>> FindAll() => 
            await repository.Find(
                entity => entity,
                entity => true,
                entity => entity.FechaDeContacto,
                OrderDirection.Descending
            );

        /// <summary>
        /// Obtiene el candidato con el id especificado
        /// </summary>
        public Task<Candidato> FindById(int id) => 
            repository.FindById(id);

        public Task Update(
            Candidato nuevaInformacionCandidato
        ) {
            nuevaInformacionCandidato.FechaDeActualizacion = DateTime.Now;
            return repository.Save(nuevaInformacionCandidato);
        }

        public Task Insert(Candidato candidatoAInsertar)
        {
            candidatoAInsertar.FechaDeActualizacion = DateTime.Now;
            return repository.Save(candidatoAInsertar);
        }

        public Task Delete(int id) => 
            repository.DeleteById(id);
    }
}
