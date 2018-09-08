using ReclutaCVData;
using ReclutaCVData.Entidades;
using System;
using System.Collections.Generic;
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
    }
}
