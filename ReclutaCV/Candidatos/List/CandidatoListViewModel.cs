using ReclutaCV.Candidatos.Edit;
using ReclutaCV.Utils.Commands;
using ReclutaCVData;
using ReclutaCVData.Entidades;
using ReclutaCVLogic.Servicios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace ReclutaCV.Candidatos.List
{
    public class CandidatoListViewModel
    {

        public CandidatoListViewModel(
            CandidatoService candidatoService,
            CandidatoEditViewModel candidatoEditViewModel
        )
        {
            this.CandidatoService = candidatoService;
            this.candidatoEditViewModel = candidatoEditViewModel;
            this.RefrescarCandidatos();


        }
    
        private readonly CandidatoEditViewModel candidatoEditViewModel;
        public List<Candidato> Items { get; internal set; }
        public CandidatoService CandidatoService { get; }
        public Candidato Seleccionado { get; set; }


        public ICommand Agregar => new SimpleCommand(this.candidatoEditViewModel.CargarNuevoYAbrirVentana);
        public ICommand Editar => new SimpleCommand(() => this.candidatoEditViewModel.CargarExistenteYAbrirVentana(this.Seleccionado.Id), () => this.Seleccionado != null);




        public void RefrescarCandidatos()
        {
            //Cargamos los candidatos desde la base de datos
            this.Items = this.CandidatoService.FindAll();
        }
    }
}
