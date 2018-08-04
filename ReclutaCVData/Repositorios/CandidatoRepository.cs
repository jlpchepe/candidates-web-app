using ReclutaCVData.Entidades;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReclutaCVData.Repositorios
{
    public class CandidatoRepository
    {
        public Db db { get; }

        public CandidatoRepository(
            Db db
        )
        {
            this.db = db;
        }

        /// <summary>
        /// Obtiene todos los candidatos existentes
        /// </summary>
        public List<Candidato> FindAll() {
            return this.db.Candidato.ToList();
        }

        /// <summary>
        /// Obtiene el candidato con el id especificado
        /// </summary>
        public Candidato FindById(int id) {
            return this.db.Candidato.Find(id);
        }
        public void Update(
            Candidato nuevaInformacionCandidato    
        ) {
            this.db.Candidato.AddOrUpdate(nuevaInformacionCandidato);
            this.db.SaveChanges();

         

        }

        public void Insert(
            Candidato candidatoAInsertar

            ) {
            this.db.Candidato.Add(candidatoAInsertar);
            this.db.SaveChanges();

        }
        public void Delete(int id) {
            this.db.Candidato.Remove(this.FindById(id));
            this.db.SaveChanges();
     

        }
    }   

}
