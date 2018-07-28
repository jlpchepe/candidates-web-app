using ReclutaCV.Candidatos.List;
using ReclutaCVData;
using ReclutaCVData.Entidades;
using ReclutaCVLogic.Repositorio;
using ReclutaCVLogic.Servicios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace ReclutaCV.Candidatos.Edit
{
    /// <summary>
    /// Ventana para edición de candidatos
    /// </summary>
    public class CandidatoEditViewModel
    {
        public CandidatoEditViewModel()
        {
            this.ReiniciarCandidato();
            this.CandidatoService = new CandidatoService(new Db());



        }

        public Candidato Candidato { get; set; }
        public CandidatoListViewModel CandidatoList { get; }

        private void ReiniciarCandidato()
        {
            this.Candidato = new Candidato();
        }

        public ICommand GuardarCandidato => null;

        public CandidatoService CandidatoService { get; }

        //private void GuardarCandidato(object sender, RoutedEventArgs e)
        //{
        //    var candidatoRepositorio = new CandidatoRepositorio();

        //    candidatoRepositorio.Guardar(this.Candidato);

        //    this.CandidatoList.RefrescarCandidatos();

        //    this.ReiniciarCandidato();
        //}
    }
}
