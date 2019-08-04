import * as React from "react";
import { Input as BootstrapInput, FormFeedback } from "reactstrap";
import { Button } from "reactstrap";
import { StringHelper } from "../../../helpers/string-helper";
import { ArrayHelper } from "../../../helpers/array-helper";
import classnames from "classnames";
import { NumberHelper } from "../../../helpers/number-helper";
import { NullHelper } from "../../../helpers/null-helper";
import { Labeled } from "../label/labeled";

interface AsyncComboWithButtonProps<TSelectable> {
    items: TSelectable[],
    label: string;
    valueSelected?: string | number | null;
    valueSelector: (item: TSelectable) => number;
    descriptionSelector: (item: TSelectable) => string;
    onValueAsStringChange?: (value: string) => void;
    onValueAsNumberChange?: (value: TSelectable) => void;
    required?: boolean;
    readonly?: boolean;
    /**
     * Operación a realizar cuando se seleccione otro elemento
     */
    onItemChange?: (item: TSelectable) => void;
    /**
     * Operación a realizar cuando se haga clic en el boton de Agrgar
     */
    onClick?: () => void;
}

interface LabeledComboStateOpenedState {
    /**
     * Término que introdujo el usuario como busqueda
     */
    searchTerm: string;
}

interface AsyncComboWithButtonState<TSelectable> {
    userChangedValue: boolean;
    userLostFocus: boolean;

    /**
     * Indica si se muestra el contenedor de las sugerencias
     */
    opened?: LabeledComboStateOpenedState;

    /**
     * Sugerencias a mostrar cuando se realice la busqueda 
     */
    suggestions: TSelectable[];
}

export class AsyncComboWithButton<TSelectable> extends React.Component<AsyncComboWithButtonProps<TSelectable>, AsyncComboWithButtonState<TSelectable>> {
    constructor(props) {
        super(props);
        this.state = {
            userChangedValue: false,
            userLostFocus: false,
            opened: undefined,
            // Se establecen los valores predeterminados antes del render
            suggestions: props.items
        };
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
        item: TSelectable,
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
                onClick={handleSelectValue}
            >
                {itemDescription}
            </li>
        );
    };

    private readonly handleUsuarioLostFocus = () => {
        this.setState({
            userLostFocus: true,
            opened: null
        });

        const { suggestions } = this.state;

        // Si no hay valor seleccionado y hay al menos una coincidencia, se selecciona la primer coincidencia
        if (
            this.props.valueSelected == null &&
            suggestions.length > 0 &&
            this.props.required
        ) {
            const firstSuggestionCoincidence = ArrayHelper.firstOrNull(suggestions);

            // Si sí hay sugerencias se toma el primer valor encontrado o el valor previamente establecido
            this.handleItemSelected(this.props.valueSelector(firstSuggestionCoincidence));
        }
    }

    /**
     * Función encargada de establecer el valor seleccionado
     */
    private handleItemSelected = (itemValue: number | string) => {
        const selectedValue = itemValue && itemValue.toString();

        this.props.onValueAsStringChange &&
            this.props.onValueAsStringChange(selectedValue);


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
            <Labeled label={this.props.label}>
                <div className="input-group">
                    <BootstrapInput
                        invalid={markAsInvalid}
                        type="text"
                        onClick={this.showSuggestions}
                        onFocus={this.showSuggestions}
                        onBlur={this.handleUsuarioLostFocus}
                        className="form-control"
                        placeholder={"--Seleccione--"}
                        disabled={this.props.readonly}
                        required={markAsRequired}
                        value={selectedItemDescription || ""}
                        onChange={this.handleSearchChange}
                    />
                    {this.state.opened &&
                        <ul className="combo list-group animated fadeIn" style={{ top: "40px" }}>
                            {suggestions.map(this.getOptionFromItem)}
                            {suggestions.length === 0 && <div className="list-group-item text-center">No hay resultados</div>}
                        </ul>
                    }
                    <FormFeedback>Dato requerido</FormFeedback>
                    <div className="input-group-append">
                        <Button 
                            label="Agregar"
                            onClick={this.props.onClick}
                        >
                            Agregar
                        </Button>
                    </div>
                </div>
            </Labeled>
        );
    }


}

