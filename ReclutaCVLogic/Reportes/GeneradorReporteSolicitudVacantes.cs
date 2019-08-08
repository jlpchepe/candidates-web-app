using ReclutaCVLogic.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReclutaCVLogic.Reportes
{
    public interface GeneradorReporteSolicitudVacantes
    {
        Task<Reporte> GenerarReporteSolicitudVacantes(IReadOnlyList<FilaReporteSolicitudVacante> solicitudes);
    }
}
