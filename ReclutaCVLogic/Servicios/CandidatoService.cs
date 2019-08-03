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
            Func<Db> db
        )
        {
            this.db = db;
        }
        private readonly Func<Db> db;

        /// <summary>
        /// Obtiene todos los candidatos existentes
        /// </summary>
        public async Task<IReadOnlyCollection<Candidato>> FindAll() => 
            await this.db().Candidato
                .OrderByDescending(c => c.FechaDeContacto)
                .ToListAsync();

        private Task<Candidato> FindByIdAttached(Db c, int id) => 
            c.Candidato.FindAsync(id);

        /// <summary>
        /// Obtiene el candidato con el id especificado
        /// </summary>
        public async Task<Candidato> FindById(int id)
        {
            using (var c = this.db())
            {
                return await FindByIdAttached(c, id);
            }
        }

        public async Task Update(
            Candidato nuevaInformacionCandidato
        )
        {
            using (var c = this.db())
            {
                c.Candidato.AddOrUpdate(nuevaInformacionCandidato);
                nuevaInformacionCandidato.FechaDeActualizacion = DateTime.Now;
                await c.SaveChangesAsync();
            }
        }

        public async Task Insert(Candidato candidatoAInsertar)
        {
            using (var c = this.db())
            {
                c.Candidato.Add(candidatoAInsertar);
                candidatoAInsertar.FechaDeActualizacion = DateTime.Now;
                await c.SaveChangesAsync();
            }

        }

        public async Task Delete(int id)
        {
            using (var c = this.db())
            {
                var candidato = await this.FindByIdAttached(c, id);
                c.Candidato.Remove(candidato);
                await c.SaveChangesAsync();
            }
        }
    }
}
