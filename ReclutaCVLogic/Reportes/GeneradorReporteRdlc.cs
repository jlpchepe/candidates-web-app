using Microsoft.Reporting.WebForms;
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
    public class GeneradorReporteRdlc : GeneradorReporteCandidatos, GeneradorReporteSolicitudVacantes
    {
        private Task<Reporte> GenerarReporte(
            string reportNameWithoutExtension,
            string rdlcReportNameWithoutExtension,
            string datasourceName,
            IReadOnlyList<object> datasourceRows
        )
        {
            return Task.FromResult(
                new Reporte(
                    reportNameWithoutExtension + ".xls", 
                    GenerateReport(
                        rdlcReportNameWithoutExtension,
                        ReportFormat.Excel,
                        datasourceName,
                        datasourceRows
                    )
                )
            );
        }

        Task<Reporte> GeneradorReporteCandidatos.GenerarReporteCandidatos(
            IReadOnlyList<FilaReporteCandidato> candidatos
        )
        {
            return GenerarReporte(
                "Reporte de candidatos", 
                "ReporteCandidatos", 
                "Candidatos", 
                candidatos
            );
        }

        Task<Reporte> GeneradorReporteSolicitudVacantes.GenerarReporteSolicitudVacantes(
            IReadOnlyList<FilaReporteSolicitudVacante> solicitudes
        )
        {
            return GenerarReporte(
                "Reporte de solicitudes de vacantes", 
                "ReporteSolicitudVacantes", 
                "Solicitudes", 
                solicitudes
            );
        }

        /// <summary>
        /// Exporta el reporte indicado al formato <see cref="ReportFormat"/> que se especifique
        /// </summary>
        /// <typeparam name="TItem"></typeparam>
        /// <param name="rdlcReportNameWithoutExtension"></param>
        /// <param name="format"></param>
        /// <param name="dataSet"></param>
        /// <returns></returns>
        private byte[] GenerateReport<TItem>(
            string rdlcReportNameWithoutExtension,
            ReportFormat format, 
            string datasetName,
            IReadOnlyList<TItem> datasetItems
        )
        {
            // Se encuentra el recurso embebido que concuerde con el nombre del reporte
            var reportFileName = $"{rdlcReportNameWithoutExtension}.rdlc";
            var reportEmbeddedResourceName =
                GetType().Assembly
                .GetManifestResourceNames()
                .FirstOrDefault(resourceName => resourceName.Contains(reportFileName));

            var localReport = new LocalReport
            {
                ReportEmbeddedResource = reportEmbeddedResourceName
            };

            var renderFormat = ReportFormatToLocalReportRenderFormat(format);

            localReport.DataSources.Add(new ReportDataSource(datasetName, datasetItems));

            return localReport.Render(renderFormat);
        }

        /// <summary>
        /// A partir del formato <see cref="ReportFormat"/> indicado, obtiene el reporte
        /// </summary>
        /// <param name="format"></param>
        /// <returns></returns>
        private string ReportFormatToLocalReportRenderFormat(ReportFormat format)
        {
            switch (format)
            {
                case ReportFormat.Excel: return "excel";
                case ReportFormat.Pdf: return "pdf";
                default: throw new ArgumentOutOfRangeException(nameof(format));
            }
        }
    }
}