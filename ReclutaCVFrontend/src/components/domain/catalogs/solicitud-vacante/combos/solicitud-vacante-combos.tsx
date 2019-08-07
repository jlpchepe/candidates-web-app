

import { createEnumLabeledCombo } from "../../../base/enum-combo";
import { 
    MotivoSolicitud, 
    MotivoSolicitudDescriptions, 
    AreaDelSolicitante,
    AreaDelSolicitanteDescriptions,
    EstatusSolicitudDescriptions,
    EstatusSolicitud,
    TipoDeContrato,
    TipoDeContratoDescriptions
} from "../../../../../communication/enums/solicitud-vacante-enums";

/**
 * Un combo para seleccionar elementos en la aplicación
 */
export const MotivoSolicitudCombo = createEnumLabeledCombo(
    MotivoSolicitud,
    (value: MotivoSolicitud) => MotivoSolicitudDescriptions.get(value)
);

export const AreaDelSolicitanteCombo = createEnumLabeledCombo(
    AreaDelSolicitante,
    (value: AreaDelSolicitante) => AreaDelSolicitanteDescriptions.get(value)
);

export const TipoDeContratoCombo = createEnumLabeledCombo(
    TipoDeContrato,
    (value: TipoDeContrato) => TipoDeContratoDescriptions.get(value)
);

export const EstatusSolicitudCombo = createEnumLabeledCombo(
    EstatusSolicitud,
    (value: EstatusSolicitud) => EstatusSolicitudDescriptions.get(value)
);