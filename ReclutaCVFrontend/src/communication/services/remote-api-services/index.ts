import { CreateCrudRestApiService } from "./generic-rest-api-service";
import { AuthenticationService } from "../authentication-service";
import { RestApiCommunication } from "./rest-api-communication-service";
import { UsuarioService } from "../user-service";
import { UsuarioInsertable, UsuarioUpdatable, UsuarioConsultable, UsuarioListable } from "../../dtos/user";
import { CandidatoService } from "../candidato-service";

const candidatoBaseEndpoint = "candidato";
const RemoteCandidatoPreService: CandidatoService = CreateCrudRestApiService(candidatoBaseEndpoint);
export const RemoteCandidatoService: CandidatoService = {
    ...RemoteCandidatoPreService,
    getPaginated: (pageNumberZeroBased: number, pageSize: number, nombre: string) =>
            RestApiCommunication.get(candidatoBaseEndpoint, { pageNumber: pageNumberZeroBased, pageSize, nombre }),
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