import { StringHelper } from "./string-helper";
export class NumberHelper {
    /**
     * Número de caracteres máximos que acepta un número (entero o no) en el sistema
     */
    public static readonly numberMaxCharacters: number = 16;
    /**
     * Número de caracteres máximos que acepta un entero
     */
    public static readonly integerMaxCharacters: number = 9;

    /**
     * A partir de la cadena de texto, la cual se supone debería ser un número
     * Retira todos los caracteres que no sean válidos para un número y cualquier error de sintaxis númerica
     * @param str 
     */
    public static sanitizeNumericString(str: string): string {
        return str && str.replace(/[^\d\.]/gi, "")
            .replace(/\.(?=.*\.)/g, "");
    }

    /**
     * Intenta convertir la cadena de texto a número, si la conversión no es posible o no es numérica, regresa null
     * @param str 
     */
    public static tryConvertToNumber(str: string) {
        return NumberHelper.isNumber(str) ? Number(str) : null;
    }

    /**
     * Determina si la cadena de texto es un número
     * @param str 
     */
    public static isNumber(str: string) {
        return !StringHelper.isNullOrWhiteSpace(str) && !isNaN(Number(str));
    }

    /**
     * Agrega un string al inicio a la cadena de texto
     * @param target, str
     */
    public static padLeft(str: string, length?: number, pad?: string) {
        return str.padStart(length, pad);
    }
}