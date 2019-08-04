/**
 * Dibuja el elemento @param element si @param value es true
 * @param value Valor buleano que que se comparará para determinar si se dibuja el elemento
 * @param element Elemento que se dibujará si @param value es true
 */
export function drawIfTrue(
    value: boolean | null,
    element: JSX.Element
){
    return value === true ? 
        element : 
        null;
}

/**
 * Dibuja lost elementos @param elements si @param value es true
 * Recuerde establecer el atributo key en los elementos que incluya
 * 
 * @param value Valor buleano que que se comparará para determinar si se dibuja el elemento
 * @param elements Elemento que se dibujará si @param value es true
 */
export function drawElementsIfTrue<TValue>(
    value: boolean | null,
    ...elements: JSX.Element[]
){
    return value === true ? elements : null;
}
