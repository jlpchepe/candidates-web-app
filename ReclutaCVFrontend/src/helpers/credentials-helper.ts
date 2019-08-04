import jwt from "jsonwebtoken";
import { CookieHelper } from "./cookie-helper";
import { DateHelper } from "./date-helper";
import { Subscription, Subject } from "rxjs";

/**
 * Información del usuario autenticado en el sistema
 */
export interface AuthenticatedUserInfo {
    userName: string;
    userRole: string;
}

const tokenCookieName = "token";
const logoutObservable = new Subject<void>();
const logInObservable = new Subject<void>();

/**
 * Métodos de ayuda para administrar las credenciales del usuario autenticado
 */
export class CredentialsHelper {
    /**
     * Establece el token de sesión
     * @param bearerToken 
     */
    public static setSessionToken(
        bearerToken: string
    ) : void {
        const millisecondsInOneDay = 24 * 60 * 60 * 1000;

        const expiresDate = new Date(DateHelper.now().getTime() + millisecondsInOneDay);

        CookieHelper.setCookie(
            tokenCookieName,
            bearerToken,
            expiresDate
        );

        logInObservable.next();
    }

    /**
     * Elimina el token de sesión
     */
    public static deleteSessionToken() : void {
        CookieHelper.setCookie(
            tokenCookieName,
            null,
            null
        );

        // Se notifica que el usuario salio del sistema
        logoutObservable.next();
    }

    /**
     * Evento que se disparará cuando el usuario haga logout
     * @param action Acción a ejecutar
     */
    public static onLogout(action: () => void) : Subscription {
        return logoutObservable.subscribe(action);
    }

    /**
     * Evento que se disparará cuando el usuario haga login
     * @param action Acción a ejecutar
     */
    public static onLogin(action: () => void) : Subscription {
        return logInObservable.subscribe(action);
    }

    public static isAuthenticated = () : boolean => {
        return CredentialsHelper.getAuthBearerToken() != null;
    }

    /**
     * Obtiene el token con las credenciales del usuario actualmente autenticado, si no hay usuario autenticado se regresa null
     */
    public static getAuthBearerToken = () => 
        CookieHelper.getCookie(tokenCookieName);

    /**
     * Lee el token y lo decodifica para obtener el usuario y rol.
     * Si el token no está en las cookies, regresa null
     */
    public static getRoleAndUserFromTokenInCookie() {
        const decodedToken = jwt.decode(CredentialsHelper.getAuthBearerToken());

        if(decodedToken == null){
            return null;
        }

        const authenticatedUserInfo: AuthenticatedUserInfo = { 
            userRole: decodedToken.role, 
            userName: decodedToken.unique_name 
        };
            
        return authenticatedUserInfo;
    }
}