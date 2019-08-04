/**
 * Formato de fecha en JSON
 */
const jsonDateFormat : RegExp = /^\d{4}-\d{2}-\d{2}T\d{2}:\d{2}:\d{2}(?:\.\d+)?Z?$/;

// Debido a que las fechas en JSON no tienen un tipo específico, sino que son string, 
// esta función las revive como objetos Date
const dateReviver = (key, value) => 
    typeof value === "string" && jsonDateFormat.test(value) ?
        new Date(value) : 
        value;

/**
 * Métodos de ayuda para trabajar con JSON
 */
export class JsonHelper{
    /**
     * Método para convertir los tipos especiales de string a su tipo verdadero en JS, como las fechas
     */
    public static parseAndRevive<TResult>(
        json: string
    ) : TResult | string {
        try{
            return JSON.parse(json, dateReviver);
        }
        catch(error) {
            return json;
        }
    }
}