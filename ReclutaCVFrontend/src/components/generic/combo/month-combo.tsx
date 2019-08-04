import { createEnumLabeledCombo } from "../../domain/base/enum-combo";
import { Month, MonthDescriptions } from "../../../communication/enums/months";


/**
 * Combo para elegir un mes en la aplicacion
 */
export const MonthCombo = createEnumLabeledCombo<Month>(
    "Mes",
    Month,
    (month: Month) => MonthDescriptions.get(month)
);