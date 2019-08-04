import * as React from "react";
import { TPromiseLike, toPromise } from "../../../helpers/observable-helper";
import { LabeledCombo } from "./combo";

/**
 * Propiedades del combo
 */
interface LabeledAsyncComboProps<TListable> {
    getItems: () => TPromiseLike<TListable[]>;
    label: string;
    valueSelected?: number | null;
    valueSelector: (item: TListable) => number;
    descriptionSelector: (item: TListable) => string;
    onValueAsNumberChange?: (value: number) => void;
    required?: boolean;
    readonly?: boolean;
}

interface LabeledAsyncComboState<TListable> {
    items: TListable[]
}

/**
 * Un combo para seleccionar elementos en la aplicación
 */
export class LabeledAsyncCombo<TListable> extends React.Component<LabeledAsyncComboProps<TListable>, LabeledAsyncComboState<TListable>> {
    constructor(props){
        super(props);

        this.state = {
            items: null
        };
    }

    componentDidMount(){
        toPromise(this.props.getItems())
            .subscribe(items => this.setState({
                items: items
            }));
    }

    render(){
        return this.state.items != null ?
            <LabeledCombo 
                items={this.state.items}
                label={this.props.label}
                valueSelector={this.props.valueSelector}
                descriptionSelector={this.props.descriptionSelector}
                onValueAsNumberChange={this.props.onValueAsNumberChange}
                valueSelected={this.props.valueSelected}
                readonly={this.props.readonly}
                required={this.props.required}
            ></LabeledCombo> : 
            null;
    }
}