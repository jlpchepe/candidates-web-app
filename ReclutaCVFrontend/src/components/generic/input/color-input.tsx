import * as React from "react";
import { Input as BootstrapInput, FormFeedback } from "reactstrap";
import { Labeled } from "../label";
import { ColorHelper } from "../../../helpers/color-helper";

interface LabeledColorInputProps {
    label: string;
    value: string;
    onChange: (value: string) => void;
    readonly?: boolean;
    required?: boolean;
}

const defaultColorValue = "#000000";

/**
 * Una entrada de color con etiqueta
 */
export class LabeledColorInput extends React.Component<LabeledColorInputProps> {

    componentDidMount() {
        if(!ColorHelper.isValidHexColor(this.props.value)) {
            this.props.onChange(defaultColorValue);
        }
    }

    handleValueChange = (e: React.ChangeEvent<HTMLInputElement>) => {
        this.props.onChange(e.target.value);
    }

    render() {
        const fixedValue = ColorHelper.isValidHexColor(this.props.value) ? 
            this.props.value :
            defaultColorValue;

        return (
            <Labeled label={this.props.label}>
                <BootstrapInput
                    type="color"
                    onChange={this.handleValueChange}
                    readOnly={this.props.readonly}
                    disabled={this.props.readonly}
                    value={fixedValue}
                    required={this.props.required}
                ></BootstrapInput>
                <FormFeedback>Dato requerido</FormFeedback>
            </Labeled>
        );
    }
};