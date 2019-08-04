import * as React from "react";
import DatePicker, { registerLocale } from "react-datepicker";
import { Labeled } from "../label";
import es from "date-fns/locale/es";
import { FormFeedback } from "reactstrap";
import classnames from "classnames";
import { DateHelper } from "../../../helpers/date-helper";

// Se importa la configuración en español para el calendario
registerLocale("es", es);

interface LabeledDateInputProps {
    label: string;
    placeholder?: string;
    value: Date | null;
    onChange: (value: Date | null) => void;
    required?: boolean;
    readonly?: boolean;
    minDate?: Date;
    maxDate?: Date;
    /**
     * Hace que las fechas seleccionadas se seleccionen respetando el UTC-0
     * Si la fecha seleccionada es 2019-01-02T00:00:00 UTC-7:
     * - en true se devolverá 2019-01-01T17:00:00 UTC-7
     * - en false regresará el primer valor tal cual 2019-01-02T00:00:00 UTC-7
     */
    useUtcZero?: boolean;
    /**
     * Indica si debe permirse capturar la hora además de la fecha
     */
    captureTime?: boolean;
}

interface LabeledDateInputState {
    userChangedValue: boolean;
    userLostFocus: boolean;
}

/**
 * Una entrada de fecha
 */
export class LabeledDateInput extends React.Component<LabeledDateInputProps, LabeledDateInputState> {
    state = {
        userChangedValue: false,
        userLostFocus: false
    };

    private readonly handleChange = (value: Date | null) => {
        if(this.props.onChange != null){
            const prefixedValue = !this.props.captureTime ?
                DateHelper.cloneDateTruncateTime(value) :
                value;

            const fixedValue = this.props.useUtcZero ? 
                DateHelper.removeUtcOffset(prefixedValue) :
                prefixedValue;
    
            this.props.onChange(fixedValue);
        }

        this.setState({
            userChangedValue: true
        });
    };

    private readonly handleUsuarioLostFocus = () => 
        this.setState({ userLostFocus: true });

    private fixedDateBeforeRenderBasedOnUtc(date: Date | null){
        // Convertimos la fecha, para que se muestre como si nuestra zona horaria fuera UTC-0
        return this.props.useUtcZero ? DateHelper.addUtcOffset(date) : date;
    }

    render() {
        const fixedPlaceholder = this.props.placeholder || "";

        const fixedDates = {
            value: this.fixedDateBeforeRenderBasedOnUtc(this.props.value),
            maxDate: this.fixedDateBeforeRenderBasedOnUtc(this.props.maxDate),
            minDate: this.fixedDateBeforeRenderBasedOnUtc(this.props.minDate),
        };

        const isInvalid = (
            this.props.required &&
            !this.props.readonly &&
            this.props.value == null &&
            (
                this.state.userChangedValue ||
                this.state.userLostFocus
            )
        );

        const markAsRequired = this.props.required && !this.props.readonly;

        const dateFormat = "dd/MM/yyyy" + (this.props.captureTime ? " HH:mm" : "");

        return (
            <Labeled label={this.props.label}>
                <DatePicker
                    locale="es"
                    placeholderText={fixedPlaceholder}
                    dateFormat={dateFormat}
                    selected={fixedDates.value}
                    peekNextMonth
                    onChange={this.handleChange}
                    dropdownMode="select"
                    className={classnames(
                        "form-control", 
                        { "is-invalid": isInvalid }
                    )}
                    required={markAsRequired}
                    disabled={this.props.readonly}
                    minDate={fixedDates.minDate}
                    maxDate={fixedDates.maxDate}
                    onBlur={this.handleUsuarioLostFocus}
                    showTimeSelect={this.props.captureTime}
                />
                <FormFeedback 
                    style={{ display: isInvalid ? "block" : undefined }}
                >Dato requerido</FormFeedback>
            </Labeled>
        );
    }
}