import { TObservableLike } from "./../../helpers/observable-helper";
import { UserListable, UserInsertable, UserUpdatable, UserConsultable } from "./../dtos/user";
import { PageResult } from "./../dtos/page-result";
import { TPromiseLike } from "../../helpers/promise-helper";

export interface UserService {
    getPaginated: (pageNumberZeroBased: number, pageSize: number) => TPromiseLike<PageResult<UserListable>>;
    getById: (id: number) => TObservableLike<UserConsultable>;
    insert: (model: UserInsertable) => TObservableLike<void>;
    update: (model: UserUpdatable) => TObservableLike<void>;
    /**
     * Cambia el estatus del usuario
     */
    changeStatus: (id: number, active: boolean) => Promise<void>;
    delete: (id: number, justification: string, password: string) => TObservableLike<void>;
}