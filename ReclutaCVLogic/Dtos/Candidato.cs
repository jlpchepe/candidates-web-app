﻿using ReclutaCVData.Entidades;
using System;

namespace ReclutaCVLogic.Dtos
{
    public class CandidatoCurriculumConsultable {
        public byte[] Curriculum { get; set; }
        public string CurriculumFileName { get; set; }
    }

    public class CandidatoCurriculumToSave
    {
        public int CandidatoId { get; set; }
        
    }

    public class CandidatoInsertable : CandidatoConsultable
    {
    }

    public class CandidatoUpdatable : CandidatoConsultable
    {
    }

    public class CandidatoConsultable
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
        public EstatusAcademico? EstatusAcademico { get; set; }
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
        public BolsaTrabajo? Bolsa { get; set; }
        public string BolsaOtra { get; set; }
        public RolCandidato? Rol { get; set; }
        public string RolOtro { get; set; }
        public decimal? ExpectativaEconomica { get; set; }
        public EstatusCandidato? Estatus { get; set; }
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
        public VeredictoFinalCandidato? VeredictoFinal { get; set; }
        public string VeredictoFinalNivelIdentificado { get; set; }
        public string VeredictoFinalComentarios { get; set; }

        // Propuesta económica
        public DateTime? PropuestaEconomicaFecha { get; set; }
        public PropuestaEconomicaEstatus? PropuestaEconomicaEstatus { get; set; }
        public decimal? PropuestaEconomicaSueldo { get; set; }
        public string PropuestaEconomicaComentarios { get; set; }

        // Ingreso
        public DateTime? IngresoFecha { get; set; }
        public string IngresoTipoContrato { get; set; }
        public DateTime? IngresoVencimientoContratoDeterminado { get; set; }
        public string IngresoObservaciones { get; set; }
        public byte[] Curriculum { get; set; }
        public string CurriculumFileName { get; set; }

        public CandidatoConsultable() { }

