import { HolidayListable, HolidayConsultable, HolidayUpdatable } from "./../../dtos/holiday";
import { WorkstationListable, WorkstationConsultable, WorkstationInsertable, WorkstationUpdatable } from "./../../dtos/workstation";
import { OperatorConsultable, OperatorInsertable, OperatorUpdatable, OperatorSelectable } from "./../../dtos/operator";
import { ActivityService } from "./../activity";
import { WorkstationService } from "./../workstation-service";
import { CreateCrudRestApiService } from "./generic-rest-api-service";
import { OperatorService } from "../operator-service";
import { AuthenticationService } from "../authentication-service";
import { RestApiCommunication } from "./rest-api-communication-service";
import { UserService } from "../user-service";
import { ActivityKitService } from "../activity-kit-service";
export { RemoteWorkOrderService } from "./remote-work-order-service";
import { UserInsertable, UserUpdatable, UserConsultable, UserListable } from "../../dtos/user";
import { OperatorListable } from "../../dtos/operator";
import { AdvisorService } from "../advisor-service";
import { ActivityListable, ActivityConsultable, ActivityInsertable, ActivityUpdatable, ActivitySelectable } from "../../dtos/activity";
import { ActivityKitConsultable, ActivityKitListable, ActivityKitInsertable, ActivityKitUpdatable } from "../../dtos/activity-kit";
import { HolidayService } from "../holiday-service";
import { AbsentService } from "../absent-service";
import { HolidayInsertable } from "../../dtos/holiday";
import { EventLogService } from "../event-log-service";
import { ConfigurationUpdatable, ConfigurationSystemThemeConsultable, ConfigurationServiceBoardConsultable } from "../../dtos/configuration";
import { ConfigurationService } from "../configuration-service";
import { WorkOrderActivityService } from "../work-order-activity-service";
import { WorkshopService } from "../workshop-service";
import { WorkshopCapacity } from "../../dtos/workshop";
import { PageResult } from "../../dtos/page-result";
import { Month } from "../../enums/months";

/**
 * Servicios API que funciona con la comunicación por medio de una arquitectura REST a un servidor
 */
export const RemoteWorkStationService: WorkstationService = {
    ...CreateCrudRestApiService<WorkstationListable, WorkstationConsultable, WorkstationInsertable, WorkstationUpdatable>("workstation"),
    getAll: (includedId?: number) => RestApiCommunication.get("workstation/all", { includedId }),
    changeStatus: (id, active) => RestApiCommunication.put("workstation/status", { id, active }),
    delete: (id: number, justification: string, password: string) => RestApiCommunication.delete("workstation/" + id, { justification, password })
};

export const RemoteActivityKitService: ActivityKitService = {
    ...CreateCrudRestApiService<ActivityKitListable, ActivityKitConsultable, ActivityKitInsertable, ActivityKitUpdatable>("activityKit"),
    changeStatus: (id, active) => RestApiCommunication.put("activityKit/status", { id, active }),
    delete: (id: number, justification: string, password: string) => RestApiCommunication.delete("activityKit/" + id, { justification, password })
};

export const RemoteActivityService: ActivityService = {
    ...CreateCrudRestApiService<ActivityListable, ActivityConsultable, ActivityInsertable, ActivityUpdatable, ActivitySelectable>("activity"),
    changeStatus: (id, active) => RestApiCommunication.put("activity/status", { id, active }),
    delete: (id: number, justification: string, password: string) => RestApiCommunication.delete("activity/" + id, { justification, password })
};


export const RemoteWorkshopService: WorkshopService = {
    getCapacity: (date: Date) => RestApiCommunication.get<WorkshopCapacity>("workshop/capacity", { date })
};
const configurationBaseEndpoint = "configuration";
export const RemoteConfigurationService: ConfigurationService = {
    getConfiguration: () => RestApiCommunication.get(configurationBaseEndpoint),
    getSystemThemeConfiguration: () => RestApiCommunication.get<ConfigurationSystemThemeConsultable>(configurationBaseEndpoint + "/systemtheme"),
    getServiceBoardConfiguration: () => RestApiCommunication.get<ConfigurationServiceBoardConsultable>(configurationBaseEndpoint + "/workboard"),
    update: (model: ConfigurationUpdatable) => RestApiCommunication.put(configurationBaseEndpoint, model)
};

export const RemoteAdvisorService: AdvisorService = {
    ...CreateCrudRestApiService("advisor"),
    changeStatus: (id, active) => RestApiCommunication.put<void>("advisor/status", { id, active }),
    delete: (id: number, justification: string, password: string) => RestApiCommunication.delete("advisor/" + id, { justification, password })
};

