import { TPromiseLike } from "../../helpers/promise-helper";
import { PageResult } from "../dtos/page-result";
import { CandidatoConsultable, CandidatoInsertable, CandidatoUpdatable } from "../dtos/candidato";

export interface CandidatoService {
    getPaginated: (pageNumberZeroBased: number, pageSize: number, busqueda: string) => TPromiseLike<PageResult<CandidatoConsultable>>;
    getById: (id: number) => TPromiseLike<CandidatoConsultable>;
    insert: (model: CandidatoInsertable) => TPromiseLike<number>;
    update: (model: CandidatoUpdatable) => TPromiseLike<void>;
    delete: (id: number) => TPromiseLike<void>;
    downloadXlsReport: (busqueda?: string) => TPromiseLike<void>;
}