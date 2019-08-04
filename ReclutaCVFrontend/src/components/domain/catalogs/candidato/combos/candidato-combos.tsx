

import { createEnumLabeledCombo } from "../../../base/enum-combo";
import { VeredictoFinalCandidato, VeredictoFinalCandidatoDescriptions, PropuestaEconomicaEstatusDescriptions, PropuestaEconomicaEstatus, EstatusAcademico, BolsaTrabajo, BolsaTrabajoDescriptions, RolCandidatoDescriptions, RolCandidato, EstatusCandidatoDescriptions, EstatusCandidato } from "../../../../../communication/enums/candidato";

/**
 * Un combo para seleccionar elementos en la aplicación
 */
export const VeredictoFinalCandidatoCombo = createEnumLabeledCombo(
    VeredictoFinalCandidato,
    (value: VeredictoFinalCandidato) => VeredictoFinalCandidatoDescriptions.get(value)
);

export const PropuestaEconomicaEstatusCombo = createEnumLabeledCombo(
    PropuestaEconomicaEstatus,
    (value: PropuestaEconomicaEstatus) => PropuestaEconomicaEstatusDescriptions.get(value)
);

export const EstatusAcademicoCombo = createEnumLabeledCombo(
    EstatusAcademico,
    (value: EstatusAcademico) => value != null ? value.toString() : ""
);
export const BolsaTrabajoCombo = createEnumLabeledCombo(
    BolsaTrabajo,
    (value: BolsaTrabajo) => BolsaTrabajoDescriptions.get(value)
);
export const RolCandidatoCombo = createEnumLabeledCombo(
    RolCandidato,
    (value: RolCandidato) => RolCandidatoDescriptions.get(value)
);
export const EstatusCandidatoCombo = createEnumLabeledCombo(
    EstatusCandidato,
    (value: EstatusCandidato) => EstatusCandidatoDescriptions.get(value)
);

