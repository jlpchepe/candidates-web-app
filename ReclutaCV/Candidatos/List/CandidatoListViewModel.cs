using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ReclutaCVData;
using ReclutaCVData.Entidades;
using ReclutaCVLogic.Servicios;

namespace ReclutaCV.Candidatos.List
{
    public class CandidatoListViewModel
    {
        public CandidatoListViewModel()
        {
            this.RefrescarCandidatos();
            this.CandidatoService = new CandidatoService(new Db());


        }
    
        public List<Candidato> Items { get; internal set; }
        public CandidatoService CandidatoService { get; }

        public void RefrescarCandidatos()
        {
            //Cargamos los candidatos desde la base de datos
            this.Items = this.CandidatoService.FindAll();
        }
    }
}
