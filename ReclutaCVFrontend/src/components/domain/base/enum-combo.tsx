import * as React from "react";
import { EnumHelper } from "../../../helpers/enum-helper";
import { LabeledCombo } from "../../generic";


/**
 * Propiedades del combo
 */
export interface EnumComboProps<TEnum> {
    value: TEnum;
    onValueChange: (item: TEnum) => void;
    readonly?: boolean;
    required?: boolean;
}

interface EnumSelectable<TEnum> {
    value: TEnum;
    description: string;
}

/**
 * Un combo para seleccionar elementos de enum
 */
export function createEnumLabeledCombo<TEnum extends number>(
    label: string,
    enumType: any,
    valueToDescription: (value: TEnum) => string
) : React.FC<EnumComboProps<TEnum>> {
    const items: EnumSelectable<TEnum>[] = EnumHelper.getValues<TEnum>(enumType)
        .map(value => ({
            value: value,
            description: valueToDescription(value)
        }));
    return (props: EnumComboProps<TEnum>) => (
        <LabeledCombo
            items={items}
            label={label}
            onValueAsNumberChange={props.onValueChange}
            valueSelected={props.value}
            valueSelector={x => x.value}
            descriptionSelector={x => x.description}
            required={props.required}
            readonly={props.readonly}
        >
        </LabeledCombo>
    );
};
