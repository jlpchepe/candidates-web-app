import { TPromiseLike } from "../../helpers/promise-helper";
import { PageResult } from "../dtos/page-result";
import { CandidatoConsultable, CandidatoInsertable, CandidatoUpdatable } from "../dtos/candidato";

export interface CandidatoService {
    getPaginated: (pageNumberZeroBased: number, pageSize: number) => TPromiseLike<PageResult<CandidatoConsultable>>;
    getById: (id: number) => TPromiseLike<CandidatoConsultable>;
    insert: (model: CandidatoInsertable) => TPromiseLike<void>;
    update: (model: CandidatoUpdatable) => TPromiseLike<void>;
    delete: (id: number, justification: string, password: string) => TPromiseLike<void>;
}