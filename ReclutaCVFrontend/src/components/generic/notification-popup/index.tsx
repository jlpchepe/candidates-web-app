import React from "react";

import { Alert } from "reactstrap";

interface NotificationPopupProps {
    alertHeading?: string;
    alertIcon?: string;
    alertMessage?: string;
    color?: string;
    onCloseNotification?: () => void;
}

/**
 * Una notificación tipo pop-up que se le muestra al usuario en pantalla
 */
export class NotificationPopup extends React.Component<NotificationPopupProps> {
    

    render() {
        const {
            alertHeading,
            alertIcon,
            alertMessage,
            color,
            onCloseNotification
        } = this.props;

        return (
            <Alert color={color} toggle={onCloseNotification} >
                <h4 className="alert-heading">{alertHeading}</h4>
                <span className="alert-inner--icon">
                    <i className={alertIcon} />
                </span>{" "}
                <span className="alert-inner--text">{alertMessage}</span>
            </Alert>
        );
    }
}

