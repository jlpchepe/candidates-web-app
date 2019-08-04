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