/**
 * Métodos de ayuda para trabajar con cookies
 */
export class CookieHelper {
    /**
    * Guarda el token una vez que se acompleta la petición
    * @param {string} cookieName
    * @param {string} cookieValue
    * @param {Date | null} expiresDate Fecha en la que expirará
    */
    public static setCookie(
        cookieName: string, 
        cookieValue: string | null,
        expiresDate: Date | null
    ) {
        const cookieExpires = "expires=" + (
            expiresDate != null ? 
                expiresDate.toUTCString() : 
                "Thu, 01 Jan 1970 00:00:00 UTC"
        );

        const fixedCookieValue = cookieValue != null ?
            cookieValue :
            "";

        document.cookie = cookieName + "=" + fixedCookieValue + ";" + cookieExpires + ";path=/";
    }

    /**
    * Lee la cookie con el nombre indicado
    * Si no encuentra la cookie, regresa null
    * @param {string} cookieName
    */
    public static getCookie(cookieName: string) : string | null {
        const name = cookieName + "=";
        const decodedCookie = decodeURIComponent(document.cookie);
        const ca = decodedCookie.split(";");

        for (let i = 0; i < ca.length; i++) {
            let c = ca[i];
            while (c.charAt(0) == " ") {
                c = c.substring(1);
            }
            if (c.indexOf(name) == 0) {
                return c.substring(name.length, c.length);
            }
        }

        return null;
    }
}