using ReclutaCV.Base.Edit;
using ReclutaCVData.Entidades;
using ReclutaCVLogic.Servicios;
using ReclutaCVLogic.Utils.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReclutaCV.Ventanas.Catalogos.SolicitudesVacante.Edit
{
    public class SolicitudVacanteEditViewModel : BaseEditViewModel<SolicitudVacante, SolicitudVacanteEditView, int>
    {

        public SolicitudVacanteEditViewModel(
            SolicitudVacantesService solicitudVacantesService
        )
        {
            this.solicitudVacantesService = solicitudVacantesService;
        }

        protected override async Task Insert()
        {
            await this.solicitudVacantesService.Insert(this.Model);
        }

        protected override async Task Update()
        {
            this.solicitudVacantesService.Update(this.Model);
            return TaskHelper.CreateEmptyTask();
        }
        protected override Task<SolicitudVacante> CargarExistente(int id)
        {
            return Task.FromResult(this.solicitudVacantesService.FindById(id));
        }
        protected override Task<SolicitudVacante> CargarNuevo()
        {
            return Task.FromResult(new SolicitudVacante());
            await this.solicitudVacantesService.Update(this.Model);
        }
    }
}
