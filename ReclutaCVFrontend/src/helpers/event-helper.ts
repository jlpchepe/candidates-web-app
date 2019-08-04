/**
 * A partir de un evento de cambio de un input, obtiene el valor como cadena de texto
 * @param event 
 */
export function getInputEventStringValue(
    event: React.ChangeEvent<HTMLInputElement>
) : string | null {
    return getInputEventAnyValue(event);
}

/**
 * A partir de un evento de cambio de un input, obtiene el valor sin tipado
 * @param event 
 */
export function getInputEventAnyValue(
    event: React.SyntheticEvent<HTMLInputElement>
) : any {
    return (<any>event.target).value;
}

/**
 * A partir de un evento de cambio de un select, obtiene el valor seleccionado "value" como cadena de texto
 * @param event 
 */
export function getSelectEventStringValueOrNull(
    event: React.ChangeEvent<HTMLSelectElement>
) : string | null {
    return (<any>event.currentTarget).value;
}