using ReclutaCVData.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ReclutaCVApi.Dtos
{
    public class SolicitudVacanteUpdatable : SolicitudVacanteConsultable
    {
    }

    public class SolicitudVacanteInsertable : SolicitudVacanteConsultable
    {

    }

    public class SolicitudVacanteConsultable
    {
        public SolicitudVacanteConsultable() { }
        public SolicitudVacanteConsultable(
            int? id,
            int folioCapitalHumano,
            DateTime fechaDeSolicitud,
            MotivoSolicitud motivo,
            string especifiqueMotivo,
            string nombreDelSolicitante,
            string puestoDelSolicitante,
            AreaDelSolicitante areaDelSolicitante,
            string especifiqueAreaDelSolicitante,
            int? sueldo,
            TipoDeContrato tipoDeContrato,
            string especifiqueTipoDeContrato,
            EstatusSolicitud estatus,
            RolCandidato puestoSolicitado,
            string especifiquePuestoSolicitado,
            NivelCandidato? puestoSolicitadoNivel,
            string nombreDelJefeInmediato,
            string proyecto,
            decimal? nivelIdiomaIngles,
            string edadRango,
            string estadoCivil,
            DateTime? fechaEstimadaDeIngreso,
            string experienciaLaboral,
            string competenciasOHabilidades,
            string certificacionesNecesarias,
            string tipoDeEvaluacion,
            string observaciones
        )
        {
            Id = id;
            FolioCapitalHumano = folioCapitalHumano;
            FechaDeSolicitud = fechaDeSolicitud;
            Motivo = motivo;
            EspecifiqueMotivo = especifiqueMotivo;
            NombreDelSolicitante = nombreDelSolicitante;
            PuestoDelSolicitante = puestoDelSolicitante;
            AreaDelSolicitante = areaDelSolicitante;
            EspecifiqueAreaDelSolicitante = especifiqueAreaDelSolicitante;
            Sueldo = sueldo;
            TipoDeContrato = tipoDeContrato;
            EspecifiqueTipoDeContrato = especifiqueTipoDeContrato;
            Estatus = estatus;
            PuestoSolicitado = puestoSolicitado;
            EspecifiquePuestoSolicitado = especifiquePuestoSolicitado;
            PuestoSolicitadoNivel = puestoSolicitadoNivel;
            NombreDelJefeInmediato = nombreDelJefeInmediato;
            Proyecto = proyecto;
            NivelIdiomaIngles = nivelIdiomaIngles;
            EdadRango = edadRango;
            EstadoCivil = estadoCivil;
            FechaEstimadaDeIngreso = fechaEstimadaDeIngreso;
            ExperienciaLaboral = experienciaLaboral;
            CompetenciasOHabilidades = competenciasOHabilidades;
            CertificacionesNecesarias = certificacionesNecesarias;
            TipoDeEvaluacion = tipoDeEvaluacion;
            Observaciones = observaciones;
        }

        public int? Id { get; set; }
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
        public NivelCandidato? PuestoSolicitadoNivel { get; set; }
        public string NombreDelJefeInmediato { get; set; }
        public string Proyecto { get; set; }
        public decimal? NivelIdiomaIngles { get; set; }
        public string EdadRango { get; set; }
        public string EstadoCivil { get; set; }
        public DateTime? FechaEstimadaDeIngreso { get; set; }
        public string ExperienciaLaboral { get; set; }
        public string CompetenciasOHabilidades { get; set; }
        public string CertificacionesNecesarias { get; set; }
        public string TipoDeEvaluacion { get; set; }
        public string Observaciones { get; set; }
    }
}