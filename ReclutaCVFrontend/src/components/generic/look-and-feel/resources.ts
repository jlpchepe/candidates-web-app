/**
 * Íconos disponibles para usarse en la aplicación
 */
export type ApplicationAvailableIcon =
    | "arrow-left"
    | "ban"
    | "bars"
    | "bell"
    | "bolt"
    | "car"
    | "check"
    | "chevron-down"
    | "clipboard-list"
    | "code-branch"
    | "cog"
    | "comments"
    | "dot-circle"
    | "eye"
    | "edit"
    | "exclamation-triangle"
    | "external-link-square-alt"
    | "file-image"
    | "flag"
    | "hammer"
    | "hand-paper"
    | "hard-hat"
    | "hashtag"
    | "home"
    | "hourglass"
    | "lightbulb"
    | "microchip"
    | "paper-plane"
    | "play"
    | "play-circle"
    | "pause"
    | "pause-circle"
    | "screwdriver"
    | "sign-in-alt"
    | "stop"
    | "stop-circle"
    | "times"
    | "toggle-on"
    | "toggle-off"
    | "tools"
    | "trash"
    | "user-circle"
    | "user-clock"
    | "user-tie"
    | "wrench";

/**
 * Colores disponibles para usarse en la aplicación
 */
export type ApplicationAvailableColor =
    | "primary"
    | "secondary"
    | "tertiary"
    | "link"
    | "info"
    | "success"
    | "warning"
    | "danger";

/**
 * Tamaños disponibles para usarse en los iconos de la aplicación
 */
export type ApplicationAvailableIconSize = "2x" | "3x" | "5x" | "7x" | "9x";
/**
 * Tamaños disponibles para usarse en las etiquetas de la aplicación
 */
export type ApplicationAvailableButtonSize = "sm" | "lg";

/**
 * Estilos disponibles para usarse en la aplicación
 */
export type ApplicationAvailableFaStyle = "fas" | "far";

/**
 * Tamaños disponibles para las columnas
 */
export type ApplicationColumnSize = 1 | 2 | 3 | 4 | 5 | 6 | 7 | 8 | 9 | 10 | 11 | 12;

/**
 * A partir de un color soportado en la aplicación, lo convierte a una clase de CSS
 */
export function colorToBackgroundClassName(color: ApplicationAvailableColor) {
    return color != null ? `bg-${color}` : "";
}

/**
 * A partir de un color soportado en la aplicación, lo convierte a una clase de CSS
 */
export function colorToTextColorClassName(color: ApplicationAvailableColor) {
    return color != null ? ` text-${color}` : "";
}

export function spinToCssFontAwesomeClassName(spin: boolean) {
    return spin ? " fa-spin" : "";
}

/**
 * A partir de un color soportado en la aplicación, lo convierte a su equivalente en nombre de clase CSS para colocarlo en botones
 * @param color
 */
export function colorToButtonCssClassColor(color: ApplicationAvailableColor) {
    switch (color) {
        case "primary":
            return "primary";
        case "secondary":
            return "secondary";
        case "tertiary":
            return "tertiary";
        case "link":
            return "link";
        case "info":
            return "info";
        case "success":
            return "success";
        case "warning":
            return "warning";
        case "danger":
            return "danger";
        case null || undefined:
            return "";
        default:
            "primary";
    }
}

/**
 * A partir de un ícono soportado en la aplicación, lo convierte a su equivalente en nombre de clase CSS
 * @param icon
 */
export function iconToIconCssClassName(
    icon: ApplicationAvailableIcon,
    size?: ApplicationAvailableIconSize,
    color?: ApplicationAvailableColor,
    style?: ApplicationAvailableFaStyle,
    spin?: boolean
): string {
    return (
        faStyleToCssFontAwesomeClassName(style) +
        iconToCssFontAwesomeClassName(icon) +
        sizeToCssFontAwesomeClassName(size) +
        colorToTextColorClassName(color) +
        spinToCssFontAwesomeClassName(spin)
    );
}

function iconToCssFontAwesomeClassName(icon: ApplicationAvailableIcon): string {
    switch (icon) {
        default:
            return " fa-" + icon;
    }
}

function sizeToCssFontAwesomeClassName(size: ApplicationAvailableIconSize): string {
    switch (size) {
        case "2x":
        case "3x":
        case "5x":
        case "7x":
        case "9x":
            return " fa-" + size;
        default:
            return "";
    }
}

function faStyleToCssFontAwesomeClassName(style: ApplicationAvailableFaStyle): string {
    switch (style) {
        case "fas":
            return "fas";
        case "far":
            return "far";
        default:
            return "fas";
    }
}
