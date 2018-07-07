using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ReclutaCVData;
using ReclutaCVData.Entidades;

namespace ReclutaCV.Candidatos.List
{
    public class CandidatoListViewModel
    {
        public CandidatoListViewModel()
        {
            this.RefrescarCandidatos();
        }
    
        public List<Candidato> Items { get; internal set; }

        public void RefrescarCandidatos()
        {
            //Cargamos los candidatos desde la base de datos
            this.Items = new Db().Candidato.ToList();
        }
    }
}
