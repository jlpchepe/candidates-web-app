import dotenv from "dotenv";
dotenv.config();

/**
 * Modos del ApiService
 */
export enum ApiServiceMode {
    InMemory,
    Remote
}

/**
 * Configuraciones generales de la aplicación
 */
export class Config {
    /**
     * Determina el modo en el cual serán inyectados los servicios a los componentes de la aplicación
     * Variable de entorno, En memoria (para probar el sitio sin necesidad de backend) o remoto (conectarse con backend)
     */
    static readonly preferredApiMode = () =>
        process.env.API_MODE == "0" ? ApiServiceMode.InMemory : ApiServiceMode.Remote;
    /**
     * URL base utilizada para conectarse con el backend
     * Esta URL se colocará como prefijo a las peticiones que se hagan al backend
     * Y puerto sobre el cual está montado el backend de la aplicación
     */
    static readonly getAdminBackendBaseUrl = () => process.env.BASE_URL || "http://localhost:5001";
}
