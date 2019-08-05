import React from "react";
import { BorderColorProperty, BackgroundColorProperty, BorderStyleProperty } from "csstype";
import classNames from "classnames";

interface BorderProps {
    color?: BorderColorProperty;
    style?: BorderStyleProperty;
}

interface ContainerProps {
    background?: BackgroundColorProperty;
    border?: BorderProps;
    container?: boolean;
    fluid?: boolean;
    /**
     * Establece la mínima altura del contenedor
     * Si se establece "full-height", se colocará el contenedor para que ocupe el 100% de la altura que tenga disponible
     */
    fullHeight?: boolean;
    height?: number | string;
    navPills?: boolean;
    paddingRight?: number | string;
    alignRight?: boolean;
    width?: number | string;
    flex?: boolean;
    alignBottom?: boolean;
    marginLeft?: string;
}

/**
 * Contenedor de cualquier tipo y número de elementos
 */
export const Container: React.FC<ContainerProps> = props => (
    <div
        className={classNames({
            container: props.container,
            "container-fluid": props.fluid,
            "h-100": props.fullHeight,
            "nav-pills": props.navPills
        })}
        style={{
            background: props.background,
            borderColor: props.border && props.border.color,
            borderStyle: props.border && props.border.style,
            marginTop: props.alignBottom && "auto",
            marginLeft: props.marginLeft || (props.alignRight && "auto"),
            paddingRight: props.paddingRight,
            width: props.width,
            display: props.flex && "flex"
        }}
    >
        {props.children}
    </div>
);
