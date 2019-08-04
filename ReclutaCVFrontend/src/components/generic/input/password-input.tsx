import * as React from "react";
import { getInputEventAnyValue } from "../../../helpers/event-helper";
import { Input as BootstrapInput, FormFeedback } from "reactstrap";
import { Labeled } from "../label";

interface PasswordInputProps {
    /**
     * Se usara valor de placeholder para el login y el valor del label para creacion de 
     * usuarios nuevos dentro del sistema
     */
    label?: string | null;
    placeholder?: string | null;
    value: string;

    className?: string;
    /**
 * Función a ejecutar cuando el valor del input cambie
 */
    onChange?: (value: string) => void;
    onBlur?: (currentValue: string) => void;
    required?: boolean;
    readonly?: boolean;
}
interface PasswordInputState {
    userChangedValue: boolean;
    userLostFocus: boolean;
}

export class PasswordInput extends React.Component<PasswordInputProps, PasswordInputState> {
    constructor(props) {
        super(props);

        this.state = ({
            userChangedValue: false,
            userLostFocus: false,
        });
    }

    private readonly handleChange = (event: React.ChangeEvent<HTMLInputElement>) => {

        this.props.onChange != null && this.props.onChange(getInputEventAnyValue(event));

        this.setState({
            userChangedValue: true
        });
    }

    private readonly handleUsuarioLostFocus = () => {
        this.props.onBlur && this.props.onBlur(this.props.value);

        this.setState({ userLostFocus: true });
    }

    render() {
        const isInvalid = (
            this.props.required &&
            (
                this.state.userChangedValue ||
                this.state.userLostFocus
            ) &&
            (
                this.props.value === null ||
                this.props.value === undefined ||
                this.props.value === ""
            )
        );

        const fixedPlaceholder = this.props.placeholder || this.props.label;

        return (
            <Labeled label={this.props.label}>
                <BootstrapInput
                    className={this.props.className}
                    invalid={isInvalid && !this.props.readonly}
                    type="password"
                    value={this.props.value}
                    placeholder={fixedPlaceholder}
                    onChange={this.handleChange}
                    required={this.props.required && !this.props.readonly}
                    readOnly={this.props.readonly}
                    onBlur={this.handleUsuarioLostFocus}
                ></BootstrapInput>
                <FormFeedback>Dato requerido</FormFeedback>
            </Labeled>
        );
    }

}
