import { Observable, Subject } from "rxjs";
import { Notification, createErrorNotification, createWarningNotification } from "../components/generic/notification-center/notification";

const notificationObservable = new Subject<Notification>();

/**
 * Métodos de ayuda para mostrar notificaciones tipo pop-up en el sistema
 */
class NotificationHelperImpl {
    /**
     * Realiza una notificación
     */
    private notify = (notification: Notification) =>
        notificationObservable.next(notification);
    
    /**
     * Realiza una notificación de error
     */
    notifyError = (heading: string, message: string) =>
        this.notify(createErrorNotification(heading, message));

    /**
     * Realiza una notificación de advertencia
     */
    notifyWarning = (heading: string, message: string) =>
        this.notify(createWarningNotification(heading, message));

    /**
     * Se suscribe a las notificaciones tipo pop-up que ocurren desde el momento de la suscripción
     */
    subscribe = (onNotification: ((notification: Notification) => void)) =>
        notificationObservable.subscribe(onNotification);
}

export const NotificationHelper = new NotificationHelperImpl();