const holidayBaseEndpoint = "holiday";
export const RemoteHolidayService: HolidayService = {
    ...CreateCrudRestApiService<HolidayListable, HolidayConsultable>(holidayBaseEndpoint),
    getPaginated: (pageNumber: number, pageSize: number, month: Month) =>
        RestApiCommunication.get<PageResult<HolidayListable>>(holidayBaseEndpoint, {
            pageNumber,
            pageSize,
            month
        }),
    insertAll: (model: HolidayUpdatable[]) => RestApiCommunication.post("holiday/load", model),
    delete: (id: number, justification: string, password: string) => RestApiCommunication.delete("holiday/" + id, { justification, password })
};

export const RemoteAbsentService: AbsentService = {
    ...CreateCrudRestApiService("absent"),
    delete: (id: number, justification: string, password: string) => RestApiCommunication.delete("absent/" + id, { justification, password })
};

export const RemoteEventLogService: EventLogService = {
    getPaginated: (pageNumberZeroBased: number, pageSize: number, startDate: Date, endDate: Date) =>
        RestApiCommunication.get("eventLog", { pageNumber: pageNumberZeroBased, pageSize, startDate, endDate })
};

export const RemoteUserService: UserService = {
    ...CreateCrudRestApiService<UserListable, UserConsultable, UserInsertable, UserUpdatable, void>("user"),
    changeStatus: (id, active) => RestApiCommunication.put("user/status", { id, active }),
    delete: (id: number, justification: string, password: string) => RestApiCommunication.delete("user/" + id, { justification, password })
};

export const RemoteOperatorService: OperatorService = {
    ...CreateCrudRestApiService<OperatorListable, OperatorConsultable, OperatorInsertable, OperatorUpdatable, OperatorSelectable>("operator"),
    changeStatus: (id, active) => RestApiCommunication.put("operator/status", { id, active }),
    delete: (id: number, justification: string, password: string) => RestApiCommunication.delete("operator/" + id, { justification, password })
};

export const RemoteAuthenticationService: AuthenticationService = {
    authenticateUser: (username: string, password: string) =>
        RestApiCommunication.post("auth", { username, password }, true)
};

const workOrderActivityBaseEndpoint = "workOrderActivity";
export const RemoteWorkOrderActivityService: WorkOrderActivityService = {
    addActivity: (workOrderId: number, activityId: number) =>
        RestApiCommunication.post(workOrderActivityBaseEndpoint, { workOrderId, activityId }),
    addActivityKit: (workOrderId: number, activityKitId: number) =>
        RestApiCommunication.post(workOrderActivityBaseEndpoint + "/kit", { workOrderId, activityKitId }),
    assignOperatorAndWorkstationToActivity: (workOrderActivityId: number, operatorId: number, workstationId: number) =>
        RestApiCommunication.put(workOrderActivityBaseEndpoint + "/operator", { workOrderActivityId, operatorId, workstationId }),
    startActivity: (workOrderActivityId: number, startTime: Date) =>
        RestApiCommunication.put(workOrderActivityBaseEndpoint + "/start", { workOrderActivityId, startTime }),
    endActivity: (workOrderActivityId: number, endTime: Date) =>
        RestApiCommunication.put(workOrderActivityBaseEndpoint + "/end", { workOrderActivityId, endTime }),
    pauseActivity: (workOrderActivityId: number, pauseTime: Date, justification: string, password: string) =>
        RestApiCommunication.put(workOrderActivityBaseEndpoint + "/pause", { workOrderActivityId, pauseTime, justification, password }),
    stopActivity: (workOrderActivityId: number, stopDate: Date, justification: string, password: string) =>
        RestApiCommunication.put(workOrderActivityBaseEndpoint + "/stop", { workOrderActivityId, stopDate, justification, password }),
    delete: (workOrderActivityId: number) =>
        RestApiCommunication.delete(workOrderActivityBaseEndpoint + "/" + workOrderActivityId),
    changeEstimatedTime: (workOrderActivityId: number, estimatedTime: number) =>
        RestApiCommunication.put(workOrderActivityBaseEndpoint + "/time", { workOrderActivityId, estimatedTime }),
    changeOrder: (workOrderActivityId: number, newOrder: number) =>
        RestApiCommunication.put(workOrderActivityBaseEndpoint + "/order", { workOrderActivityId, newOrder }),
};