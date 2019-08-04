import { CreateCrudRestApiService } from "./generic-rest-api-service";
import { AuthenticationService } from "../authentication-service";
import { RestApiCommunication } from "./rest-api-communication-service";
import { UsuarioService } from "../user-service";
import { UsuarioInsertable, UsuarioUpdatable, UsuarioConsultable, UsuarioListable } from "../../dtos/user";
import { CandidatoService } from "../candidato-service";


export const RemoteCandidatoService: CandidatoService = CreateCrudRestApiService("candidato")

export const RemoteUsuarioService: UsuarioService = {
    ...CreateCrudRestApiService<UsuarioListable, UsuarioConsultable, UsuarioInsertable, UsuarioUpdatable, void>("user"),
    changeStatus: (id, active) => RestApiCommunication.put("user/status", { id, active }),
};

export const RemoteAuthenticationService: AuthenticationService = {
    authenticateUsuario: (username: string, password: string) =>
        RestApiCommunication.post("auth", { username, password }, true)
};