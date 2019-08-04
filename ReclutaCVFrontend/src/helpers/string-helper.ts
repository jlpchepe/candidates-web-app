export class StringHelper {
    
    /**
     * Determina si la cadena de texto es nula, cadena vacía o espacios en blanco
     * @param str 
     */
    public static isNullOrWhiteSpace(str: string): boolean {
        return str == null || String(str).trim() == "";
    }

    /**
     * Determina si la cadena de texto es nula o cadena vacía
     * @param str 
     */
    public static isNullOrEmpty(str: string): boolean {
        return str == null || str == "";
    }

    /**
     * Devuelve la cadena de texto si es diferente de null, de otro modo, regresa una cadena vacía
     * @param str 
     */
    public static valueOrEmpty(str: string){
        return str || "";
    }

    /**
     * Determina si el @param text contiene @param searchTerm
     * Ignora diferencias en el casing
     * @param text Si es null, se regresa false
     * @param searchTerm Si es null, se regresa true
     */
    public static containsCaseInsensitive(
        text: string, 
        searchTerm: string
    ){
        return searchTerm == null || (
            text != null && 
            text.toLowerCase().includes(searchTerm.toLowerCase())
        );
    }

    //Caracteres que se van a reemplazar dentro del input
    private static readonly sanitizeTable = {"Á":"A","É":"E", "Ë": "E", "Í":"I","Ó":"O","Ü":"U","Ú":"U"};

    /**
     * Sanitiza la entrada de texto indicada según las reglas de negocio de la aplicación
     */
    public static sanitizeTextInput(text: string | null) : string | null {
        //vocales con acento los cambiamos por su equivalente sin acento
        return text && text.replace(/./g, char => StringHelper.sanitizeTable[char] || char).toUpperCase();
    }
}