import { StringHelper } from "./string-helper";

const validColorRegex = /(?:#[a-f0-9]{6})/;

export class ColorHelper {
    /**
     * Determina si se trata de un color valido
     * @param hexColor
     */
    public static isValidHexColor(hexColor: string) {
        return !StringHelper.isNullOrWhiteSpace(hexColor) && validColorRegex.test(hexColor);
    }

    /**
     * Conversion de hex a rgb para uso en calculo de luminosidad
     * @param hexColor
     */
    private static hexToRgb(hexColor: string) {
        const result = /^#?([a-f\d]{2})([a-f\d]{2})([a-f\d]{2})$/i.exec(hexColor);
        return (
            result && {
                r: parseInt(result[1], 16),
                g: parseInt(result[2], 16),
                b: parseInt(result[3], 16)
            }
        );
    }

    /**
     *  Calculamos la luminosidad para determinar si un color de fondo es brilloso o no
     *  Regresa negro si el color es brilloso y blanco si es oscuro
     * @param hexColor
     */
    public static fixTextColorBaseOnBackground(hexColor: string) {
        if (!validColorRegex.test(hexColor)) {
            return "#000000";
        }
        const rgb = this.hexToRgb(hexColor);
        const luma = (0.299 * rgb.r + 0.587 * rgb.g + 0.114 * rgb.b) / 255;
        return luma > 0.5 ? "#000000" : "#FFFFFF";
    }
}
