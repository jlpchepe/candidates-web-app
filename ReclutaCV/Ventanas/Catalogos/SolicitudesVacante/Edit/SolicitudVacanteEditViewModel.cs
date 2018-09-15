using ReclutaCV.Base.Edit;
using ReclutaCVData.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReclutaCV.Ventanas.Catalogos.SolicitudesVacante.Edit
{
    public class SolicitudVacanteEditViewModel : BaseEditViewModel<SolicitudVacante, SolicitudVacanteEditView, int>
    {
        protected override Task<SolicitudVacante> CargarExistente(int id)
        {
            throw new NotImplementedException();
        }

        protected override Task<SolicitudVacante> CargarNuevo()
        {
            throw new NotImplementedException();
        }

        protected override Task Insert()
        {
            throw new NotImplementedException();
        }

        protected override Task Update()
        {
            throw new NotImplementedException();
        }
    }
}
