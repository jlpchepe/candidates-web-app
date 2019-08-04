export class ArrayHelper {
    /**
     * Determina si el arreglo tiene algún elemento
     */
    public static any<TItem>(items: TItem[]){
        return items != null && items.length > 0;
    }

    /**
     * Obtiene el primer elemento del arreglo o null si no tiene elementos
     * @param items 
     */
    public static firstOrNull<TItem>(
        items: TItem[]
    ) : TItem {
        const [firstElement = null] = items;

        return firstElement;
    }

    /**
     * Encuentra el primer elemento en {@param items} que encaje con el {@param predicate} indicado
     * @param items 
     * @param predicate 
     */
    public static findFirstOrNull<TItem>(
        items: TItem[], 
        predicate: (item: TItem) => boolean
    ) : TItem {
        return items.find(predicate);
    }

    /**
     * Regresa un nuevo arreglo vacío
     */
    public static emptyArray<TItem>() : TItem[] {
        return [];
    }

    /**
     * En el arreglo indicado
     * Reemplaza el elemento @param oldItem con el @param newItem
     * Si el elemento @param oldItem no está en el arrego, esta función no hace nada
     * Esta función es pura, se regresa un nuevo arreglo
     * @param items 
     * @param oldItem 
     * @param newItem 
     */
    public static replace<TItem>(
        items: TItem[], 
        oldItem: TItem, 
        newItem: TItem
    ) : TItem[] {
        const oldItemIndex = items.indexOf(oldItem);

        // Si el elemento indicado no está en el arreglo, se devuelve el arreglo actual
        if(oldItemIndex == -1){
            return [...items];
        }

        return [
            ...items.slice(0, oldItemIndex), 
            newItem, 
            ...items.slice(oldItemIndex + 1, items.length)
        ];
    }
}