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