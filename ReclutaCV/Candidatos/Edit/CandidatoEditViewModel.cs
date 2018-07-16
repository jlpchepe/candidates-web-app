using ReclutaCV.Candidatos.List;
using ReclutaCVData.Entidades;
using ReclutaCVLogic.Repositorio;
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
        }

        public Candidato Candidato { get; set; }
        public CandidatoListViewModel CandidatoList { get; }

        private void ReiniciarCandidato()
        {
            this.Candidato = new Candidato();
        }

        public ICommand GuardarCandidato => new RelayCommand();

        private void GuardarCandidato(object sender, RoutedEventArgs e)
        {
            var candidatoRepositorio = new CandidatoRepositorio();

            candidatoRepositorio.Guardar(this.Candidato);

            this.CandidatoList.RefrescarCandidatos();

            this.ReiniciarCandidato();
        }
    }
}
