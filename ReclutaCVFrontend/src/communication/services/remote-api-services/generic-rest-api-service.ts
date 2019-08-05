import { PageResult } from "./../../dtos/page-result";
import { RestApiCommunication } from "./rest-api-communication-service";

export enum HttpMethod {
    GET,
    POST,
    PUT
}

export interface CrudRestApiService<
    TListable,
    TConsultable = TListable,
    TSelectableResponse = TConsultable,
    TInsertableRequest = TListable,
    TUpdatableRequest = TInsertableRequest,
    TInsertableResponse = void,
    TUpdatableResponse = void
> {
    getPaginated: (pageNumber: number, pageSize: number) => Promise<PageResult<TListable>>,
    getById: (id: number) => Promise<TConsultable>,
    insert: (model: TInsertableRequest) => Promise<TInsertableResponse>,
    update: (model: TUpdatableRequest) => Promise<TUpdatableResponse>
    delete: (id: number) => Promise<void>;
}

export function CreateCrudRestApiService<TListable, TConsultable = TListable, TInsertable = TConsultable, TUpdatable = TConsultable, TSelectable = TConsultable>
(baseEndpoint: string) : CrudRestApiService<TListable, TConsultable, TSelectable, TInsertable, TUpdatable, number> {
    return {
        getPaginated: (pageNumberZeroBased: number, pageSize: number) =>
            RestApiCommunication.get(baseEndpoint, { pageNumber: pageNumberZeroBased, pageSize }),
        getById: (id) =>
            RestApiCommunication.get(baseEndpoint + "/" + id),
        insert: (workstation) =>
            RestApiCommunication.post(baseEndpoint, workstation),
        update: (workstation) =>
            RestApiCommunication.put(baseEndpoint, workstation),
        delete: (id) => 
            RestApiCommunication.delete(baseEndpoint + "/" + id)
    };
}