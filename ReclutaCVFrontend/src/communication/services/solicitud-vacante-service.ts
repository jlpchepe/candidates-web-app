import { SolicitudVacanteConsultable, SolicitudVacanteInsertable, SolicitudVacanteUpdatable, SolicitudVacanteListable } from "../dtos/solicitud-vacante";
import { PageResult } from "../dtos/page-result";
import { TPromiseLike } from "../../helpers/promise-helper";

export interface SolicitudVacanteService {
    getPaginated: (pageNumberZeroBased: number, pageSize: number, folio?: number) => TPromiseLike<PageResult<SolicitudVacanteListable>>;
    getById: (id: number) => TPromiseLike<SolicitudVacanteConsultable>;
    insert: (model: SolicitudVacanteInsertable) => TPromiseLike<number>;
    update: (model: SolicitudVacanteUpdatable) => TPromiseLike<void>;
    delete: (id: number) => TPromiseLike<void>;
}