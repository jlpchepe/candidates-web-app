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
    getAll: () => Promise<TSelectableResponse[]>,
    insert: (model: TInsertableRequest) => Promise<TInsertableResponse>,
    update: (model: TUpdatableRequest) => Promise<TUpdatableResponse>
}

export function CreateCrudRestApiService<TListable, TConsultable = TListable, TInsertable = TConsultable, TUpdatable = TConsultable, TSelectable = TConsultable>
(baseEndpoint: string) : CrudRestApiService<TListable, TConsultable, TSelectable, TInsertable, TUpdatable> {
    return {
        getPaginated: (pageNumberZeroBased: number, pageSize: number) =>
            RestApiCommunication.get(baseEndpoint, { pageNumber: pageNumberZeroBased, pageSize }),
        getById: (id) =>
            RestApiCommunication.get(baseEndpoint + "/" + id),
        getAll: () =>
            RestApiCommunication.get(baseEndpoint + "/all"),
        insert: (workstation) =>
            RestApiCommunication.post(baseEndpoint, workstation),
        update: (workstation) =>
            RestApiCommunication.put(baseEndpoint, workstation)
    };
}