export interface EnumType {
    [index: string]: number | string;
}

export class EnumHelper {
    /**
     * Obtiene los valores posibles del enum
     * @param enumType 
     */
    static getValues<TEnum>(enumType: any) : TEnum[] {
        return Object.keys(enumType)
            .map(key => Number(enumType[key]))
            .filter(key => !isNaN(key))
            .map(key => key as any as TEnum);
    }
}