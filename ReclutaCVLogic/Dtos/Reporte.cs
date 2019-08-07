using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReclutaCVLogic.Dtos
{
    /// <summary>
    /// Representa la información de un reporte generado por el sistema
    /// </summary>
    public class Reporte
    {
        public Reporte(
            string nombreConExtension, 
            byte[] contenido
        )
        {
            NombreConExtension = nombreConExtension;
            Contenido = contenido;
        }

        public string NombreConExtension { get; set; }
        public byte[] Contenido { get; set; }
    }
}
