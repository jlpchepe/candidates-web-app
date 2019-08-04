import * as React from "react";
import { Route as BrowserRoute } from "react-router-dom";
import { TRouteComponent } from "../../layout/routing-relation-repository";

interface RouteProps {
    /**
     * Ruta que se compara contra la URL relativa del navegador para determinar si se muestra el contenido
     */
    path: string;

    component?: TRouteComponent;
}

/**
 * Una ruta, en esencia es un contenedor que muestra lo que lleva dentro solo si la ruta del navegador coincide con la suya
 */
export class AppRoute extends React.Component<RouteProps> {
    render() {
        return (
            <BrowserRoute
                exact={true}
                path={this.props.path}
                component={this.props.component}
            />
        );
    }
}
