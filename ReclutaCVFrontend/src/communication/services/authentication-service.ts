export interface AuthenticationService {
    /**
     * Valida las credenciales del usuario, si el usuario es correcto regresa un JWT en base64, si es incorrecto regresa un error
     * @param username 
     * @param password 
     */
    authenticateUsuario(username: string, password: string) : Promise<string>;
}