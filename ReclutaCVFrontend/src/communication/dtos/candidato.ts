export interface CandidatoListable extends CandidatoConsultable {
    
}

export interface CandidatoInsertable extends CandidatoConsultable{
}

export interface CandidatoUpdatable extends CandidatoConsultable{
}

export interface CandidatoConsultable
{
    id: number | null;
    //Datos generales
    nombre: string;
    correo: string;
    telefono: string;
    fechaDeNacimiento: Date | string | null;
    estadoCivil: string;
    lugarNacimiento: string;
    generalesComentarios: string;
    fechaDeActualizacion: Date | string | null;

    // Experiencia laboral
    compañia: string;
    añosDeExperiencia: number | null;
    sueldoActual: number | null;
    motivoDeSeparacion: string;

    // Educación
    carrera: string;
    institucion: string;
    estatusAcademico: EstatusAcademico;
    cursos: string;
    certificaciones: string;
    competenciasOHabilidades: string;
    tecnologiasQueDomina: string;
    softwareQueDomina: string;

    // Inglés
    nivelDeIngles: string;
    nivelDeInglesHablado: number | null;
    nivelDeInglesEscrito: number | null;
    nivelDeInglesLectura: number | null;

    // Proceso de reclutamiento
    solicitudPersonalFolio: number | null;
    puestoClave: number | null;
    puestoNombre: string;
    proyectoNombre: string;
    fechaDeRecepcionCurriculum: Date | string | null;
    fechaDeContacto: Date | string | null;
    fechaPreentrevistaTelefonica: Date | string | null;
    fechaRecepcionSolicitudRegistro: Date | string | null;
    quienLoContacto: string;
    bolsa: BolsaTrabajo;
    bolsaOtra: string;
    rol: RolCandidato;
    rolOtro: string;
    expectativaEconomica: number | null;
    estatus: EstatusCandidato;
    reclutamientoComentarios: string;

    // examen psicometrico
    examenPsicometricoNombre: string;
    examenPsicometricoResultados: string;
    examenPsicometricoObservaciones: string;

    // examen de programación
    examenProgramacionFecha: Date | string | null;
    examenProgramacionIpComputadora: string;
    examenProgramacionId: string;
    examenProgramacionUmlCalificacion: number | null;
    examenProgramacionUmlTotalReactivos: number | null;
    examenProgramacionAdooCalificacion: number | null;
    examenProgramacionAdooTotalReactivos: number | null;
    examenProgramacionPooCalificacion: number | null;
    examenProgramacionPooTotalReactivos: number | null;
    examenProgramacionLogicaCalificacion: number | null;
    examenProgramacionLogicaTotalReactivos: number | null;
    examenProgramacionWebCalificacion: number | null;
    examenProgramacionWebTotalReactivos: number | null;
    examenProgramacionJavascriptCalificacion: number | null;
    examenProgramacionJavascriptTotalReactivos: number | null;
    examenProgramacionScrumCalificacion: number | null;
    examenProgramacionScrumTotalReactivos: number | null;
    examenProgramacionTecnologiaCalificacion: number | null;
    examenProgramacionTecnologiaTotalReactivos: number | null;
    examenProgramacionAciertos: number | null;
    examenProgramacionTotalReactivos: number | null;
    examenProgramacionRango: string;

    // examen de analista
    examenAnalistaFecha: Date | string | null;
    examenAnalistaIpComputadora: string;
    // Teórico
    examenAnalistaTeoricoId: string;
    examenAnalistaTeoricoAciertos: number | null;
    examenAnalistaTeoricoTotalReactivos: number | null;
    examenAnalistaTeoricoRango: string;
    // Práctico
    examenAnalistaPracticoId: string;
    examenAnalistaPracticoNumeroCaso: number | null;
    examenAnalistaPracticoAciertos: number | null;
    examenAnalistaPracticoTotalReactivos: number | null;
    examenAnalistaPracticoRango: string;

    // examen de ingeniero de pruebas
    examenIngenieroPruebasFecha: Date | string | null;
    examenIngenieroPruebasIpComputadora: string;
    // Teórico
    examenIngenieroPruebasTeoricoId: number | null;
    examenIngenieroPruebasTeoricoAciertos: number | null;
    examenIngenieroPruebasTeoricoTotalReactivos: number | null;
    examenIngenieroPruebasTeoricoRango: string;
    // Práctico
    examenIngenieroPruebasPracticoId: number | null;
    examenIngenieroPruebasPracticoCalificacion: number | null;
    examenIngenieroPruebasPracticoPuntos: number | null;
    examenIngenieroPruebasPracticoRango: string;
    // SQL
    examenIngenieroPruebasSqlTotalReactivos: number | null;
    examenIngenieroPruebasSqlCalificacion: number | null;

    // examen de administrador de proyectos
    examenAdministradorProyectoFecha: Date | string | null;
    examenAdministradorProyectoIpComputadora: string;
    examenAdministradorProyectoId: number | null;
    examenAdministradorProyectoAciertos: number | null;
    examenAdministradorProyectoTotalReactivos: number | null;
    examenAdministradorProyectoRango: string;

    // examen de soporte - BD
    examenPracticoSoporteBdFecha: Date | string | null;
    examenPracticoSoporteBdAciertos: number | null;
    examenPracticoSoporteBdTotalReactivos: number | null;
    examenPracticoSoporteBdRango: string;

    // Etapa de entrevistas
    entrevistaCapitalHumanoFecha: Date | string | null;
    entrevistaCapitalHumanoComentarios: string;
    entrevistaCoordinadorYEquipoTecnicoFecha: Date | string | null;
    entrevistaCoordinadorYEquipoTecnicoComentarios: string;
    entrevistaInglesFecha: Date | string | null;
    entrevistaInglesComentarios: string;
    entrevistaGerenteAreaFecha: Date | string | null;
    entrevistaGerenteAreaComentarios: string;
    veredictoFinal: VeredictoFinalCandidato;
    veredictoFinalNivelIdentificado: string;
    veredictoFinalComentarios: string;

    // Propuesta económica
    propuestaEconomicaFecha: Date | string | null;
    propuestaEconomicaEstatus: PropuestaEconomicaEstatus;
    propuestaEconomicaSueldo: number | null;
    propuestaEconomicaComentarios: string;

    // Ingreso
    ingresoFecha: Date | string | null;
    ingresoTipoContrato: string;
    ingresoVencimientoContratoDeterminado: Date | string | null;
    ingresoObservaciones: string;
}