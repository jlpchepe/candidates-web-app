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
    public class SolicitudVacantesService
    {
        public Func<Db> db { get; }

        public SolicitudVacantesService(
            Func<Db> db
        )
        {
            this.db = db;
        }

        /// <summary>
        /// Obtiene todos las solicitudes existentes
        /// </summary>
        public IReadOnlyCollection<SolicitudVacante> FindAll()
        {
            return this.db().SolicitudVacante.ToList();
        }

        public void Insert(SolicitudVacante SolicitudVacanteAInsertar)
        {
            using (var c = this.db())
            {
                c.SolicitudVacante.Add(SolicitudVacanteAInsertar);
                c.SaveChanges();
            }
        }

        public void Update(
            SolicitudVacante SolicitudVacante
        )
        {
            using (var c = this.db())
            {
                c.SolicitudVacante.AddOrUpdate(SolicitudVacante);
                c.SaveChanges();
            }
        }
    }
}
