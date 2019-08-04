

import { UsuarioRole, UsuarioRoleDescriptions } from "../../../../../communication/enums/user-roles";
import { createEnumLabeledCombo } from "../../../base/enum-combo";



/**
 * Un combo para seleccionar elementos en la aplicación
 */
export const RoleCombo = createEnumLabeledCombo(
    "Rol",
    UsuarioRole,
    (value: UsuarioRole) => UsuarioRoleDescriptions.get(value)
);