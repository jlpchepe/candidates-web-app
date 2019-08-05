export enum VeredictoFinalCandidato{
    EnEspera,
    Aceptado,
    Rechazado
}

export const VeredictoFinalCandidatoDescriptions = new Map<VeredictoFinalCandidato, string>([
    [VeredictoFinalCandidato.EnEspera, "En espera"],
    [VeredictoFinalCandidato.Aceptado, "Aceptado"],
    [VeredictoFinalCandidato.Rechazado, "Rechazado"]
]);

export enum PropuestaEconomicaEstatus{
    Aceptada,
    Rechazada
}

export const PropuestaEconomicaEstatusDescriptions = new Map([
    [PropuestaEconomicaEstatus.Aceptada, "Aceptada"],
    [PropuestaEconomicaEstatus.Rechazada, "Rechazada"]
]);

export enum EstatusAcademico{
    Egresado,
    Titulado,
    Pasante,
    Estudiante,
    Trunca,
    Técnico
}

export const EstatusAcademicoDescriptions = {
    get: (estatusAcademico: EstatusAcademico) => estatusAcademico != null ? EstatusAcademico[estatusAcademico] : null
}

export enum BolsaTrabajo{
    ReferenciaInterna,
    ReferenciaExterna,
    OccMundial,
    Facebook,
    BolsaUniversitaria,
    Linkedin,
    Twitter,
    Google,
    EmpleosTi,
    CompuTrabajo,
    Jobs,
    OtraBolsa
}

export const BolsaTrabajoDescriptions = new Map([
    [BolsaTrabajo.ReferenciaInterna, "Referencia interna"],
    [BolsaTrabajo.ReferenciaExterna, "Referencia externa"],
    [BolsaTrabajo.OccMundial, "OCCMundial"],
    [BolsaTrabajo.Facebook, "Facebook"],
    [BolsaTrabajo.BolsaUniversitaria, "Bolsa universitaria"],
    [BolsaTrabajo.Linkedin, "LinkedIn"],
    [BolsaTrabajo.Twitter, "Twitter"],
    [BolsaTrabajo.Google, "Google"],
    [BolsaTrabajo.EmpleosTi, "Empleos TI"],
    [BolsaTrabajo.CompuTrabajo, "CompuTrabajo"],
    [BolsaTrabajo.Jobs, "Jobs"],
    [BolsaTrabajo.OtraBolsa, "Otra bolsa"]
]);

export enum RolCandidato{
    IngenieroDeSoftware,
    IngenieroDeSoftwareEnSoporteYMantenimiento,
    Analista,
    AdministradorDeProyecto,
    EspecialistaDeNegocio,
    IngenieroDePruebas,
    DataEngineer,
    ArquitectoSoftware,
    Otro
}

export const RolCandidatoDescriptions = new Map([
    [RolCandidato.IngenieroDeSoftware, "Ingeniero de software"],
    [RolCandidato.IngenieroDeSoftwareEnSoporteYMantenimiento, "Ingeniero de software en soporte y mantenimiento"],
    [RolCandidato.Analista, "Analista"],
    [RolCandidato.AdministradorDeProyecto, "Administrador de proyecto"],
    [RolCandidato.EspecialistaDeNegocio, "Especialista de negocio"],
    [RolCandidato.IngenieroDePruebas, "Ingeniero de pruebas"],
    [RolCandidato.DataEngineer, "Data engineer"],
    [RolCandidato.ArquitectoSoftware, "Arquitecto de software"],
    [RolCandidato.Otro, "Otro"]
]);

export enum EstatusCandidato{
    CitadoParaExamen,
    CitadoParaEntrevista,
    InteresesAltos,
    Foraneo,
    OtraVacante,
    AnalizandoAlCandidato,
    NoLeIntereso,
    VacanteDetenida,
    Seleccionado,
    PreSeleccionado,
    NoCumpleConElPerfilTecnico,
    NoCumpleConElPerfilHabilidades,
    NoCumpleConElPerfil,
    PorContactar,
    Rechazado,
    RechazoOferta   
}

export const EstatusCandidatoDescriptions = new Map([
    [EstatusCandidato.CitadoParaExamen, "Citado para examen"],
    [EstatusCandidato.CitadoParaEntrevista, "Citado para entrevista"],
    [EstatusCandidato.InteresesAltos, "Intereses altos"],
    [EstatusCandidato.Foraneo, "Foráneo"],
    [EstatusCandidato.OtraVacante, "Otra vacante"],
    [EstatusCandidato.AnalizandoAlCandidato, "Analizando al candidato"],
    [EstatusCandidato.NoLeIntereso, "No le interesó"],
    [EstatusCandidato.VacanteDetenida, "Vacante detenida"],
    [EstatusCandidato.Seleccionado, "Candidato seleccionado"],
    [EstatusCandidato.PreSeleccionado, "Candidato pre seleccionado"],
    [EstatusCandidato.NoCumpleConElPerfilTecnico, "No cumple con el perfil (técnico)"],
    [EstatusCandidato.NoCumpleConElPerfilHabilidades, "No cumple con el perfil (habilidades)"],
    [EstatusCandidato.NoCumpleConElPerfil, "No cumple con el perfil"],
    [EstatusCandidato.PorContactar, "Por contactar"],
    [EstatusCandidato.Rechazado, "Rechazado"],
    [EstatusCandidato.RechazoOferta, "Rechazó la oferta"],
]);