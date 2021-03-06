import { SolicitudVacanteConsultable, SolicitudVacanteInsertable, SolicitudVacanteUpdatable, SolicitudVacanteListable } from "../dtos/solicitud-vacante";
import { PageResult } from "../dtos/page-result";
import { TPromiseLike } from "../../helpers/promise-helper";
import { RolCandidato } from "../enums/candidato";

export interface SolicitudVacanteService {
    getPaginated: (pageNumberZeroBased: number, pageSize: number, busqueda?: string, puestoSolicitado?: RolCandidato) => TPromiseLike<PageResult<SolicitudVacanteListable>>;
    getById: (id: number) => TPromiseLike<SolicitudVacanteConsultable>;
    insert: (model: SolicitudVacanteInsertable) => TPromiseLike<number>;
    update: (model: SolicitudVacanteUpdatable) => TPromiseLike<void>;
    delete: (id: number) => TPromiseLike<void>;
    downloadXlsReport: (busqueda?: string, puestoSolicitado?: RolCandidato) => TPromiseLike<void>;
}