import * as React from "react";
import { ArrayHelper } from "../../../helpers/array-helper";
import { NumberHelper } from "../../../helpers/number-helper";
import { Labeled } from "../label/labeled";
import { Input as BootstrapInput, FormFeedback } from "reactstrap";
import { StringHelper } from "../../../helpers/string-helper";
import { NullHelper } from "../../../helpers/null-helper";
import classnames from "classnames";

/**
 * Propiedades del combo
 */
interface LabeledComboProps<TListable> {
    /**
     * Elementos con los que se llenará el combo
     */
    items: TListable[];
    /**
     * Etiqueta para mostrar en el combo
     */
    label?: string;
    /**
     * Valor del item que debe mostrarse como seleccionado en el combo
     */
    valueSelected?: string | number | null;
    /**
     * Indica si es requerido seleccionar un valor del combo
     */
    required?: boolean;
    /**
     * Indica si el combo se mostrará en modo de solo lectura
     */
    readonly?: boolean;
    /**
     * Selector de una columna que haga único a los elementos, el valor que es útil a nivel sistema
     * Ejemplo: Podría ser su Id: (item) => item.id
     */
    valueSelector: (item: TListable) => string | number;
    /**
     * Selector del valor amigable para mostrar al usuario
     */
    descriptionSelector: (item: TListable) => string;
    /**
     * Operación a realizar cuando se seleccione otro elemento
     */
    onItemChange?: (item: TListable) => void;
    onValueAsStringChange?: (value: string) => void;
    onValueAsNumberChange?: (value: number) => void;
    positionFixed?: boolean;
}

/**
 * Estado que tendrá el combo, cuando se encuentren desplegadas sus opciones de selección
 */
interface LabeledComboStateOpenedState {
    /**
     * Término que introdujo el usuario como busqueda
     */
    searchTerm: string;
}

interface LabeledComboState<TListable> {
    userChangedValue: boolean;
    userLostFocus: boolean;

    /**
     * Indica si se muestra el contenedor de las sugerencias
     */
    opened?: LabeledComboStateOpenedState;

    /**
     * Sugerencias a mostrar cuando se realice la busqueda 
     */
    suggestions: TListable[];
}

const defaultSelectOption = "--Seleccione--";

/**
 * Un combo con filtro de busqueda para seleccionar elementos en la aplicación
 */
export class LabeledCombo<TListable> extends React.Component<LabeledComboProps<TListable>, LabeledComboState<TListable>> {
    constructor(props: LabeledComboProps<TListable>) {
        super(props);

        this.state = {
            userChangedValue: false,
            userLostFocus: false,
            opened: undefined,
            // Se establecen los valores predeterminados antes del render
            suggestions: props.items
        };
    }

    createDefaultSelectOption = (value: number, label: string) => {
        return (<li
            tabIndex={-1}
            key={value}
            className={classnames(
                "list-group-item list-group-item-action",
                { active: this.props.valueSelected === value }
            )}
            onMouseDown={() => this.handleItemSelected(value)}
        >
            {label}
        </li>);
    }


    /**
     * Encuentra el elemento que tenga el valor seleccionado
     */
    private findSelectedItem = (selectedValue: string | number) => {
        return ArrayHelper.findFirstOrNull(
            this.props.items,
            item => this.props.valueSelector(item) == selectedValue
        );
    }

    private findSelectedItemDescription = (selectedValue: string | number) => {
        const selectedItem = this.findSelectedItem(selectedValue);

        return selectedItem != null ? this.props.descriptionSelector(selectedItem) : null;
    }

