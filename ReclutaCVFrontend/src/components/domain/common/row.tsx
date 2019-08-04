import * as React from "react";
import { Row as BootstrapRow } from "reactstrap";
import { Column } from "./column";

interface RowProps {
    fullHeight?: boolean;
}

/**
 * Una fila que envuelve un conjunto de elementos
 */
export class Row extends React.Component<RowProps> {
    render() {
        return (
            <BootstrapRow style={{ height: this.props.fullHeight ? "100%" : undefined }}>
                {
                    React.Children.map(
                        this.props.children,
                        (child, childIndex) => {
                            //Si el componente ya es una columna, no envolveremos el child
                            return (child == null || child["type"] == Column) ?
                                <React.Fragment key={childIndex}>{child}</React.Fragment> :
                                <Column>{child}</Column>;
                        }
                    )
                }
            </BootstrapRow>
        );
    }
}