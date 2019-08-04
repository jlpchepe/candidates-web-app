import * as React from "react";
import { Input, FormFeedback } from "reactstrap";
import { getInputEventStringValue } from "../../../helpers/event-helper";
import { NullHelper } from "../../../helpers/null-helper";
import { Labeled } from "../label";
import { StringHelper } from "../../../helpers/string-helper";

interface LabeledTextAreaInputProps {
    label: string;
    value: string;
    placeholder?: string | null;
    /**
     * Función a ejecutar cuando el valor del input cambie
     */
    onChange: (value: string) => void;
    required?: boolean;
    readonly?: boolean;
}

interface LabeledTextAreaInputState {
    userChangedValue: boolean;
    userLostFocus: boolean;
}

/**
 * Una entrada de texto en un área
 */
export class LabeledTextAreaInput extends React.Component<LabeledTextAreaInputProps, LabeledTextAreaInputState> {
    constructor(props: LabeledTextAreaInputProps) {
        super(props);

        this.state = {
            userChangedValue: false,
            userLostFocus: false
        };
    }

    private readonly handleChange = (event: React.ChangeEvent<HTMLInputElement>) => {
        const value = getInputEventStringValue(event);
        const sanitizedValue = StringHelper.sanitizeTextInput(value);

        this.props.onChange(sanitizedValue);

        this.setState({ userChangedValue: true });
    };

    private readonly handleUserLostFocus = () => {
        const valueFixed = this.props.value && StringHelper.sanitizeTextInput(this.props.value)
            // Retiramos todos los espacios blancos que estén a la izquierda
            .trimLeft()
            .trimRight();

        // Si el valor reparado es diferente que el que se reporto al momento del Blur, notificamos el cambio
        if (this.props.value != valueFixed) {
            this.props.onChange(valueFixed);
        }
        this.setState({ userLostFocus: true });
    };

    render() {
        const fixedValue = NullHelper.valueOrDefault(this.props.value, "");
        const fixedPlaceholder = this.props.placeholder || this.props.label;

        const isInvalid =
            this.props.required &&
            !this.props.readonly &&
            fixedValue == "" &&
            (
                this.state.userChangedValue ||
                this.state.userLostFocus
            );

        const markAsRequired = this.props.required && !this.props.readonly;

        return (
            <Labeled label={this.props.label}>
                <Input
                    placeholder={fixedPlaceholder}
                    type="textarea"
                    invalid={isInvalid}
                    value={fixedValue}
                    onChange={this.handleChange}
                    onBlur={this.handleUserLostFocus}
                    required={markAsRequired}
                    disabled={this.props.readonly}
                />
                <FormFeedback
                    style={{ display: isInvalid && "block" }}>Dato requerido</FormFeedback>
            </Labeled>
        );
    }
}
