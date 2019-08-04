import * as React from "react";
import { getInputEventAnyValue } from "../../../helpers/event-helper";
import { Labeled } from "../label/labeled";
import { Input as BootstrapInput, FormFeedback } from "reactstrap";
import { NullHelper } from "../../../helpers/null-helper";

interface LabeledInputProps {
    label: string;
    value: string;
    /**
     * Si no se especifica, se usará el valor @param label 
     */
    placeholder?: string | null;
    /**
     * Función a ejecutar cuando el valor del input cambie
     */
    onChange?: (value: string) => void;
    onBlur?: (currentValue: string) => void;
    required: boolean;
    readonly?: boolean;
    maxLength?: number;
}

interface LabeledInputState {
    userChangedValue: boolean;
    userLostFocus: boolean;
}

/**
 * Envoltura alrededor de la clase input nativa
 */
export class LabeledInput extends React.Component<LabeledInputProps, LabeledInputState> {
    constructor(props: LabeledInputProps){
        super(props);
        
        this.state = {
            userChangedValue: false,
            userLostFocus: false
        };
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
        const fixedPlaceholder = this.props.placeholder || this.props.label;
        const fixedValue = NullHelper.valueOrDefault(this.props.value, "");

        const isInvalid = (
            this.props.required &&
            !this.props.readonly &&
            fixedValue == "" &&
            (
                this.state.userChangedValue ||
                this.state.userLostFocus
            )
        );

        const markAsRequired = this.props.required && !this.props.readonly;

        return (
            <Labeled label={this.props.label}>
                <BootstrapInput 
                    type="text" 
                    invalid={isInvalid}
                    value={fixedValue}
                    placeholder={fixedPlaceholder}
                    onChange={this.handleChange}
                    required={markAsRequired}
                    readOnly={this.props.readonly}
                    disabled={this.props.readonly}
                    onBlur={this.handleUsuarioLostFocus}
                    maxLength={this.props.maxLength}
                ></BootstrapInput>
                <FormFeedback>Dato requerido</FormFeedback>
            </Labeled>
        );
    }
}