import { CreateCrudRestApiService } from "./generic-rest-api-service";
import { saveAs } from "file-saver";
import { AuthenticationService } from "../authentication-service";
import { RestApiCommunication } from "./rest-api-communication-service";
import { UsuarioService } from "../user-service";
import { UsuarioInsertable, UsuarioUpdatable, UsuarioConsultable, UsuarioListable } from "../../dtos/user";
import { CandidatoService } from "../candidato-service";
import { SolicitudVacanteService } from "../solicitud-vacante-service";
import { RolCandidato } from "../../enums/candidato";

const candidatoBaseEndpoint = "candidato";
const RemoteCandidatoPreService: Partial<CandidatoService> = CreateCrudRestApiService(candidatoBaseEndpoint);
export const RemoteCandidatoService: CandidatoService = {
    ...RemoteCandidatoPreService,
    getPaginated: (pageNumberZeroBased: number, pageSize: number, nombre: string) =>
        RestApiCommunication.get(candidatoBaseEndpoint, { pageNumber: pageNumberZeroBased, pageSize, nombre }),
    generateXlsReport: (busqueda?: string) => 
        RestApiCommunication.get(candidatoBaseEndpoint + "/report", { busqueda }),
    uploadCurriculum: (candidatoId: number, file: File) => {
        const formData = new FormData();
        formData.append("file", file);

        return RestApiCommunication.put(candidatoBaseEndpoint + "/curriculum/" + candidatoId, formData, false);
    },
    downloadCurriculum: (candidatoId: number) =>
        RestApiCommunication.get(candidatoBaseEndpoint + "/curriculum/" + candidatoId, {}, true)
            .then((response: {file: Blob, fileName: string}) => {
                saveAs(response.file, response.fileName);
            })
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
export const RemoteSolicitudVacantePreService: SolicitudVacanteService = CreateCrudRestApiService(solicitudVacanteBaseEndpoint);
export const RemoteSolicitudVacanteService: SolicitudVacanteService = {
    ...RemoteSolicitudVacantePreService,
    getPaginated: (pageNumberZeroBased: number, pageSize: number, busqueda?: string, puestoSolicitado?: RolCandidato) =>
        RestApiCommunication.get(solicitudVacanteBaseEndpoint, { pageNumber: pageNumberZeroBased, pageSize, busqueda, puestoSolicitado })
};