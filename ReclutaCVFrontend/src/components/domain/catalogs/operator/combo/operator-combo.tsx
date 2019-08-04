import * as React from "react";

import * as services from "../../../../../communication/services";
import { LabeledCombo } from "../../../../generic";
import { OperatorSelectable } from "../../../../../communication/dtos/operator";
import { withItemsComboLoading, WithItemsComboLoaderProps } from "../../../../hoc/with-items-combo-loader";

const operatorService = services.Operator;

/**
 * Propiedades del combo
 */
interface OperatorComboProps extends WithItemsComboLoaderProps<OperatorSelectable> {
    label?: string;
    idSelected: number | null;
    onIdSelectedChange: (id: number) => void;
    readonly?: boolean;
    required?: boolean;
}

/**
 * Un combo para seleccionar elementos en la aplicación
 */
class OperatorComboSimple extends React.Component<OperatorComboProps> {
    private valueSelector = (item: OperatorSelectable) => item.id;
    private descriptionSelector = (item: OperatorSelectable) => item.name;

    render() {
        return (
            <LabeledCombo
                label={this.props.label}
                items={this.props.items}
                readonly={this.props.readonly}
                valueSelector={this.valueSelector}
                descriptionSelector={this.descriptionSelector}
                onValueAsNumberChange={this.props.onIdSelectedChange}
                valueSelected={this.props.idSelected}
                required={this.props.required}
            />
        );
    }
}

export const OperatorCombo = withItemsComboLoading(OperatorComboSimple, operatorService.getAll);
