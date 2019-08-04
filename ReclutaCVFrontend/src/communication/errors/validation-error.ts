/**
 * Un error debido a una validación de datos que se pasaron a backend
 */
export interface ValidationErrorResponse {
    IsValidationError: boolean;
    Message: string;
}