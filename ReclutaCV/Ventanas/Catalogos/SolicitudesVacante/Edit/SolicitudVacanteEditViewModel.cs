using ReclutaCV.Base.Edit;
using ReclutaCVData.Entidades;
using ReclutaCVLogic.Servicios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReclutaCV.Ventanas.Catalogos.SolicitudesVacante.Edit
{
    public class SolicitudVacanteEditViewModel : BaseEditViewModel<SolicitudVacante, SolicitudVacanteEditView, int>
    {
        private readonly SolicitudVacantesService solicitudVacantesService;

        protected override Task<SolicitudVacante> CargarExistente(int id)
        {
            return null;
        }
        public SolicitudVacanteEditViewModel(
            SolicitudVacantesService solicitudVacantesService
        )
        {
            this.solicitudVacantesService = solicitudVacantesService;
        }

        protected override Task<SolicitudVacante> CargarNuevo()
        {
            return Task.FromResult(new SolicitudVacante());
        }

        protected override async Task Insert()
        {
            await this.solicitudVacantesService.Insert(this.Model);
        }

        protected override async Task Update()
        {
            await this.solicitudVacantesService.Update(this.Model);
        }
    }
}
