import { SystemUnhandledError } from "./system-unhandled-error";
import { ValidationErrorResponse } from "./validation-error";
import { NotificationHelper } from "../../helpers/notification-helper";

export class ServiceErrorsHandler {
    /**
     * Maneja un error arrojado tras la llamada de un servicio
     * @param error 
     */
    public static handleServiceError(error: SystemUnhandledError | ValidationErrorResponse | Error){
        const validationError = <ValidationErrorResponse>error;
        const systemError = <SystemUnhandledError>error;

        if(validationError.IsValidationError){
            NotificationHelper.notifyError(
                "Error de captura", 
                validationError.Message
            );
        } else if (systemError.IsSystemError){
            NotificationHelper.notifyError(
                "Error", 
                //TODO: Poner que este mensaje sea el de sistema
                //systemError.Message,
                "Datos capturados son inválidos"
            );
        } else {
            NotificationHelper.notifyError(
                "Error", 
                "Contacte con soporte"
            );
        }
    }
}