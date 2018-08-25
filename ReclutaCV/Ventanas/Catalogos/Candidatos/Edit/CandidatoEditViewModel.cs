using ReclutaCV.Candidatos.List;
using ReclutaCV.Interfaces;
using ReclutaCV.Utils.Commands;
using ReclutaCV.Utils.Eventos;
using ReclutaCVData;
using ReclutaCVData.Entidades;
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
    public class CandidatoEditViewModel : ISaveEntity
    {
        public CandidatoEditViewModel(
            CandidatoService candidatoService
        )
        {
            this.candidatoService = candidatoService;
        }

        public event ActionEventHandler OnClosed;
        public event ActionEventHandler OnSavedEntity;

        private readonly CandidatoService candidatoService;
        private CandidatoEditView Ventana;

        public Candidato Candidato { get; set; }

        public ICommand GuardarCandidato => new SimpleCommand(this.Guardar);
        public ICommand Cerrar => new SimpleCommand(this.CerrarVentana);

        private void ReiniciarCandidato()
        {
            this.Candidato = new Candidato();
        }

        public void Insert()
        {
            this.candidatoService.Insert(this.Candidato);
        }
        public void Update()
        {
            this.candidatoService.Update(this.Candidato);

        }

        protected bool Editando { get; private set; }

        private void Guardar()
        {
            if (this.Editando)
            {
                this.Update();

            }
            else
            {
                Insert();
            }

            this.OnSavedEntity?.Invoke();
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
            this.Candidato = this.candidatoService.FindById(id);
            this.AbrirVentana();
        }

        private void AbrirVentana()
        {
            this.Ventana = new CandidatoEditView
            {
                DataContext = this
            };

            this.Ventana.Closed += (o, s) => this.CerrarVentana();
            this.Ventana.Show();
        }

        private void CerrarVentana()
        {
            this.Ventana.Close();
            this.OnClosed?.Invoke();
        }
    }
}
