import * as React from "react";

import * as services from "../../../../../communication/services";
import { LabeledCombo } from "../../../../generic";
import { AbsentSelectable } from "../../../../../communication/dtos/absent";
import { withItemsComboLoading } from "../../../../hoc/with-items-combo-loader";
import { WithItemsLoaderProps } from "../../../../hoc/with-items-loader";

const absentService = services.Absent;

/**
 * Propiedades del combo
 */
interface AbsentComboProps extends WithItemsLoaderProps<AbsentSelectable> {
    label: string;
    idSelected: number | null;
    onIdSelectedChange: (id: number) => void;
    readonly?: boolean;
}

/**
 * Un combo para seleccionar elementos en la aplicación
 */
class AbsentComboSimple extends React.Component<
AbsentComboProps
> {
    private valueSelector = (model: AbsentSelectable) => model.id;
    private descriptionSelector = (model: AbsentSelectable) =>
        model.reason;

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
            />
        );
    }
}

export const AbsentCombo = withItemsComboLoading(AbsentComboSimple, absentService.getAll);
