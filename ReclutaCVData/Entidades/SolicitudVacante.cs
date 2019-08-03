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
        [Description("Comercialización")]
        Comercial,
        [Description("Administración y finanzas - Capital Humano")]
        AdministracionYFinanzasCapitalHumano,
        [Description("Administración y finanzas - Contable y Fiscal")]
        AdministracionYFinanzasasContableYFiscal,
        [Description("Producción - Operación")]
        ProduccionOperacion,
        [Description("Producción - Mesa de Servicios")]
        ProduccionMesaDeServicios,
        [Description("Tecnologías y procesos")]
        TecnologiasYProcesos,
        [Description("Dirección General")]
        DirecciónGeneral,
        Otro
    }


    public enum MotivoSolicitud
    {
        PuestoNuevo,
        Incapacidad,
        Reemplazo,
        Proyecto,
        Practicante,
        Otro
    }
        
    public enum TipoDeContrato
    {
        [Description("Proyecto especifico")]
        ProyectoEspecifico,
        [Description("Periodo especifico")]
        PeriodoEspecifico,
        [Description("Tiempo indefinido")]
        TiempoIndefinido,
        Otro
    }

    public enum EstatusSolicitud
    {
        Autorizada,
        NoAutorizada,
        Cancelada,
        Detenida,

    }
    public class SolicitudVacante
    {
        [Key]
        public int Id { get; set; }
        public int FolioCapitalHumano { get; set; }
        public DateTime FechaDeSolicitud { get; set; } = DateTime.Now;
        public MotivoSolicitud Motivo { get; set; } = MotivoSolicitud.Proyecto;
        public string EspecifiqueMotivo { get; set; }
        public string NombreDelSolicitante { get; set; }
        public string PuestoDelSolicitante { get; set; }
        public AreaDelSolicitante AreaDelSolicitante { get; set; } = AreaDelSolicitante.ProduccionOperacion;
        public string EspecifiqueAreaDelSolicitante { get; set; }
        public int? Sueldo { get; set; }
        public TipoDeContrato TipoDeContrato { get; set; } = TipoDeContrato.TiempoIndefinido;
        public string EspecifiqueTipoDeContrato { get; set; }
        public EstatusSolicitud Estatus { get; set; } = EstatusSolicitud.NoAutorizada;
        public RolCandidato PuestoSolicitado { get; set; } = RolCandidato.IngenieroDeSoftware;
        public string EspecifiquePuestoSolicitado { get; set; }
        public NivelCandidato PuestoSolicitadoNivel { get; set; } = NivelCandidato.NoEspecificado;
        public string NombreDelJefeInmediato { get; set; }
        public string Proyecto { get; set; }
        public decimal? NivelIdiomaIngles { get; set; }
        public string EdadRango { get; set; }
        public string EstadoCivil { get; set; }
        public DateTime? FechaEstimadaDeIngreso { get; set; }
        public string ExperienciaLaboral { get;  set; }
        public string CompetenciasOHabilidades { get; set; }
        public string CertificacionesNecesarias { get; set; }
        public string TipoDeEvaluacion { get; set; }
        public string Observaciones { get; set; }
    }
}
