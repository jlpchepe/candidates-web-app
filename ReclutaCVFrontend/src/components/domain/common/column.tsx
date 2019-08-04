import React from "react";
import classnames from "classnames";
import { Col as BootstrapCol } from "reactstrap";
import { ApplicationAvailableColor, colorToBackgroundClassName, ApplicationColumnSize } from "../../generic/look-and-feel/resources";

interface ColumnProps {
    size?: ApplicationColumnSize;
    color?: ApplicationAvailableColor;
    className?: string;
    onClick?: (id, workOrderId?) => void;
}

/**
 * Una fila que envuelve un conjunto de elementos
 */
export class Column extends React.Component<ColumnProps> {
    render() {
        return (
            <BootstrapCol
                className={classnames(this.props.className, colorToBackgroundClassName(this.props.color))}
                md={this.props.size}
                onClick={this.props.onClick}
                style={this.props.onClick != null ? {cursor: "pointer"} : null }
            >
                {this.props.children}
            </BootstrapCol>
        );
    }
}
