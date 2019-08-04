import * as React from "react";

import { LabeledCombo } from "../combo";

/**
 * Propiedades para la entrada de estatus
 */
interface StatusInputProps {
    value: boolean;
    onChange: (value: boolean) => void;
    readonly?: boolean;
    required?: boolean;
}

const trueAsString = "true";

/**
 * Componente para indicar el estatus de un elemento
 * @param props 
 */
export const LabeledStatusInput: React.FC<StatusInputProps> = props => (
    <LabeledCombo
        label="Estatus"
        items={[trueAsString, "false"]}
        valueSelected={props.value != null ? String(props.value) : null}
        descriptionSelector={value => value === trueAsString ? "Activo" : "Inactivo"}
        valueSelector={value => value}
        onItemChange={value => props.onChange(value != null ? value == trueAsString : null)}
        required={props.required}
        readonly={props.readonly}
    >
    </LabeledCombo>
);