import { CreateCrudRestApiService } from "./generic-rest-api-service";
import { AuthenticationService } from "../authentication-service";
import { RestApiCommunication } from "./rest-api-communication-service";
import { UsuarioService } from "../user-service";
import { UsuarioInsertable, UsuarioUpdatable, UsuarioConsultable, UsuarioListable } from "../../dtos/user";
import { CandidatoService } from "../candidato-service";
import { SolicitudVacanteService } from "../solicitud-vacante-service";
import { RolCandidato } from "../../enums/candidato";

const candidatoBaseEndpoint = "candidato";
export const RemoteCandidatoService: CandidatoService = {
    ...CreateCrudRestApiService(candidatoBaseEndpoint),
    getPaginated: (pageNumberZeroBased: number, pageSize: number, nombre: string) =>
        RestApiCommunication.get(candidatoBaseEndpoint, { pageNumber: pageNumberZeroBased, pageSize, nombre }),
    downloadXlsReport: (busqueda?: string) => 
        RestApiCommunication.get(candidatoBaseEndpoint + "/report", { busqueda })
};

const usuarioBaseEndpoint = "usuario";
export const RemoteUsuarioService: UsuarioService = {
    ...CreateCrudRestApiService<UsuarioListable, UsuarioConsultable, UsuarioInsertable, UsuarioUpdatable, void>(usuarioBaseEndpoint),
    changeStatus: (id, active) => RestApiCommunication.put(usuarioBaseEndpoint + "/status", { id, active }),
};

export const RemoteAuthenticationService: AuthenticationService = {
    authenticateUsuario: (username: string, password: string) =>
        RestApiCommunication.post("auth", { username, password }, true)
};

const solicitudVacanteBaseEndpoint = "solicitudVacante";
export const RemoteSolicitudVacanteService: SolicitudVacanteService = {
    ...CreateCrudRestApiService(solicitudVacanteBaseEndpoint),
    getPaginated: (pageNumberZeroBased: number, pageSize: number, busqueda?: string, puestoSolicitado?: RolCandidato) =>
        RestApiCommunication.get(solicitudVacanteBaseEndpoint, { pageNumber: pageNumberZeroBased, pageSize, busqueda, puestoSolicitado }),
    downloadXlsReport: (busqueda?: string, puestoSolicitado?: RolCandidato) => 
        RestApiCommunication.get(candidatoBaseEndpoint + "/report", { busqueda, puestoSolicitado })
};