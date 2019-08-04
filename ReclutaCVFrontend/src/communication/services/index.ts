import { AuthenticationService } from "./authentication-service";
import { UsuarioService } from "./user-service";
import { Config, ApiServiceMode } from "./../../config";
import { CandidatoService } from "./candidato-service";
import { InMemoryUsuarioService, InMemoryAuthenticationService, InMemoryCandidatoService } from "./in-memory-services";
import { RemoteUsuarioService, RemoteAuthenticationService, RemoteCandidatoService } from "./remote-api-services";

/**
 * Los servicios contenidos en este archivo son los que utilizarán los componentes del proyecto para comunicarse con servicios de REST API
 * Está diseñado de tal forma que sea posible devolver estos servicios como mocks en memoria o bien como auténticos servicios que se conectan a la API remota
 * La propósito de este diseño es permitir que el frontend pueda ser probado sin necesidad de levantar el backend y todos los servicios que lo soportan
 */

/**
 * Devuelve el servicio en memoria o remoto en función de lo contenido en el archivo de configuración
 * @param remoteService 
 * @param inMemoryService Puede ser null, en caso de que no haya implementación en memoria del servicio
 */
const RemoteOrInMemoryBasedOnConfig = <TService>(inMemoryService: TService, remoteService?: TService) =>
    remoteService == null ? 
        inMemoryService :
        inMemoryService == null ? 
            remoteService :
            Config.preferredApiMode() == ApiServiceMode.InMemory ?
                inMemoryService : 
                remoteService;

export const Usuario: UsuarioService = RemoteOrInMemoryBasedOnConfig(InMemoryUsuarioService, RemoteUsuarioService);
export const Authentication: AuthenticationService = RemoteOrInMemoryBasedOnConfig(InMemoryAuthenticationService, RemoteAuthenticationService);
export const Candidato: CandidatoService = RemoteOrInMemoryBasedOnConfig(InMemoryCandidatoService, RemoteCandidatoService);