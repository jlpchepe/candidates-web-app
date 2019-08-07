export enum MotivoSolicitud {
    PuestoNuevo,
    Incapacidad,
    Reemplazo,
    Proyecto,
    Practicante,
    Otro
}

export const MotivoSolicitudDescriptions = new Map([
    [MotivoSolicitud.PuestoNuevo, "Puesto nuevo"],
    [MotivoSolicitud.Incapacidad, "Incapacidad"],
    [MotivoSolicitud.Reemplazo, "Reemplazo"],
    [MotivoSolicitud.Proyecto, "Proyecto"],
    [MotivoSolicitud.Practicante, "Practicante"],
    [MotivoSolicitud.Otro, "Otro"]
]);

export enum AreaDelSolicitante {
    Comercial,
    AdministracionYFinanzasCapitalHumano,
    AdministracionYFinanzasasContableYFiscal,
    ProduccionOperacion,
    ProduccionMesaDeServicios,
    TecnologiasYProcesos,
    DirecciónGeneral,
    Otro
}

export const AreaDelSolicitanteDescriptions = new Map([
    [AreaDelSolicitante.Comercial, "Comercialización"],
    [AreaDelSolicitante.AdministracionYFinanzasCapitalHumano, "Administración y finanzas - Capital Humano"],
    [AreaDelSolicitante.AdministracionYFinanzasasContableYFiscal, "Administración y finanzas - Contable y Fiscal"],
    [AreaDelSolicitante.ProduccionOperacion, "Producción - Operación"],
    [AreaDelSolicitante.ProduccionMesaDeServicios, "Producción - Mesa de Servicios"],
    [AreaDelSolicitante.TecnologiasYProcesos, "Tecnologías y procesos"],
    [AreaDelSolicitante.DirecciónGeneral, "Dirección General"],
    [AreaDelSolicitante.Otro, "Otro"]
]);

export enum TipoDeContrato {
    ProyectoEspecifico,
    PeriodoEspecifico,
    TiempoIndefinido,
    Otro
}

export const TipoDeContratoDescriptions = new Map([
    [TipoDeContrato.ProyectoEspecifico, "Proyecto específico"],
    [TipoDeContrato.PeriodoEspecifico, "Periodo específico"],
    [TipoDeContrato.TiempoIndefinido, "Tiempo indefinido"],
    [TipoDeContrato.Otro, "Otro"]
]);

export enum EstatusSolicitud {
    Autorizada,
    NoAutorizada,
    Cancelada,
    Detenida
}

export const EstatusSolicitudDescriptions = new Map([
    [EstatusSolicitud.Autorizada, "Autorizada"],
    [EstatusSolicitud.NoAutorizada, "No autorizada"],
    [EstatusSolicitud.Cancelada, "Cancelada"],
    [EstatusSolicitud.Detenida, "Detenida"]
]);