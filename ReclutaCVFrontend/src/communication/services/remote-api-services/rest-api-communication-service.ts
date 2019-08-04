import { Config } from "../../../config";
import Axios, { AxiosPromise, AxiosRequestConfig } from "axios";
import { JsonHelper } from "../../../helpers/json-helper";
import { ServiceErrorsHandler } from "../../errors/service-errors-handler";
import { NotificationHelper } from "../../../helpers/notification-helper";
import { CredentialsHelper } from "../../../helpers/credentials-helper";

interface UrlParams {
    [param: string]: number | string | Date
}

/**
 * El principal motivo de esta clase es crear una capa de abstracción entre axios y la aplicación
 * Métodos de ayuda para la comunicación con el backend administrativo de la aplicación
 */
class RemoteApiCommunicationService {

    private getAbsoluteUrl = (relativeUrl: string) => {
        return Config.getAdminBackendBaseUrl() + "/" + relativeUrl;
    }

    /**
     * Configuración para mandar las peticiones
     * @param params 
     */
    private getAxiosRequestConfig(
        params?: any
    ) : AxiosRequestConfig {
        const bearerToken = CredentialsHelper.getAuthBearerToken();

        return {
            params,
            transformResponse: JsonHelper.parseAndRevive,
            headers: bearerToken ? 
                { Authorization: "Bearer " + bearerToken } : 
                undefined
        };
    }

    /**
     * Procesa una promesa de Axios
     * Si es exitoso, regresa la respuesta
     * Si es errónea, regresa el error que entregó el backend
     * @param axiosPromise 
     */
    private processAxiosPromise<TResult>(
        axiosPromise: AxiosPromise<TResult>,
        disableNotifyOnError?: boolean
    ) : Promise<TResult> {
        return axiosPromise
            .then(response => response.data)
            .catch(axiosError =>  { 
                if(axiosError.response == null){
                    NotificationHelper.notifyError(
                        "Error de conexión",
                        "No se puede establecer conexión con el servidor"
                    );

                    throw axiosError;
                    
                } else {
                    const errorData = <any>axiosError.response.data;
    
                    if(!disableNotifyOnError){
                        ServiceErrorsHandler.handleServiceError(errorData);
                    }
    
                    throw errorData;
                }
            })
        ;
    }

    public delete<TResult, TParams extends UrlParams = UrlParams>(
        relativeUrl: string,
        params?: TParams
    ) : Promise<TResult> {
        return this.processAxiosPromise(
            Axios.delete(
                this.getAbsoluteUrl(relativeUrl),
                this.getAxiosRequestConfig(params)
            )
        );
    }
    
    get<TResult, TParams extends UrlParams = UrlParams>(
        relativeUrl: string,
        params?: TParams
    ) : Promise<TResult> {
        return this.processAxiosPromise(
            Axios.get(
                this.getAbsoluteUrl(relativeUrl),
                this.getAxiosRequestConfig(params)
            )
        );
    }

    post<TResult, TPayload>(
        relativeUrl: string,
        payload: TPayload,
        disableNotifyOnError?: boolean
    ) : Promise<TResult> {
        return this.processAxiosPromise(
            Axios.post(
                this.getAbsoluteUrl(relativeUrl),
                payload,
                this.getAxiosRequestConfig()
            ),
            disableNotifyOnError
        );
    }

    put<TResult, TPayload = {}>(
        relativeUrl: string,
        payload: TPayload,
        disableNotifyOnError?: boolean
    ) : Promise<TResult> {
        return this.processAxiosPromise(
            Axios.put(
                this.getAbsoluteUrl(relativeUrl),
                payload,
                this.getAxiosRequestConfig()
            ),
            disableNotifyOnError
        );
    }
}

export const RestApiCommunication = new RemoteApiCommunicationService();