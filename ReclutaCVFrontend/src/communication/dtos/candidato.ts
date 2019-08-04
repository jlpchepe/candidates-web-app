export interface CandidatoListable extends CandidatoConsultable {
    
}

export interface CandidatoInsertable extends CandidatoConsultable{
}

export interface CandidatoUpdatable extends CandidatoConsultable{
}

export interface CandidatoConsultable
{
    Id: number | null;
    //Datos generales
    Nombre: string;
    Correo: string;
    Telefono: string;
    FechaDeNacimiento: Date | string | null;
    EstadoCivil: string;
    LugarNacimiento: string;
    GeneralesComentarios: string;
    FechaDeActualizacion: Date | string | null;

    // Experiencia laboral
    Compañia: string;
    AñosDeExperiencia: number | null;
    SueldoActual: number | null;
    MotivoDeSeparacion: string;

    // Educación
    Carrera: string;
    Institucion: string;
    EstatusAcademico: EstatusAcademico;
    Cursos: string;
    Certificaciones: string;
    CompetenciasOHabilidades: string;
    TecnologiasQueDomina: string;
    SoftwareQueDomina: string;

    // Inglés
    NivelDeIngles: string;
    NivelDeInglesHablado: number | null;
    NivelDeInglesEscrito: number | null;
    NivelDeInglesLectura: number | null;

    // Proceso de reclutamiento
    SolicitudPersonalFolio: number | null;
    PuestoClave: number | null;
    PuestoNombre: string;
    ProyectoNombre: string;
    FechaDeRecepcionCurriculum: Date | string | null;
    FechaDeContacto: Date | string | null;
    FechaPreentrevistaTelefonica: Date | string | null;
    FechaRecepcionSolicitudRegistro: Date | string | null;
    QuienLoContacto: string;
    Bolsa: BolsaTrabajo;
    BolsaOtra: string;
    Rol: RolCandidato;
    RolOtro: string;
    ExpectativaEconomica: number | null;
    Estatus: EstatusCandidato;
    ReclutamientoComentarios: string;

    // Examen psicometrico
    ExamenPsicometricoNombre: string;
    ExamenPsicometricoResultados: string;
    ExamenPsicometricoObservaciones: string;

    // Examen de programación
    ExamenProgramacionFecha: Date | string | null;
    ExamenProgramacionIpComputadora: string;
    ExamenProgramacionId: string;
    ExamenProgramacionUmlCalificacion: number | null;
    ExamenProgramacionUmlTotalReactivos: number | null;
    ExamenProgramacionAdooCalificacion: number | null;
    ExamenProgramacionAdooTotalReactivos: number | null;
    ExamenProgramacionPooCalificacion: number | null;
    ExamenProgramacionPooTotalReactivos: number | null;
    ExamenProgramacionLogicaCalificacion: number | null;
    ExamenProgramacionLogicaTotalReactivos: number | null;
    ExamenProgramacionWebCalificacion: number | null;
    ExamenProgramacionWebTotalReactivos: number | null;
    ExamenProgramacionJavascriptCalificacion: number | null;
    ExamenProgramacionJavascriptTotalReactivos: number | null;
    ExamenProgramacionScrumCalificacion: number | null;
    ExamenProgramacionScrumTotalReactivos: number | null;
    ExamenProgramacionTecnologiaCalificacion: number | null;
    ExamenProgramacionTecnologiaTotalReactivos: number | null;
    ExamenProgramacionAciertos: number | null;
    ExamenProgramacionTotalReactivos: number | null;
    ExamenProgramacionRango: string;

    // Examen de analista
    ExamenAnalistaFecha: Date | string | null;
    ExamenAnalistaIpComputadora: string;
    // Teórico
    ExamenAnalistaTeoricoId: string;
    ExamenAnalistaTeoricoAciertos: number | null;
    ExamenAnalistaTeoricoTotalReactivos: number | null;
    ExamenAnalistaTeoricoRango: string;
    // Práctico
    ExamenAnalistaPracticoId: string;
    ExamenAnalistaPracticoNumeroCaso: number | null;
    ExamenAnalistaPracticoAciertos: number | null;
    ExamenAnalistaPracticoTotalReactivos: number | null;
    ExamenAnalistaPracticoRango: string;

    // Examen de ingeniero de pruebas
    ExamenIngenieroPruebasFecha: Date | string | null;
    ExamenIngenieroPruebasIpComputadora: string;
    // Teórico
    ExamenIngenieroPruebasTeoricoId: number | null;
    ExamenIngenieroPruebasTeoricoAciertos: number | null;
    ExamenIngenieroPruebasTeoricoTotalReactivos: number | null;
    ExamenIngenieroPruebasTeoricoRango: string;
    // Práctico
    ExamenIngenieroPruebasPracticoId: number | null;
    ExamenIngenieroPruebasPracticoCalificacion: number | null;
    ExamenIngenieroPruebasPracticoPuntos: number | null;
    ExamenIngenieroPruebasPracticoRango: string;
    // SQL
    ExamenIngenieroPruebasSqlTotalReactivos: number | null;
    ExamenIngenieroPruebasSqlCalificacion: number | null;

    // Examen de administrador de proyectos
    ExamenAdministradorProyectoFecha: Date | string | null;
    ExamenAdministradorProyectoIpComputadora: string;
    ExamenAdministradorProyectoId: number | null;
    ExamenAdministradorProyectoAciertos: number | null;
    ExamenAdministradorProyectoTotalReactivos: number | null;
    ExamenAdministradorProyectoRango: string;

    // Examen de soporte - BD
    ExamenPracticoSoporteBdFecha: Date | string | null;
    ExamenPracticoSoporteBdAciertos: number | null;
    ExamenPracticoSoporteBdTotalReactivos: number | null;
    ExamenPracticoSoporteBdRango: string;

    // Etapa de entrevistas
    EntrevistaCapitalHumanoFecha: Date | string | null;
    EntrevistaCapitalHumanoComentarios: string;
    EntrevistaCoordinadorYEquipoTecnicoFecha: Date | string | null;
    EntrevistaCoordinadorYEquipoTecnicoComentarios: string;
    EntrevistaInglesFecha: Date | string | null;
    EntrevistaInglesComentarios: string;
    EntrevistaGerenteAreaFecha: Date | string | null;
    EntrevistaGerenteAreaComentarios: string;
    VeredictoFinal: VeredictoFinalCandidato;
    VeredictoFinalNivelIdentificado: string;
    VeredictoFinalComentarios: string;

    // Propuesta económica
    PropuestaEconomicaFecha: Date | string | null;
    PropuestaEconomicaEstatus: PropuestaEconomicaEstatus;
    PropuestaEconomicaSueldo: number | null;
    PropuestaEconomicaComentarios: string;

    // Ingreso
    IngresoFecha: Date | string | null;
    IngresoTipoContrato: string;
    IngresoVencimientoContratoDeterminado: Date | string | null;
    IngresoObservaciones: string;
}