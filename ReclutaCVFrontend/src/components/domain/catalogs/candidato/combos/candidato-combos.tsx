

import { createEnumLabeledCombo } from "../../../base/enum-combo";
import { VeredictoFinalCandidato, VeredictoFinalCandidatoDescriptions } from "../../../../../communication/enums/veredicto-final-candidato";

/**
 * Un combo para seleccionar elementos en la aplicación
 */
export const VeredictoFinalCandidatoCombo = createEnumLabeledCombo(
    "Rol",
    VeredictoFinalCandidato,
    (value: VeredictoFinalCandidato) => VeredictoFinalCandidatoDescriptions.get(value)
);