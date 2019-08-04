import * as React from "react";
import { Input as BootstrapInput } from "reactstrap";
import { Labeled } from "../label";

interface LabeledBooleanInputProps {
    label: string;
    /**
     * Si no se especifica, se usará el valor @param label 
     */
    placeholder?: string | null | undefined;
    readonly?: boolean;
    value: boolean;
    onChange: (value: boolean) => void;
}

/**
 * Una entrada número con etiqueta
 */
export class LabeledBooleanInput extends React.Component<LabeledBooleanInputProps> {

    private readonly handleChange = (event: React.ChangeEvent<HTMLInputElement>) => {
        const isChecked = event.currentTarget.checked;

        this.props.onChange != null && this.props.onChange(isChecked);
    }
    
    render() {
        const fixedPlaceholder = this.props.placeholder || this.props.label;

        return (
            <Labeled label={this.props.label}>
                <BootstrapInput 
                    type="checkbox"
                    checked={this.props.value}
                    placeholder={fixedPlaceholder}
                    onChange={this.handleChange}
                    readOnly={this.props.readonly}
                    disabled={this.props.readonly}
                ></BootstrapInput>
            </Labeled>
        );
    }
}