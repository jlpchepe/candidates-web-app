using ReclutaCV.Base.List;
using ReclutaCV.Ventanas.Catalogos.SolicitudesVacante.Edit;
using ReclutaCVData.Entidades;
using ReclutaCVLogic.Servicios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReclutaCV.Ventanas.Catalogos.SolicitudesVacante.List
{
    public class SolicitudVacanteListViewModel : BaseListViewModel<SolicitudVacante, SolicitudVacanteListView, SolicitudVacanteEditViewModel>
    {
        public SolicitudVacanteListViewModel(
            SolicitudVacantesService SolicitudVacanteService,
            Func<SolicitudVacanteEditViewModel> SolicitudVacanteEditViewModelFactory
            )
        {

        }

        protected override Task<IReadOnlyCollection<SolicitudVacante>> ObtenerItems()
        {
            throw new NotImplementedException();
        }

        protected override Task OnAgregar()
        {
            throw new NotImplementedException();
        }

        protected override Task OnBorrar(SolicitudVacante item)
        {
            throw new NotImplementedException();
        }

        protected override Task OnEditar(SolicitudVacante item)
        {
            throw new NotImplementedException();
        }
    }
}
