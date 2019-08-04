import { UsuarioListable, UsuarioInsertable, UsuarioUpdatable, UsuarioConsultable } from "./../dtos/user";
import { PageResult } from "./../dtos/page-result";
import { TPromiseLike } from "../../helpers/promise-helper";

export interface UsuarioService {
    getPaginated: (pageNumberZeroBased: number, pageSize: number) => TPromiseLike<PageResult<UsuarioListable>>;
    getById: (id: number) => TPromiseLike<UsuarioConsultable>;
    insert: (model: UsuarioInsertable) => TPromiseLike<void>;
    update: (model: UsuarioUpdatable) => TPromiseLike<void>;
    /**
     * Cambia el estatus del usuario
     */
    changeStatus: (id: number, active: boolean) => Promise<void>;
    delete: (id: number, justification: string, password: string) => TPromiseLike<void>;
}