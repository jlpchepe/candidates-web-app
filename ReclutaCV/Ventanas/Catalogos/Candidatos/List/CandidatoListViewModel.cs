using PropertyChanged;
using ReclutaCV.Base.List;
using ReclutaCV.Candidatos.Edit;
using ReclutaCV.Utils.Commands;
using ReclutaCVData;
using ReclutaCVData.Entidades;
using ReclutaCVLogic.Servicios;
using ReclutaCVLogic.Utils.Helpers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace ReclutaCV.Candidatos.List
{
    [ImplementPropertyChanged]
    public class CandidatoListViewModel : BaseListViewModel<Candidato, CandidatoListView, CandidatoEditViewModel>
    {
        public CandidatoListViewModel(
            CandidatoService candidatoService,
            Func<CandidatoEditViewModel> candidatoEditViewModelFactory
        )
        {
            this.candidatoService = candidatoService;
            this.candidatoEditViewModelFactory = candidatoEditViewModelFactory;

            this.RefrescarItemsSync();
        }

        private readonly CandidatoService candidatoService;

        private readonly Func<CandidatoEditViewModel> candidatoEditViewModelFactory;

        private CandidatoEditViewModel ObtenerVentanaEdicion() {
            var ventanaEdicion = this.candidatoEditViewModelFactory();
            ventanaEdicion.OnSavedEntity += () => this.RefrescarItemsSync();

            return ventanaEdicion;
        }

        protected override Task<IReadOnlyCollection<Candidato>> ObtenerItems()
        {
            return Task.FromResult(this.candidatoService.FindAll());
        }

        protected override async Task OnAgregar()
        {
            await this.ObtenerVentanaEdicion().CargarNuevoYAbrirVentana();
        }

        protected override async Task OnEditar(Candidato item)
        {
            await this.ObtenerVentanaEdicion().CargarExistenteYAbrirVentana(item.Id);
        }

        protected override Task OnBorrar(Candidato item)
        {
            this.candidatoService.Delete(item.Id);
            return TaskHelper.CreateEmptyTask();
        }
    }
}
