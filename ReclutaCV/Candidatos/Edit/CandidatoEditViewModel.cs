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


        public void Insert()
        {
            this.CandidatoService.Insert(this.Candidato);
        }
        public void Update() 
        {
            this.CandidatoService.Update(this.Candidato);

        }
       
        private bool Editando { get; set; }
        private void Guardar ()
        {
            if (this.Editando)
            {
                this.Update();
                
            }else
            {
                Insert();
                
            }
                   
        }

        public void CargarNuevo()
        {
            this.Editando = false;
            this.Candidato = new Candidato();

        }
        public void CargarExistente(int id)
        {
            this.Editando = true;
            this.Candidato= this.CandidatoService.FindById(id);

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
