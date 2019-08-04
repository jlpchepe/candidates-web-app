import React from "react";
import { Button, Icon, CircularButton } from "../../generic";
import { withRouter, RouteComponentProps } from "react-router";
import { goBack } from "../../../helpers/navigation-helper";

/**
 * Botón para regresar atrás en la aplicación
 */
export class ReturnButtonSimple extends React.Component<RouteComponentProps> {
    goBackClick = () => goBack(this.props.history);

    render() {
        return (
            <div className="mr-3">
                <CircularButton color="link" icon="arrow-left" onClick={this.goBackClick} isOutlined />
            </div>
        );
    }
}

export const ReturnButton = withRouter(ReturnButtonSimple);
