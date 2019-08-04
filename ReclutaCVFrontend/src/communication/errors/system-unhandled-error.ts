/**
 * Un error que no pudo ser manejado correctamente por el backend del sistema
 */
export interface SystemUnhandledError {
    IsSystemError: boolean;
    Message: string;
    ExceptionMessage: string;
    ExceptionStackTrace: string;
}