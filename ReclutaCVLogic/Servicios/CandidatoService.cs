using AppPersistence.Dtos;
using AppPersistence.Enums;
using AppPersistence.Repositories;
using ReclutaCVData;
using ReclutaCVData.Entidades;
using ReclutaCVLogic.Dtos;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Linq.Expressions;
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
        /// Obtiene todos los candidatos existentes
        /// </summary>
        public async Task<Page<CandidatoConsultable>> FindAll(
            Expression<Func<Candidato, CandidatoConsultable>> selector,
            int pageNumber,
            int pageSize,
            string nombre
        )
        {
            var fixedNombre = nombre ?? "";

            return await repository.Find(
                selector,
                entity =>
                    fixedNombre == "" ||
                    entity.Nombre.ToLower().Contains(nombre.ToLower())
                ,
                entity => entity.FechaDeContacto,
                new Pageable(pageNumber, pageSize, OrderDirection.Descending)
            );
        }

        public async Task SaveCurriculum(
            int candidatoId, 
            byte[] curriculum, 
            string curriculumFileName
        )
        {
            var candidato = await FindById(candidatoId, entity => entity);
            candidato.Curriculum = curriculum;
            candidato.CurriculumFileName = curriculumFileName;

            await Update(candidato);
        }

        public async Task<CandidatoCurriculumConsultable> GetCurriculum(int id)
        {
            return await FindById(
                id,
                entity => new CandidatoCurriculumConsultable
                {
                    Curriculum = entity.Curriculum,
                    CurriculumFileName = entity.CurriculumFileName
                }
            );
        }

        /// <summary>
        /// Obtiene el candidato con el id especificado
        /// </summary>
        public Task<TResult> FindById<TResult>(
            int id,
            Expression<Func<Candidato, TResult>> selector
        ) => 
            repository.FindFirstOrDefault(
                selector,
                entity => entity.Id == id,
                entity => true
            );

        public Task Update(
            Candidato nuevaInformacionCandidato
        ) {
            nuevaInformacionCandidato.FechaDeActualizacion = DateTime.Now;
            return repository.Save(nuevaInformacionCandidato);
        }

        /// <summary>
        /// Regresa la llave primaria del registro
        /// </summary>
        /// <param name="candidatoAInsertar"></param>
        /// <returns></returns>
        public async Task<int> Insert(Candidato candidatoAInsertar)
        {
            candidatoAInsertar.FechaDeActualizacion = DateTime.Now;
            await repository.Save(candidatoAInsertar);

            return candidatoAInsertar.Id;
        }

        public Task Delete(int id) => 
            repository.DeleteById(id);
    }
}
