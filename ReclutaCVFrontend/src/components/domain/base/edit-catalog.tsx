import * as React from "react";

import { TPromiseLike } from "../../../helpers/observable-helper";
import { drawIfTrue } from "../../../helpers/react-helper";
import { Button, Container } from "../../generic";
import { PageHeader } from "../common/page-header";

interface EditCatalogProps {
    fluid?: boolean;
    title: string;
    /**
     * Indica si se cargará el modelo en modo de solo lectura
     */
    readonly?: boolean;
    /**
     * Función a ejecutar cuando el usuario indique guardar
     */
    onSave: () => TPromiseLike<void>;
}

/**
 * Una vista de catálogo de edición
 */
export class EditCatalog extends React.Component<EditCatalogProps> {
    render() {
        const drawSaveButton: boolean =
            this.props.readonly !== true && this.props.onSave != null;

        return (
            <Container fluid={this.props.fluid} container={!this.props.fluid}>
                <PageHeader title={this.props.title} />
                {this.props.children}
                {drawIfTrue(
                    drawSaveButton,
                    <Button color="primary" label="Guardar" onClick={this.props.onSave} />
                )}
            </Container>
        );
    }
}
