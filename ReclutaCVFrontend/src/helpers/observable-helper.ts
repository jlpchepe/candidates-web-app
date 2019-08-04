import { Observable, from, of } from "rxjs";


/**
 * Una función que regresa una promesa o que regresa directamente un valor
 */
export type TPromiseLike<TValue> = Observable<TValue> | Promise<TValue> | TValue;

/**
 * Convierte el objeto indicado a un Observable
 * @param observableValue 
 */
export function toPromise<TResult>(
    observableValue: TPromiseLike<TResult>
) : Observable<TResult> {

    if(observableValue instanceof Observable){
        return observableValue;
    }

    if(observableValue instanceof Promise){
        return from(observableValue);
    }

    return of(observableValue);
}