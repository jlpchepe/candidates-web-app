import * as React from "react";
import { LabeledInput } from "./input";
import { NumberHelper } from "../../../helpers/number-helper";

interface LabeledNumberInputProps {
    label: string;
    value: number;
    onChange: (value: number) => void;
    /**
     * Si no se especifica, se usará el valor @param label 
     */
    placeholder?: string | null | undefined;
    required?: boolean;
    readonly?: boolean;
    /**
     * Indica que el valor solo puede ser un entero
     */
    integer?: boolean;
}

interface LabeledNumberInputState {
    /**
     * Almacena el último valor sanitizado que se obtuvo de la entrada de usuario
     */
    sanitizedValue?: string;
}

/**
 * Una entrada número con etiqueta
 */
export class LabeledNumberInput extends React.Component<LabeledNumberInputProps, LabeledNumberInputState> {
    state = {
        sanitizedValue: this.props.value != null ? this.props.value.toString() : ""
    };

    componentDidUpdate(prevProps: LabeledNumberInputProps) {
        if (this.props.value !== prevProps.value) {
            const sanitizedValue = this.props.value != null ? this.props.value.toString() : "";
            this.setState({sanitizedValue});
        }
    }

    private handleValueChange = (sanitizedValue: string) => {
        this.setState({ sanitizedValue });

        const valueAsNumber = NumberHelper.tryConvertToNumber(sanitizedValue);

        this.props.onChange(valueAsNumber);
    }

    private handleChange = (value: string) => {
        const sanitizedValue = NumberHelper.sanitizeNumericString(value);

        this.handleValueChange(sanitizedValue);
    }

    private handleOnBlur = (currentValueAsString: string) => {
        // Si en el blur del input el último caracter es un punto, lo removemos
        const currentValueAsStringFixed = currentValueAsString
            // Retiramos todos los puntos, en caso de que se trate de enteros
            .replace(this.props.integer ? /\.+.*$/ : "", "")
            // Retiramos todos los ceros que estén a la izquierda
            .replace(/^0+(?!\.)(?!$)/g, "")
            // Retiramos los puntos que estén a la derecha
            .replace(/\.+$/g, "");

        // Si el valor reparado es diferente que el que se reporto al momento del Blur, notificamos el cambio
        if (currentValueAsString != currentValueAsStringFixed) {
            this.handleValueChange(currentValueAsStringFixed);
        }
    }

    render() {
        const maxLength = this.props.integer ?
            NumberHelper.integerMaxCharacters :
            NumberHelper.numberMaxCharacters;

        return (
            <LabeledInput
                label={this.props.label}
                value={this.state.sanitizedValue}
                placeholder={this.props.placeholder}
                onChange={this.handleChange}
                required={this.props.required}
                onBlur={this.handleOnBlur}
                readonly={this.props.readonly}
                maxLength={maxLength}
            ></LabeledInput>
        );
    }
}