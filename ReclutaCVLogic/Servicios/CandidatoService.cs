using ReclutaCVData;
using ReclutaCVData.Entidades;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReclutaCVLogic.Servicios
{
    public class CandidatoService
    {
        public Func<Db> db { get; }

        public CandidatoService(
            Func<Db> db
        )
        {
            this.db = db;
        }

        /// <summary>
        /// Obtiene todos los candidatos existentes
        /// </summary>
        public List<Candidato> FindAll()
        {
            return this.db().Candidato.ToList();
        }

        private Candidato FindByIdAttached(Db c, int id)
        {
            return c.Candidato.Find(id);
        }

        /// <summary>
        /// Obtiene el candidato con el id especificado
        /// </summary>
        public Candidato FindById(int id)
        {
            using (var c = this.db())
            {
                return this.FindByIdAttached(c, id);
            }
        }

        public void Update(
            Candidato nuevaInformacionCandidato
        )
        {
            using (var c = this.db())
            {
                c.Candidato.AddOrUpdate(nuevaInformacionCandidato);
                c.SaveChanges();
            }
        }

        public void Insert(Candidato candidatoAInsertar)
        {
            using (var c = this.db())
            {
                c.Candidato.Add(candidatoAInsertar);
                c.SaveChanges();
            }

        }
        public void Delete(int id)
        {
            using (var c = this.db())
            {
                var candidato = this.FindByIdAttached(c, id);
                c.Candidato.Remove(candidato);
                c.SaveChanges();
            }
        }
    }
}
