using ReclutaCVData;
using ReclutaCVData.Entidades;
using ReclutaCVLogic.Servicios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReclutaCV.Candidatos.List
{
    public class CandidatoListViewModel
    {
        public CandidatoListViewModel(CandidatoService candidatoService)
        {
            this.CandidatoService = candidatoService;
            this.RefrescarCandidatos();


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
