using ReclutaCVData.Entidades;
using ReclutaCVLogic.Utils.Extensions;
using ReclutaCVLogic.Utils.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReclutaCVLogic.Dtos
{
    /// <summary>
    /// Una fila del reporte de candidatos
    /// </summary>
    public class FilaReporteCandidato
    {
        public int? Id { get; set; }
        //Datos generales
        public string Nombre { get; set; }
        public string Correo { get; set; }
        public string Telefono { get; set; }
        public DateTime? FechaDeNacimiento { get; set; }
        public string EstadoCivil { get; set; }
        public string LugarNacimiento { get; set; }
        public string GeneralesComentarios { get; set; }
        public DateTime? FechaDeActualizacion { get; set; }

        // Experiencia laboral
        public string Compañia { get; set; }
        public decimal? AñosDeExperiencia { get; set; }
        public decimal? SueldoActual { get; set; }
        public string MotivoDeSeparacion { get; set; }

        // Educación
        public string Carrera { get; set; }
        public string Institucion { get; set; }
        public EstatusAcademico? EstatusAcademico { private get; set; }
        public string EstatusAcademicoNombre => EstatusAcademico?.GetDescription();
        public string Cursos { get; set; }
        public string Certificaciones { get; set; }
        public string CompetenciasOHabilidades { get; set; }
        public string TecnologiasQueDomina { get; set; }
        public string SoftwareQueDomina { get; set; }

        // Inglés
        public string NivelDeIngles { get; set; }
        public decimal? NivelDeInglesHablado { get; set; }
        public decimal? NivelDeInglesEscrito { get; set; }
        public decimal? NivelDeInglesLectura { get; set; }

        // Proceso de reclutamiento
        public int? SolicitudPersonalFolio { get; set; }
        public int? PuestoClave { get; set; }
        public string PuestoNombre { get; set; }
        public string ProyectoNombre { get; set; }
        public DateTime? FechaDeRecepcionCurriculum { get; set; }
        public DateTime? FechaDeContacto { get; set; }
        public DateTime? FechaPreentrevistaTelefonica { get; set; }
        public DateTime? FechaRecepcionSolicitudRegistro { get; set; }
        public string QuienLoContacto { get; set; }
        public BolsaTrabajo? Bolsa { private get; set; }
        public string BolsaOtra { private get; set; }
        public string BolsaNombre => Bolsa == BolsaTrabajo.OtraBolsa ? BolsaOtra : Bolsa?.GetDescription();
        public RolCandidato? Rol { private get; set; }
        public string RolOtro { private get; set; }
        public string RolNombre => Rol == RolCandidato.Otro ? RolOtro : Rol?.GetDescription();
        public decimal? ExpectativaEconomica { get; set; }
        public EstatusCandidato? Estatus { get; set; }
        public string EstatusNombre => Estatus?.GetDescription();
        public string ReclutamientoComentarios { get; set; }

        // Examen psicometrico
        public string ExamenPsicometricoNombre { get; set; }
        public string ExamenPsicometricoResultados { get; set; }
        public string ExamenPsicometricoObservaciones { get; set; }

        // Examen de programación
        public DateTime? ExamenProgramacionFecha { get; set; }
        public string ExamenProgramacionIpComputadora { get; set; }
        public string ExamenProgramacionId { get; set; }
        public int? ExamenProgramacionUmlCalificacion { get; set; }
        public int? ExamenProgramacionUmlTotalReactivos { get; set; }
        public int? ExamenProgramacionAdooCalificacion { get; set; }
        public int? ExamenProgramacionAdooTotalReactivos { get; set; }
        public int? ExamenProgramacionPooCalificacion { get; set; }
        public int? ExamenProgramacionPooTotalReactivos { get; set; }
        public int? ExamenProgramacionLogicaCalificacion { get; set; }
        public int? ExamenProgramacionLogicaTotalReactivos { get; set; }
        public int? ExamenProgramacionWebCalificacion { get; set; }
        public int? ExamenProgramacionWebTotalReactivos { get; set; }
        public int? ExamenProgramacionJavascriptCalificacion { get; set; }
        public int? ExamenProgramacionJavascriptTotalReactivos { get; set; }
        public int? ExamenProgramacionScrumCalificacion { get; set; }
        public int? ExamenProgramacionScrumTotalReactivos { get; set; }
        public int? ExamenProgramacionTecnologiaCalificacion { get; set; }
        public int? ExamenProgramacionTecnologiaTotalReactivos { get; set; }
        public int? ExamenProgramacionAciertos { get; set; }
        public int? ExamenProgramacionTotalReactivos { get; set; }
        public string ExamenProgramacionRango { get; set; }

        // Examen de analista
        public DateTime? ExamenAnalistaFecha { get; set; }
        public string ExamenAnalistaIpComputadora { get; set; }
        //// Teórico
        public string ExamenAnalistaTeoricoId { get; set; }
        public int? ExamenAnalistaTeoricoAciertos { get; set; }
        public int? ExamenAnalistaTeoricoTotalReactivos { get; set; }
        public string ExamenAnalistaTeoricoRango { get; set; }
        //// Práctico
        public string ExamenAnalistaPracticoId { get; set; }
        public int? ExamenAnalistaPracticoNumeroCaso { get; set; }
        public int? ExamenAnalistaPracticoAciertos { get; set; }
        public int? ExamenAnalistaPracticoTotalReactivos { get; set; }
        public string ExamenAnalistaPracticoRango { get; set; }

        // Examen de ingeniero de pruebas
        public DateTime? ExamenIngenieroPruebasFecha { get; set; }
        public string ExamenIngenieroPruebasIpComputadora { get; set; }
        //// Teórico
        public int? ExamenIngenieroPruebasTeoricoId { get; set; }
        public int? ExamenIngenieroPruebasTeoricoAciertos { get; set; }
        public int? ExamenIngenieroPruebasTeoricoTotalReactivos { get; set; }
        public string ExamenIngenieroPruebasTeoricoRango { get; set; }
        //// Práctico
        public int? ExamenIngenieroPruebasPracticoId { get; set; }
        public decimal? ExamenIngenieroPruebasPracticoCalificacion { get; set; }
        public int? ExamenIngenieroPruebasPracticoPuntos { get; set; }
        public string ExamenIngenieroPruebasPracticoRango { get; set; }
        //// SQL
        public int? ExamenIngenieroPruebasSqlTotalReactivos { get; set; }
        public decimal? ExamenIngenieroPruebasSqlCalificacion { get; set; }

        // Examen de administrador de proyectos
        public DateTime? ExamenAdministradorProyectoFecha { get; set; }
        public string ExamenAdministradorProyectoIpComputadora { get; set; }
        public int? ExamenAdministradorProyectoId { get; set; }
        public int? ExamenAdministradorProyectoAciertos { get; set; }
        public int? ExamenAdministradorProyectoTotalReactivos { get; set; }
        public string ExamenAdministradorProyectoRango { get; set; }

        // Examen de soporte - BD
        public DateTime? ExamenPracticoSoporteBdFecha { get; set; }
        public int? ExamenPracticoSoporteBdAciertos { get; set; }
        public int? ExamenPracticoSoporteBdTotalReactivos { get; set; }
        public string ExamenPracticoSoporteBdRango { get; set; }

        // Etapa de entrevistas
        public DateTime? EntrevistaCapitalHumanoFecha { get; set; }
        public string EntrevistaCapitalHumanoComentarios { get; set; }
        public DateTime? EntrevistaCoordinadorYEquipoTecnicoFecha { get; set; }
        public string EntrevistaCoordinadorYEquipoTecnicoComentarios { get; set; }
        public DateTime? EntrevistaInglesFecha { get; set; }
        public string EntrevistaInglesComentarios { get; set; }
        public DateTime? EntrevistaGerenteAreaFecha { get; set; }
        public string EntrevistaGerenteAreaComentarios { get; set; }
        public VeredictoFinalCandidato? VeredictoFinal { private get; set; }
        public string VeredictoFinalNombre => VeredictoFinal?.GetDescription();
        public string VeredictoFinalNivelIdentificado { get; set; }
        public string VeredictoFinalComentarios { get; set; }

        // Propuesta económica
        public DateTime? PropuestaEconomicaFecha { get; set; }
        public PropuestaEconomicaEstatus? PropuestaEconomicaEstatus { private get; set; }
        public string PropuestaEconomicaEstatusNombre => PropuestaEconomicaEstatus?.GetDescription();
        public decimal? PropuestaEconomicaSueldo { get; set; }
        public string PropuestaEconomicaComentarios { get; set; }

        // Ingreso
        public DateTime? IngresoFecha { get; set; }
        public string IngresoTipoContrato { get; set; }
        public DateTime? IngresoVencimientoContratoDeterminado { get; set; }
        public string IngresoObservaciones { get; set; }
    }
}