using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReclutaCVData.Entidades
{
    public enum AreaDelSolicitante
    {
        [Description("Comercial")]
        Comercial,
        [Description("Administración y finanzas")]
        AdministracionYFinanzas,
        [Description("Producción")]
        Produccion,
        [Description("Tecnologías y procesos")]
        TecnologiasYProcesos,
        [Description("Jurídico")]
        Juridico
    }

    public enum EstadoCivil
    {
        Casado,
        Soltero

    }

    public enum Sexo
    {
        Masculino,
        Femenino,
        Indistinto

    }
    public enum InstrumentoDeEvaluacion 
    {
        [Description("Programación")]
        Programación,
            [Description("Mesa de servicios")]
        MesaDeServicios
        
    }

    public class SolicitudVacante
    {
        [Key]
        public int Id { get; set; }
        public string NombreDelSolicitante { get; set; }
        public AreaDelSolicitante AreaDelSolicitante { get; set; }

        public int CantidadDeVacantes { get; set; }
        public DateTime FechaDeSolicitud { get; set; }
        public RolCandidato PuestoSolicitado { get; set; }
        public int CantidadDePersonal { get; set; }
        public decimal NivelIdiomaIngles { get; set; }
        public EstadoCivil EstadoCivil { get; set; } 
        public string EdadRango { get; set; }
        public Sexo SexoDelCandidato { get; set; }
        public string Proyecto { get; set; }
        public DateTime FechaEstimadaDeIngreso { get; set; }
        public string ExperienciaLaboral { get; set; }
        public string CompetenciasOHabilidades { get; set; }
        public string CertificacionesNecesarias { get; set; }
        public InstrumentoDeEvaluacion AplicacionDeInstrumentoDeEvaluacion { get; set; }
        public int Sueldo { get; set; }
        public string Observaciones { get; set; }

    }
}
