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
            throw new NotImplementedException();
        }
        public SolicitudVacanteEditViewModel(
            SolicitudVacantesService solicitudVacantesService
       
            )
        {
            this.solicitudVacantesService= solicitudVacantesService
                

        }
        protected override Task<SolicitudVacante> CargarNuevo()
        {
            throw new NotImplementedException();
        }

        protected override Task Insert()
        {
            this.solicitudVacantesService.Insert(this.Model);
        }

        protected override Task Update()
        {
            
        }
    }
}
