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
        private readonly SolicitudVacantesService solicitudVacantesService;

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
            await this.solicitudVacantesService.Update(this.Model);
        }
        protected override Task<SolicitudVacante> CargarExistente(int id)
        {
            return this.solicitudVacantesService.FindById(id);
        }
        protected override Task<SolicitudVacante> CargarNuevo()
        {
            var SolicitudVacante = new SolicitudVacante();

            SolicitudVacante.FechaDeSolicitud = DateTime.Now;

            SolicitudVacante.FechaEstimadaDeIngreso = DateTime.Now;

            SolicitudVacante.SexoDelCandidato = Sexo.Indistinto;

          

         
            return Task.FromResult(SolicitudVacante);

        }
    }
}
