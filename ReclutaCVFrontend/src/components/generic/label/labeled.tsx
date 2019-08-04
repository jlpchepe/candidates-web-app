import * as React from "react";
import { Label } from "./label";
import { FormGroup } from "reactstrap";


interface LabeledProps {
    label?: string;
}

/**
 * Envuelve los elementos en su interior y les coloca una etiqueta
 */
export class Labeled extends React.Component<LabeledProps> {
    render() {
        return (
            this.props.label ?
                (
                    <FormGroup>
                        <Label>{this.props.label}</Label>
                        {this.props.children}
                    </FormGroup>
                ) :
                this.props.children
        );
    }
}