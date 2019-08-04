export class NullHelper {
    /**
     * Regresa {@param valueOrNull} si es diferente de null o {@param defaultIfNull} en caso contrario
     * @param valueOrNull 
     * @param defaultIfNull 
     */
    static valueOrDefault<TValue>(
        valueOrNull: TValue | null | undefined, 
        defaultIfNull: TValue
    ){
        return valueOrNull != null ? valueOrNull : defaultIfNull;
    }

}