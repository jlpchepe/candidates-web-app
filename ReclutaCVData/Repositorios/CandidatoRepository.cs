using ReclutaCVData.Entidades;
using System;
using System.Collections.Generic;
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
        public void Update() { }
        public void Insert() { }
        public void Delete() { }
    }
}
