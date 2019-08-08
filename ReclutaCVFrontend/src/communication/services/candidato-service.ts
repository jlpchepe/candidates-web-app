import { TPromiseLike } from "../../helpers/promise-helper";
import { PageResult } from "../dtos/page-result";
import { CandidatoConsultable, CandidatoInsertable, CandidatoUpdatable } from "../dtos/candidato";

export interface CandidatoService {
    getPaginated: (pageNumberZeroBased: number, pageSize: number, nombre: string) => TPromiseLike<PageResult<CandidatoConsultable>>;
    getById: (id: number) => TPromiseLike<CandidatoConsultable>;
    insert: (model: CandidatoInsertable) => TPromiseLike<number>;
    update: (model: CandidatoUpdatable) => TPromiseLike<void>;
    delete: (id: number) => TPromiseLike<void>;
    generateXlsReport: (busqueda?: string) => TPromiseLike<string>;
    downloadCurriculum: (candidatoId: number) => TPromiseLike<void>;
    uploadCurriculum: (candidatoId: number, file: File) => TPromiseLike<void>;
}