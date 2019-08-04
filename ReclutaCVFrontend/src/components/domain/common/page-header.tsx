// Dependencias globales
import React from "react";
import { Row } from "reactstrap";

// Genéricos
import { Title, Container } from "../../generic";

// Common
import { ReturnButton } from "./return-button";
import { Column } from "./column";

interface PageHeaderProps {
    title: string;
    extraButtons?: JSX.Element | JSX.Element[];
}

/**
 * Cabecera genérica para las páginas de la aplicación
 */
export const PageHeader: React.FC<PageHeaderProps> = props => (
    <>
        <div className="page-header">
            <ReturnButton />
            <Title className="m-0" title={props.title} />
            <Container alignRight>
                <Row>
                    {props.extraButtons}
                    <Column className="pl-1" />
                </Row>
            </Container>
        </div>
        <hr />
    </>
);
