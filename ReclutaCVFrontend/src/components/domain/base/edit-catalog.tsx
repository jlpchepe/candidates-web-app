import * as React from "react";

import { TPromiseLike } from "../../../helpers/promise-helper";
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
    onSave: (goBackAfterSave: boolean) => TPromiseLike<void>;
}

/**
 * Una vista de catálogo de edición
 */
export class EditCatalog extends React.Component<EditCatalogProps> {
    render() {
        const drawSaveButton: boolean =
            this.props.readonly !== true && this.props.onSave != null;

        const saveButtons = drawSaveButton ? 
            <>
                <Button color="primary" className="mr-1" label="Guardar" onClick={() => this.props.onSave(false)} />
                <Button color="primary" label="Guardar y regresar" onClick={() => this.props.onSave(true)} /> 
            </> :
            null;

        return (
            <Container fluid={this.props.fluid} container={!this.props.fluid}>
                <PageHeader title={this.props.title} extraButtons={saveButtons}/>
                {this.props.children}
                {saveButtons}
            </Container>
        );
    }
}