        public CandidatoConsultable(
            int? id,
            string nombre,
            string correo,
            string telefono,
            DateTime? fechaDeNacimiento,
            string estadoCivil,
            string lugarNacimiento,
            string generalesComentarios,
            DateTime? fechaDeActualizacion,
            string compañia,
            decimal? añosDeExperiencia,
            decimal? sueldoActual,
            string motivoDeSeparacion,
            string carrera,
            string institucion,
            EstatusAcademico? estatusAcademico,
            string cursos,
            string certificaciones,
            string competenciasOHabilidades,
            string tecnologiasQueDomina,
            string softwareQueDomina,
            string nivelDeIngles,
            decimal? nivelDeInglesHablado,
            decimal? nivelDeInglesEscrito,
            decimal? nivelDeInglesLectura,
            int? solicitudPersonalFolio,
            int? puestoClave,
            string puestoNombre,
            string proyectoNombre,
            DateTime? fechaDeRecepcionCurriculum,
            DateTime? fechaDeContacto,
            DateTime? fechaPreentrevistaTelefonica,
            DateTime? fechaRecepcionSolicitudRegistro,
            string quienLoContacto,
            BolsaTrabajo? bolsa,
            string bolsaOtra,
            RolCandidato? rol,
            string rolOtro,
            decimal? expectativaEconomica,
            EstatusCandidato? estatus,
            string reclutamientoComentarios,
            string examenPsicometricoNombre,
            string examenPsicometricoResultados,
            string examenPsicometricoObservaciones,
            DateTime? examenProgramacionFecha,
            string examenProgramacionIpComputadora,
            string examenProgramacionId,
            int? examenProgramacionUmlCalificacion,
            int? examenProgramacionUmlTotalReactivos,
            int? examenProgramacionAdooCalificacion,
            int? examenProgramacionAdooTotalReactivos,
            int? examenProgramacionPooCalificacion,
            int? examenProgramacionPooTotalReactivos,
            int? examenProgramacionLogicaCalificacion,
            int? examenProgramacionLogicaTotalReactivos,
            int? examenProgramacionWebCalificacion,
            int? examenProgramacionWebTotalReactivos,
            int? examenProgramacionJavascriptCalificacion,
            int? examenProgramacionJavascriptTotalReactivos,
            int? examenProgramacionScrumCalificacion,
            int? examenProgramacionScrumTotalReactivos,
            int? examenProgramacionTecnologiaCalificacion,
            int? examenProgramacionTecnologiaTotalReactivos,
            int? examenProgramacionAciertos,
            int? examenProgramacionTotalReactivos,
            string examenProgramacionRango,
            DateTime? examenAnalistaFecha,
            string examenAnalistaIpComputadora,
            string examenAnalistaTeoricoId,
            int? examenAnalistaTeoricoAciertos,
            int? examenAnalistaTeoricoTotalReactivos,
            string examenAnalistaTeoricoRango,
            string examenAnalistaPracticoId,
            int? examenAnalistaPracticoNumeroCaso,
            int? examenAnalistaPracticoAciertos,
            int? examenAnalistaPracticoTotalReactivos,
            string examenAnalistaPracticoRango,
            DateTime? examenIngenieroPruebasFecha,
            string examenIngenieroPruebasIpComputadora,
            int? examenIngenieroPruebasTeoricoId,
            int? examenIngenieroPruebasTeoricoAciertos,
            int? examenIngenieroPruebasTeoricoTotalReactivos,
            string examenIngenieroPruebasTeoricoRango,
            int? examenIngenieroPruebasPracticoId,
            decimal? examenIngenieroPruebasPracticoCalificacion,
            int? examenIngenieroPruebasPracticoPuntos,
            string examenIngenieroPruebasPracticoRango,
            int? examenIngenieroPruebasSqlTotalReactivos,
            decimal? examenIngenieroPruebasSqlCalificacion,
            DateTime? examenAdministradorProyectoFecha,
            string examenAdministradorProyectoIpComputadora,
            int? examenAdministradorProyectoId,
            int? examenAdministradorProyectoAciertos,
            int? examenAdministradorProyectoTotalReactivos,
            string examenAdministradorProyectoRango,
            DateTime? examenPracticoSoporteBdFecha,
            int? examenPracticoSoporteBdAciertos,
            int? examenPracticoSoporteBdTotalReactivos,
            string examenPracticoSoporteBdRango,
            DateTime? entrevistaCapitalHumanoFecha,
            string entrevistaCapitalHumanoComentarios,
            DateTime? entrevistaCoordinadorYEquipoTecnicoFecha,
            string entrevistaCoordinadorYEquipoTecnicoComentarios,
            DateTime? entrevistaInglesFecha,
            string entrevistaInglesComentarios,
            DateTime? entrevistaGerenteAreaFecha,
            string entrevistaGerenteAreaComentarios,
            VeredictoFinalCandidato? veredictoFinal,
            string veredictoFinalNivelIdentificado,
            string veredictoFinalComentarios,
            DateTime? propuestaEconomicaFecha,
            PropuestaEconomicaEstatus? propuestaEconomicaEstatus,
            decimal? propuestaEconomicaSueldo,
            string propuestaEconomicaComentarios,
            DateTime? ingresoFecha,
            string ingresoTipoContrato,
            DateTime? ingresoVencimientoContratoDeterminado,
            string ingresoObservaciones,
            byte[] curriculum,
            string curriculumFileName
        )
        {
            Id = id;
            Nombre = nombre;
            Correo = correo;
            Telefono = telefono;
            FechaDeNacimiento = fechaDeNacimiento;
            EstadoCivil = estadoCivil;
            LugarNacimiento = lugarNacimiento;
            GeneralesComentarios = generalesComentarios;
            FechaDeActualizacion = fechaDeActualizacion;
            Compañia = compañia;
            AñosDeExperiencia = añosDeExperiencia;
            SueldoActual = sueldoActual;
            MotivoDeSeparacion = motivoDeSeparacion;
            Carrera = carrera;
            Institucion = institucion;
            EstatusAcademico = estatusAcademico;
            Cursos = cursos;
            Certificaciones = certificaciones;
            CompetenciasOHabilidades = competenciasOHabilidades;
            TecnologiasQueDomina = tecnologiasQueDomina;
            SoftwareQueDomina = softwareQueDomina;
            NivelDeIngles = nivelDeIngles;
            NivelDeInglesHablado = nivelDeInglesHablado;
            NivelDeInglesEscrito = nivelDeInglesEscrito;
            NivelDeInglesLectura = nivelDeInglesLectura;
            SolicitudPersonalFolio = solicitudPersonalFolio;
            PuestoClave = puestoClave;
            PuestoNombre = puestoNombre;
            ProyectoNombre = proyectoNombre;
            FechaDeRecepcionCurriculum = fechaDeRecepcionCurriculum;
            FechaDeContacto = fechaDeContacto;
            FechaPreentrevistaTelefonica = fechaPreentrevistaTelefonica;
            FechaRecepcionSolicitudRegistro = fechaRecepcionSolicitudRegistro;
            QuienLoContacto = quienLoContacto;
            Bolsa = bolsa;
            BolsaOtra = bolsaOtra;
            Rol = rol;
            RolOtro = rolOtro;
            ExpectativaEconomica = expectativaEconomica;
            Estatus = estatus;
            ReclutamientoComentarios = reclutamientoComentarios;
            ExamenPsicometricoNombre = examenPsicometricoNombre;
            ExamenPsicometricoResultados = examenPsicometricoResultados;
            ExamenPsicometricoObservaciones = examenPsicometricoObservaciones;
            ExamenProgramacionFecha = examenProgramacionFecha;
            ExamenProgramacionIpComputadora = examenProgramacionIpComputadora;
            ExamenProgramacionId = examenProgramacionId;
            ExamenProgramacionUmlCalificacion = examenProgramacionUmlCalificacion;
            ExamenProgramacionUmlTotalReactivos = examenProgramacionUmlTotalReactivos;
            ExamenProgramacionAdooCalificacion = examenProgramacionAdooCalificacion;
            ExamenProgramacionAdooTotalReactivos = examenProgramacionAdooTotalReactivos;
            ExamenProgramacionPooCalificacion = examenProgramacionPooCalificacion;
            ExamenProgramacionPooTotalReactivos = examenProgramacionPooTotalReactivos;
            ExamenProgramacionLogicaCalificacion = examenProgramacionLogicaCalificacion;
            ExamenProgramacionLogicaTotalReactivos = examenProgramacionLogicaTotalReactivos;
            ExamenProgramacionWebCalificacion = examenProgramacionWebCalificacion;
            ExamenProgramacionWebTotalReactivos = examenProgramacionWebTotalReactivos;
            ExamenProgramacionJavascriptCalificacion = examenProgramacionJavascriptCalificacion;
            ExamenProgramacionJavascriptTotalReactivos = examenProgramacionJavascriptTotalReactivos;
            ExamenProgramacionScrumCalificacion = examenProgramacionScrumCalificacion;
            ExamenProgramacionScrumTotalReactivos = examenProgramacionScrumTotalReactivos;
            ExamenProgramacionTecnologiaCalificacion = examenProgramacionTecnologiaCalificacion;
            ExamenProgramacionTecnologiaTotalReactivos = examenProgramacionTecnologiaTotalReactivos;
            ExamenProgramacionAciertos = examenProgramacionAciertos;
            ExamenProgramacionTotalReactivos = examenProgramacionTotalReactivos;
            ExamenProgramacionRango = examenProgramacionRango;
            ExamenAnalistaFecha = examenAnalistaFecha;
            ExamenAnalistaIpComputadora = examenAnalistaIpComputadora;
            ExamenAnalistaTeoricoId = examenAnalistaTeoricoId;
            ExamenAnalistaTeoricoAciertos = examenAnalistaTeoricoAciertos;
            ExamenAnalistaTeoricoTotalReactivos = examenAnalistaTeoricoTotalReactivos;
            ExamenAnalistaTeoricoRango = examenAnalistaTeoricoRango;
            ExamenAnalistaPracticoId = examenAnalistaPracticoId;
            ExamenAnalistaPracticoNumeroCaso = examenAnalistaPracticoNumeroCaso;
            ExamenAnalistaPracticoAciertos = examenAnalistaPracticoAciertos;
            ExamenAnalistaPracticoTotalReactivos = examenAnalistaPracticoTotalReactivos;
            ExamenAnalistaPracticoRango = examenAnalistaPracticoRango;
            ExamenIngenieroPruebasFecha = examenIngenieroPruebasFecha;
            ExamenIngenieroPruebasIpComputadora = examenIngenieroPruebasIpComputadora;
            ExamenIngenieroPruebasTeoricoId = examenIngenieroPruebasTeoricoId;
            ExamenIngenieroPruebasTeoricoAciertos = examenIngenieroPruebasTeoricoAciertos;
            ExamenIngenieroPruebasTeoricoTotalReactivos = examenIngenieroPruebasTeoricoTotalReactivos;
            ExamenIngenieroPruebasTeoricoRango = examenIngenieroPruebasTeoricoRango;
            ExamenIngenieroPruebasPracticoId = examenIngenieroPruebasPracticoId;
            ExamenIngenieroPruebasPracticoCalificacion = examenIngenieroPruebasPracticoCalificacion;
            ExamenIngenieroPruebasPracticoPuntos = examenIngenieroPruebasPracticoPuntos;
            ExamenIngenieroPruebasPracticoRango = examenIngenieroPruebasPracticoRango;
            ExamenIngenieroPruebasSqlTotalReactivos = examenIngenieroPruebasSqlTotalReactivos;
            ExamenIngenieroPruebasSqlCalificacion = examenIngenieroPruebasSqlCalificacion;
            ExamenAdministradorProyectoFecha = examenAdministradorProyectoFecha;
            ExamenAdministradorProyectoIpComputadora = examenAdministradorProyectoIpComputadora;
            ExamenAdministradorProyectoId = examenAdministradorProyectoId;
            ExamenAdministradorProyectoAciertos = examenAdministradorProyectoAciertos;
            ExamenAdministradorProyectoTotalReactivos = examenAdministradorProyectoTotalReactivos;
            ExamenAdministradorProyectoRango = examenAdministradorProyectoRango;
            ExamenPracticoSoporteBdFecha = examenPracticoSoporteBdFecha;
            ExamenPracticoSoporteBdAciertos = examenPracticoSoporteBdAciertos;
            ExamenPracticoSoporteBdTotalReactivos = examenPracticoSoporteBdTotalReactivos;
            ExamenPracticoSoporteBdRango = examenPracticoSoporteBdRango;
            EntrevistaCapitalHumanoFecha = entrevistaCapitalHumanoFecha;
            EntrevistaCapitalHumanoComentarios = entrevistaCapitalHumanoComentarios;
            EntrevistaCoordinadorYEquipoTecnicoFecha = entrevistaCoordinadorYEquipoTecnicoFecha;
            EntrevistaCoordinadorYEquipoTecnicoComentarios = entrevistaCoordinadorYEquipoTecnicoComentarios;
            EntrevistaInglesFecha = entrevistaInglesFecha;
            EntrevistaInglesComentarios = entrevistaInglesComentarios;
            EntrevistaGerenteAreaFecha = entrevistaGerenteAreaFecha;
            EntrevistaGerenteAreaComentarios = entrevistaGerenteAreaComentarios;
            VeredictoFinal = veredictoFinal;
            VeredictoFinalNivelIdentificado = veredictoFinalNivelIdentificado;
            VeredictoFinalComentarios = veredictoFinalComentarios;
            PropuestaEconomicaFecha = propuestaEconomicaFecha;
            PropuestaEconomicaEstatus = propuestaEconomicaEstatus;
            PropuestaEconomicaSueldo = propuestaEconomicaSueldo;
            PropuestaEconomicaComentarios = propuestaEconomicaComentarios;
            IngresoFecha = ingresoFecha;
            IngresoTipoContrato = ingresoTipoContrato;
            IngresoVencimientoContratoDeterminado = ingresoVencimientoContratoDeterminado;
            IngresoObservaciones = ingresoObservaciones;
        }
    }
}