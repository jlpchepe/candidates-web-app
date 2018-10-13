using ReclutaCV.Base.List;
using ReclutaCV.Ventanas.Catalogos.SolicitudesVacante.Edit;
using ReclutaCVData.Entidades;
using ReclutaCVLogic.Servicios;
using ReclutaCVLogic.Utils.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReclutaCV.Ventanas.Catalogos.SolicitudesVacante.List
{
    public class SolicitudVacanteListViewModel : BaseListViewModel<SolicitudVacante, SolicitudVacanteListView, SolicitudVacanteEditViewModel>
    {
        private readonly SolicitudVacantesService solicitudVacanteService;
        private readonly Func<SolicitudVacanteEditViewModel> solicitudVacanteEditViewModelFactory;

        public SolicitudVacanteListViewModel(
            SolicitudVacantesService SolicitudVacanteService,
            Func<SolicitudVacanteEditViewModel> SolicitudVacanteEditViewModelFactory
            )
        {
            solicitudVacanteService = SolicitudVacanteService;
            solicitudVacanteEditViewModelFactory = SolicitudVacanteEditViewModelFactory;

            this.RefrescarItemsSync();
        }

        protected override Task<IReadOnlyCollection<SolicitudVacante>> ObtenerItems()
        {
            return this.solicitudVacanteService.FindAll();
        }

        protected override async Task OnAgregar()
        {
            await this.solicitudVacanteEditViewModelFactory().CargarNuevoYAbrirVentana();
        }

        protected override async Task OnBorrar(SolicitudVacante item)
        {
            await this.solicitudVacanteService.Delete(item.Id);
        }

        protected override async Task OnEditar(SolicitudVacante item)
        {
            await this.solicitudVacanteEditViewModelFactory().CargarExistenteYAbrirVentana(item.Id);

        }
    }
}
