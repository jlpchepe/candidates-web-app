const millisecondsToMinuteFactor = 1000 * 60;

/**
 * Métodos de ayuda para operar sobre objetos Date
 */
export class DateHelper {
    /**
     * Obtiene la fecha actual, con UTC-0, a las cero horas
     */
    public static todayUtcZeroTruncate() : Date {
        return DateHelper.removeUtcOffset(DateHelper.cloneDateTruncateTime(DateHelper.now()));
    }

    /**
     * Obtiene la fecha y hora actual
     */
    public static now() : Date {
        return new Date();
    }

    /**
     * Remueve las horas de diferencia del UTC local con respecto al UTC-0
     * Por ejemplo, si el es 2019-02-02T08:00:00UTC-7, se regresará 2019-02-02T01:00:00UTC-7 (equivalente a 2019-02-02T08:00:00UTC-0)
     * @param date 
     */
    public static removeUtcOffset(
        date: Date | null
    ) : Date | null {
        if(date == null){
            return null;
        }

        return DateHelper.addMinutes(
            date, 
            -date.getTimezoneOffset()
        );
    }

    /**
     * Agrega las horas de diferencia del UTC local con respecto al UTC-0
     * Por ejemplo, si el es 2019-02-02T08:00:00UTC-7 (equivalente a 2019-02-02T15:00:00UTC-0), se regresará 2019-02-02T15:00:00UTC-7
     * @param date 
     */
    public static addUtcOffset(
        date: Date | null
    ) : Date | null {
        if(date == null){
            return null;
        }

        return DateHelper.addMinutes(
            date, 
            date.getTimezoneOffset()
        );
    }

    /**
     * Convierte la hora UTC a la hora local equivalente, respetando los valores de los componentes del objeto Date
     * Por ejemplo, la fecha: 2019-01-01T00:00:00 GMT-0 se transformará a 2019-01-01T00:00:00 GMT-7
     * @param utcDate 
     */
    public static toLocalDate(utcDate: Date){
        if(utcDate == null){
            return null;
        }

        return new Date(
            utcDate.getUTCFullYear(),
            utcDate.getUTCMonth(),
            utcDate.getUTCDate(),
            utcDate.getUTCHours(),
            utcDate.getUTCMinutes(),
            utcDate.getUTCSeconds(),
            utcDate.getUTCMilliseconds()
        );
    }

    /**
     * Convierte el objeto Date a UTC, respetando los mismos valores de los componentes que ya tenía solo cambiando la zona horaria
     * Por ejemplo, la fecha: 2019-01-01T21:20:00 GMT-7 se transformará a 2019-01-01T00:00:00 GMT-7
     * Si la fecha es null, regresa null
     */
    public static cloneDateTruncateTime(
        localDate: Date
    ){
        if(localDate == null){
            return null;
        }

        return new Date(
            localDate.getFullYear(),
            localDate.getMonth(),
            localDate.getDate(),
            0,
            0,
            0,
            0
        );
    }

    /**
     * Obtiene la diferencia entre las dos fechas en milisegundos
     * Si alguna de las fechas es null, regresa null
     * @param endDate 
     * @param initialDate 
     */
    public static diffMilliseconds(endDate: Date, initialDate: Date) {
        if (endDate == null || initialDate == null) {
            return null;
        }

        return endDate.getTime() - initialDate.getTime();
    }

    /**
     * Obtiene la diferencia entre las dos fechas en minutos enteros
     * Si alguna de las fechas es null, regresa null
     * @param endDate 
     * @param initialDate 
     */
    public static diffMinutes(endDate: Date, initialDate: Date) {
        const millisencondsDiff = DateHelper.diffMilliseconds(endDate, initialDate);

        return millisencondsDiff != null ? 
            Math.trunc(millisencondsDiff / millisecondsToMinuteFactor) : 
            null;
    }

    private static padLeftWithZeroTwoDigits(value: number){
        const valueAsString = `${value}`;

        return valueAsString.length < 2 ? `0${valueAsString}` : valueAsString;
    }

    private static formatTimeComponents(...parts: number[]) {
        return parts.map(part => DateHelper.padLeftWithZeroTwoDigits(part)).join(":");
    }

    /**
     * Aplica formato de hora a la fecha indicada HH:mm
     * Si la fecha es null, se regresa null
     */
    public static formatToShortTime(date: Date) {
        if (date == null) { return null; }

        return DateHelper.formatTimeComponents(date.getHours(), date.getMinutes());
    }

    /**
     * Aplica formato de hora a la fecha indicada HH:mm:ss
     * Si la fecha es null, se regresa null
     */
    private static formatToLongTime(date: Date){
        if (date == null) { return null; }

        return DateHelper.formatTimeComponents(date.getHours(), date.getMinutes(), date.getSeconds());
    }

    /**
     * Da formato corto a la fecha especificada, considerando el UTC local
     * @param date 
     */
    public static formatShortDateLocal(date: Date) : string {
        return date != null ? 
            `${DateHelper.padLeftWithZeroTwoDigits(date.getDate())}/${DateHelper.padLeftWithZeroTwoDigits(date.getMonth() + 1)}/${DateHelper.padLeftWithZeroTwoDigits(date.getFullYear())}` :
            null;
    }

    /**
     * Da formato largo (DD:MM:YYY HH:MM) a la fecha especificada, considerando el UTC local
     * @param date 
     */
    public static formatLongDateLocal(date: Date) : string {
        return date != null ? 
            DateHelper.formatShortDateLocal(date) + " " + DateHelper.formatToLongTime(date) : 
            null;
    }

    /**
     * Da formato corto a la fecha especificada, considerando el UTC cero
     * @param date 
     */
    public static formatShortDateUtc(date: Date){
        return date != null ?
            DateHelper.formatShortDateLocal(DateHelper.toLocalDate(date)) :
            null;
    }

    /**
     * Da formato largo (DD:MM:YYY HH:MM) a la fecha especificada, considerando el UTC cero
     * @param date 
     */
    public static formatLongDateUtc(date: Date){
        return date != null ?
            DateHelper.formatLongDateLocal(DateHelper.toLocalDate(date)) :
            null;
    }

    /**
     * Agrega los minutos a la fecha indicada
     * @param date 
     * @param minutes Pueden ser positivos o negativos
     */
    public static addMinutes(date: Date, minutes: number) : Date {
        const millisecondsToAdd = minutes * millisecondsToMinuteFactor;
        return new Date(date.getTime() + millisecondsToAdd);
    }

    /**
     * Intenta convertir la fecha de texto a un objeto {@link date}
     * Si no se puede realizar la conversión, regresa null
     * @param date 
     */
    public static tryParseDate(date: string){
        const parsedDate = new Date(date);
        
        return isNaN(parsedDate.getTime()) ? null : parsedDate;
    }
};