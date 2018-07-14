using ReclutaCV.Candidatos.List;
using ReclutaCVData.Entidades;
using ReclutaCVLogic.Repositorio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace ReclutaCV.Candidatos.Edit
{
    /// <summary>
    /// Ventana para edición de candidatos
    /// </summary>
    public class CandidatoEditViewModel
    {
        public CandidatoEditViewModel()
        {
            
        }

        public Candidato Candidato { get; set; }
        public CandidatoListViewModel CandidatoList { get; }

        void ReiniciarCandidato()
        {
            this.Candidato = new Candidato();
        }

        private void GuardarCandidato(object sender, RoutedEventArgs e)
        {
            var candidatoRepositorio = new CandidatoRepositorio();

            candidatoRepositorio.Guardar(this.Candidato);

            this.CandidatoList.RefrescarCandidatos();

            this.ReiniciarCandidato();
        }
    }
}
