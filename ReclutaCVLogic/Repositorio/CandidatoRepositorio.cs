using ReclutaCVData;
using ReclutaCVData.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReclutaCVLogic.Repositorio
{
    public class CandidatoRepositorio
    {


        /// <summary>
        /// Guarda el candidato en la base de datos
        /// </summary>
        /// <param name="candidato"></param>
        /// <returns></returns>
        public int Guardar(Candidato candidato)
        {
            var db = new Db();

            db.Candidato.Add(candidato);

            db.SaveChanges();

            return 0;


        }
    }
}
