using ReclutaCVLogic.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReclutaCVLogic.Reportes
{
    /// <summary>
    /// Clase encargada de generar reportes RDLC
    /// </summary>
    public class GeneradorReporteRdlc : GeneradorReporteCandidatos
    {
        private Reporte GenerarReporte(
            string datasourceName,
            IReadOnlyList<object> datasourceRows
        )
        {
            return null;
        }

        Reporte GeneradorReporteCandidatos.GenerarReporteCandidatos(
            IReadOnlyList<FilaReporteCandidato> candidatos
        )
        {
            return GenerarReporte("Candidatos", candidatos);
        }
    }
}