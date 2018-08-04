using ReclutaCV.Candidatos.List;
using ReclutaCV.Utils.Commands;
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
        public CandidatoEditViewModel(CandidatoService candidatoService)
        {
            this.ReiniciarCandidato();
            this.CandidatoService = candidatoService;
        }

        private CandidatoEditView Ventana;
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

        public void CargarNuevoYAbrirVentana()
        {
            this.Editando = false;
            this.Candidato = new Candidato();
            this.AbrirVentana();


        }
        public void CargarExistenteYAbrirVentana(int id)
        {
            this.Editando = true;
            this.Candidato= this.CandidatoService.FindById(id);
            this.AbrirVentana();
        }

        private void AbrirVentana()
        {
            this.Ventana = new CandidatoEditView();
            this.Ventana.DataContext = this;
            this.Ventana.InitializeComponent();
            this.Ventana.Show();
        }

        public ICommand GuardarCandidato => new SimpleCommand(this.Guardar);
        private void CerrarVentana()
        {
            this.Ventana.Close();
        }

        public ICommand Cerrar => new SimpleCommand(this.CerrarVentana);

        public CandidatoService CandidatoService { get; }
    }
}
