

import { createEnumLabeledCombo } from "../../../base/enum-combo";
import { VeredictoFinalCandidato, VeredictoFinalCandidatoDescriptions, PropuestaEconomicaEstatusDescriptions, PropuestaEconomicaEstatus } from "../../../../../communication/enums/candidato";

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
