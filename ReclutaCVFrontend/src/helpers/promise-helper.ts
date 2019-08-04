/**
 * Una función que regresa una promesa o que regresa directamente un valor
 */
export type TPromiseLike<TValue> = Promise<TValue> | TValue;

/**
 * Convierte el objeto indicado a un Observable
 * @param promiseLikeValue 
 */
export function toPromise<TResult>(
    promiseLikeValue: TPromiseLike<TResult>
) : Promise<TResult> {
    return Promise.resolve(promiseLikeValue);
}