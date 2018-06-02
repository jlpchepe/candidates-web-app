using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReclutaCVData
{
    public enum RolFungidoProyecto
    {
        LiderTecnico,
        AdministradorProyecto,
        IngenieroSoftware
    }   

    public class Proyecto
    {
        public int TipoProyecto { get; set; }
        public int DuracionEnMeses { get; set; }
        public string LenguajeDeProgramacion { get; set; }
        public int NumeroDeIntegrantes { get; set; }
        public string RolFungido { get; set; }

    }
}
