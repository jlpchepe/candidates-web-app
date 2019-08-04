import React from "react";
import { NotificationPopup } from "../notification-popup";
import { Notification } from "./notification";
import { NotificationHelper } from "../../../helpers/notification-helper";


interface NotificationCenterState {
    notifications: Notification[];
}

/**
 * Tiempo en el cual se estará mostrando una notificación
 */
const notificationTimeout = 3000;

/**
 * Punto central que se encarga de mostrar y posteriormente ocultar las notificaciones tipo pop-up
 */
export class NotificationCenter extends React.Component<{}, NotificationCenterState> {

    state: NotificationCenterState = {
        notifications: []
    }
    
    componentDidMount() {
        // Se suscribe al flujo de notificaciones de la aplicación
        NotificationHelper.subscribe(notification => {
            this.setState(prevState => ({ 
                notifications: [...prevState.notifications, notification] 
            }));

            // Temporizador que cuenta el tiempo para que una notificación desaparezca
            const timer = setTimeout(
                () => {
                    this.onFadeNotification(notification);
                    clearTimeout(timer);
                }, 
                notificationTimeout
            );
        });
    }

    onDeleteNotification = (notificationToDelete: Notification) => 
        this.setState(prevState => ({
            notifications: 
                prevState.notifications.filter(notification => 
                    notification !== notificationToDelete
                )
        }));
        
    onFadeNotification = (notificationToFade: Notification) => {
        this.setState(prevState => ({
            notifications: 
                prevState.notifications.filter(notification => 
                    notification != notificationToFade
                )
        }));
    };

    render() {
        const { notifications } = this.state;
        return (
            <div className="notification-center">
                {
                    notifications.map((notification, notificationIndex) =>    
                        <NotificationPopup
                            key={notificationIndex}
                            {...notification}
                            onCloseNotification={() => this.onDeleteNotification(notification)}
                        />
                    )
                }
            </div>
        );
    }
}
