import * as React from "react";
import { LabeledInput } from "./input";
import { StringHelper } from "../../../helpers/string-helper";

/**
 * Propiedades para el componente de entrada de texto
 */
interface TextInputProps {
    label: string;
    value: string;
    /**
     * Si no se especifica, se usará el valor @param label
     */
    placeholder?: string | null | undefined;
    onChange?: (value: string) => void;
    required?: boolean;
    readonly?: boolean;
    maxlength?: number;
}

/**
 * Un componente para entrada de texto con validaciones
 */
export class LabeledTextInput extends React.Component<TextInputProps> {

    private handleChange = (value: string) => {
        const sanitizedValue = value;
        this.props.onChange(sanitizedValue);
    }

    private handleOnBlur = (value: string ) => {

        const valueFixed = value
            // Retiramos todos los espacios blancos que estén a la izquierda
            .trimLeft()
            .trimRight();

        // Si el valor reparado es diferente que el que se reporto al momento del Blur, notificamos el cambio
        if(value != valueFixed) {
            this.props.onChange(valueFixed);
        }
    }

    render() {
        const sanitizedValue = this.props.value || "";

        return (
            <LabeledInput
                placeholder={this.props.placeholder}
                label={this.props.label}
                value={sanitizedValue}
                onChange={this.handleChange}
                required={this.props.required}
                readonly={this.props.readonly}
                onBlur={this.handleOnBlur}
                maxLength={this.props.maxlength}
            ></LabeledInput>
        );
    }
}