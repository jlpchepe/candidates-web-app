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
            Func<Db> db
        )
        {
            this.db = db;
        }

        private Func<Db> db { get; }

        /// <summary>
        /// Obtiene todos las solicitudes existentes
        /// </summary>
        public async Task<IReadOnlyCollection<SolicitudVacante>> FindAll()
        {
            using (var c = this.db())
            {
                return await c.SolicitudVacante.ToListAsync();
            }
        }

        public async Task Insert(SolicitudVacante SolicitudVacanteAInsertar)
        {
            using (var c = this.db())
            {
                c.SolicitudVacante.Add(SolicitudVacanteAInsertar);
                await c.SaveChangesAsync();
            }
        }

        public async Task Update(
            SolicitudVacante SolicitudVacante
        )
        {
            using (var c = this.db())
            {
                c.SolicitudVacante.AddOrUpdate(SolicitudVacante);
                await c.SaveChangesAsync();
            }
        }
    }
}