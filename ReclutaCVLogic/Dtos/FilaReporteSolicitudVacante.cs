﻿using ReclutaCVData.Entidades;
using ReclutaCVLogic.Utils.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReclutaCVLogic.Dtos
{
    public class FilaReporteSolicitudVacante
    {
        public FilaReporteSolicitudVacante(
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
        public DateTime FechaDeSolicitud { get; set; } 
        public MotivoSolicitud Motivo { private get; set; }
        public string EspecifiqueMotivo { private get; set; }
        public string MotivoNombre => Motivo == MotivoSolicitud.Otro ? EspecifiqueMotivo : Motivo.GetDescription();
        public string NombreDelSolicitante { get; set; }
        public string PuestoDelSolicitante { get; set; }
        public AreaDelSolicitante AreaDelSolicitante { private get; set; }
        public string EspecifiqueAreaDelSolicitante { private get; set; }
        public string AreaDelSolicitanteNombre => AreaDelSolicitante == AreaDelSolicitante.Otro ? EspecifiqueAreaDelSolicitante : AreaDelSolicitante.GetDescription();
        public int? Sueldo { get; set; }
        public TipoDeContrato TipoDeContrato { private get; set; } 
        public string EspecifiqueTipoDeContrato { private get; set; }
        public string TipoDeContratoNombre => TipoDeContrato == TipoDeContrato.Otro ? EspecifiqueTipoDeContrato : TipoDeContrato.GetDescription();
        public EstatusSolicitud Estatus { private get; set; } 
        public string EstatusNombre => Estatus.GetDescription();
        public RolCandidato PuestoSolicitado { private get; set; }
        public string EspecifiquePuestoSolicitado { private get; set; }
        public string PuestoSolicitadoNombre => PuestoSolicitado == RolCandidato.Otro ? EspecifiquePuestoSolicitado : PuestoSolicitado.GetDescription();
        public NivelCandidato? PuestoSolicitadoNivel { private get; set; }
        public string PuestoSolicitadoNivelNombre => PuestoSolicitadoNivel?.GetDescription();
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