    /**
     * Maneja el cambio de la búsqueda introducida por el usuario
     */
    private handleSearchChange = (event: React.ChangeEvent<HTMLInputElement>) => {
        // Filtro por el cual se filtrarán los elementos del combo
        const searchTerm = event.target.value;

        let suggestedItems = this.props.items;
        // Se raaliza el filtrado por el texto ingresado
        suggestedItems = suggestedItems.filter(item =>
            StringHelper.containsCaseInsensitive(
                this.props.descriptionSelector(item),
                searchTerm
            )
        );

        // Se establecen las sugerencias encontradas
        this.setState({
            opened: { searchTerm },
            userChangedValue: true,
            suggestions: suggestedItems,
        });
    };

    private getOptionFromItem = (
        item: TListable,
        itemIndex: number
    ): JSX.Element => {
        const itemValue = this.props.valueSelector(item);
        const itemDescription = this.props.descriptionSelector(item);
        const handleSelectValue = () => this.handleItemSelected(itemValue);

        // Se renderizan las sugerencias de busqueda
        return (
            <li
                tabIndex={-1}
                key={itemIndex}
                className={classnames(
                    "list-group-item list-group-item-action",
                    { active: this.props.valueSelected === itemValue }
                )}
                onMouseDown={handleSelectValue}
            >
                {itemDescription}
            </li>
        );
    };

    private readonly handleUserLostFocus = () => {
        this.setState({
            userLostFocus: true,
            opened: null
        });
    }

    /**
     * Función encargada de establecer el valor seleccionado
     */
    private handleItemSelected = (itemValue: number | string) => {
        const selectedValue = itemValue && itemValue.toString();

        this.props.onValueAsStringChange &&
            this.props.onValueAsStringChange(selectedValue);

        if (this.props.onValueAsNumberChange != null) {
            this.props.onValueAsNumberChange(
                NumberHelper.tryConvertToNumber(selectedValue)
            );
        }

        if (this.props.onItemChange != null) {
            const selectedItem = this.findSelectedItem(selectedValue);

            this.props.onItemChange && this.props.onItemChange(selectedItem);
        }
    }

    /**
     * Muestra las sugerencias al usuario
     */
    private showSuggestions = () =>
        this.setState({
            opened: { searchTerm: this.findSelectedItemDescription(this.props.valueSelected) },
            suggestions: this.props.items
        });

    render() {
        const selectedItemDescription =
            this.state.opened != null ?
                this.state.opened.searchTerm :
                this.findSelectedItemDescription(this.props.valueSelected);

        const fixedValueSelected = NullHelper.valueOrDefault(this.props.valueSelected, "");
        const isInvalid = (
            this.props.required &&
            fixedValueSelected === "" &&
            (
                this.state.userChangedValue ||
                this.state.userLostFocus
            )
        );

        const markAsInvalid = isInvalid && !this.props.readonly;
        const markAsRequired = this.props.required && !this.props.readonly;

        const { suggestions } = this.state;


        return (
            <div style={{ position: "relative", width: "inherit" }}>
                <Labeled label={this.props.label}>
                    <BootstrapInput
                        invalid={markAsInvalid}
                        type="text"
                        onClick={this.showSuggestions}
                        onFocus={this.showSuggestions}
                        onBlur={this.handleUserLostFocus}
                        className="form-control"
                        placeholder={defaultSelectOption}
                        readOnly={this.props.readonly}
                        disabled={this.props.readonly}
                        required={markAsRequired}
                        value={selectedItemDescription || ""}
                        onChange={this.handleSearchChange}
                    >
                    </BootstrapInput>

                    {this.state.opened &&
                        <ul className="combo list-group animated fadeIn" style={{ position: this.props.positionFixed && "fixed", minWidth: this.props.positionFixed && "auto" }}>
                            {!this.props.required && suggestions.length > 0 ? this.createDefaultSelectOption(null, defaultSelectOption) : null}
                            {suggestions.map(this.getOptionFromItem)}
                            {suggestions.length === 0 && <div className="list-group-item text-center">No hay resultados</div>}
                        </ul>
                    }
                    <FormFeedback>Dato requerido</FormFeedback>
                </Labeled>
            </div>
        );
    }
}