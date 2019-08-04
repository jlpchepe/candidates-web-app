import { ApplicationAvailableColor, ApplicationAvailableIcon } from "../look-and-feel/resources";

export interface Notification {
    alertHeading?: string;
    alertIcon?: ApplicationAvailableIcon;
    alertMessage?: string;
    color?: ApplicationAvailableColor;
}

export const createErrorNotification = (heading: string, message: string): Notification => ({
    alertHeading: heading,
    alertIcon: "bars",
    alertMessage: message,
    color: "danger"
});

export const createSuccessNotification = (heading: string, message: string): Notification => ({
    alertHeading: heading,
    alertIcon: "bars",
    alertMessage: message,
    color: "success"
});

export const createWarningNotification = (heading: string, message: string): Notification => ({
    alertHeading: heading,
    alertIcon: "bars",
    alertMessage: message,
    color: "warning"
});
