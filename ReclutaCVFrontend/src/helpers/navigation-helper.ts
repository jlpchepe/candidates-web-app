import { NumberHelper } from "./number-helper";
import { History, Location } from "history";
import { match } from "react-router";

export function getPathDivisor(): string {
    return "/";
}

/**
 * Se dirige en el navegador al path indicado, siempre sobrescribe el path actual con el que se establezca
 * Si desea que este path se adjunte al path en el que se encuentra actualmente el usuario, use el método @function goToRelativePath
 */     
export function goToPath(
    history: History,
    path: string,
    state?: object,
){
    const pathDivisor = getPathDivisor();
    const fixedPath = (path.startsWith(pathDivisor) ? null : pathDivisor) + path;

    history.push(fixedPath, state);
}

/**
 * Se dirige a la página anterior donde se encontraba el navegador
 * @param path 
 */
export function goBack(history: History) : void { history.goBack(); }

function readParam(match: match, param: string) : string | null | undefined {
    return match.params[param];
}

/**
 * A partir de los parámetros de consulta de la URL, obtiene el valor del parámetro indicado
 * Si el valor 
 */
export function readNumberQueryParam(
    location: Location,
    paramName: string
) : number | null {
    const stringValue = location.search.replace(
        new RegExp(`^.*[\?&]${paramName}=(\\w+)&?.*`), 
        "$1"
    );

    return NumberHelper.tryConvertToNumber(stringValue);
}

export function readStringPathParam(
    match: match,
    paramName: string
) : number | null {
    const stringParamValue: any = readParam(match, paramName);

    return stringParamValue;
}

export function readNumberPathParam(
    match: match,
    paramName: string
) : number | null {
    const paramValue: any = readParam(match, paramName);

    return isNaN(paramValue) ? 
        null : 
        Number(paramValue);
}

/**
 * Intenta leer el parámetro booleano con el nombre indicado, si tiene cualquier valor diferente de true, regresa false
 * @param match 
 * @param param 
 */
export function readBooleanRouteParam(
    match: match,
    paramName: string
) : boolean | null {
    const paramValue: any = readParam(match, paramName);

    return paramValue === "true";
}

/**
 * Obtiene la ruta actual
 */
export function getCurrentLocationPathName(location: Location) : string {
    return location.pathname;
}