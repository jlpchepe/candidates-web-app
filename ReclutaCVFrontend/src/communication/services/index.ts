import { RemoteOperatorService, RemoteAuthenticationService, RemoteAdvisorService, RemoteHolidayService, RemoteAbsentService, RemoteEventLogService, RemoteConfigurationService, RemoteWorkOrderService, RemoteWorkOrderActivityService, RemoteWorkshopService } from "./remote-api-services/index";
import { AuthenticationService } from "./authentication-service";
import { RemoteWorkStationService, RemoteActivityService, RemoteUserService, RemoteActivityKitService } from "./remote-api-services";
import { WorkstationService } from "./workstation-service";
import { UserService } from "./user-service";
import { OperatorService } from "./operator-service";
import { ActivityService } from "./activity";
import { InMemoryActivityKitService, InMemoryActivityService, InMemoryOperatorService, InMemoryUserService, InMemoryWorkstationService, InMemoryAuthenticationService, InMemoryWorkOrderService, InMemoryNotificationService, InMemoryAdvisorService, InMemoryEventLogService, InMemoryAbsentService } from "./in-memory-services";
import { Config, ApiServiceMode } from "./../../config";
import { ActivityKitService as ActivityKitService } from "./activity-kit-service";
import { WorkOrderService } from "./work-order-service";
import { NotificationService } from "./notification-service";
import { AdvisorService } from "./advisor-service";
import { HolidayService } from "./holiday-service";
import { AbsentService } from "./absent-service";
import { EventLogService } from "./event-log-service";
import { ConfigurationService } from "./configuration-service";
import { RemoteNotificationService } from "./remote-api-services/remote-notification-service";
import { WorkOrderActivityService } from "./work-order-activity-service";
import { InMemoryHolidayService } from "./in-memory-services/holiday-service";
import { WorkshopService } from "./workshop-service";
import { SystemEventsWebSocket } from "./system-events-web-socket";
import { RemoteSystemEventsWebSocket } from "./remote-api-services/remote-system-events-web-socket";
import { InMemorySystemEventsWebSocket } from "./in-memory-services/in-memory-system-events-web-socket";

/**
 * Los servicios contenidos en este archivo son los que utilizarán los componentes del proyecto para comunicarse con servicios de REST API
 * Está diseñado de tal forma que sea posible devolver estos servicios como mocks en memoria o bien como auténticos servicios que se conectan a la API remota
 * La propósito de este diseño es permitir que el frontend pueda ser probado sin necesidad de levantar el backend y todos los servicios que lo soportan
 */

/**
 * Devuelve el servicio en memoria o remoto en función de lo contenido en el archivo de configuración
 * @param remoteService 
 * @param inMemoryService Puede ser null, en caso de que no haya implementación en memoria del servicio
 */
const RemoteOrInMemoryBasedOnConfig = <TService>(inMemoryService: TService, remoteService?: TService) =>
    remoteService == null ? 
        inMemoryService :
        inMemoryService == null ? 
            remoteService :
            Config.preferredApiMode() == ApiServiceMode.InMemory ?
                inMemoryService : 
                remoteService;

export const Activity: ActivityService = RemoteOrInMemoryBasedOnConfig(InMemoryActivityService, RemoteActivityService);
export const ActivityKit: ActivityKitService = RemoteOrInMemoryBasedOnConfig(InMemoryActivityKitService, RemoteActivityKitService);
export const Operator: OperatorService = RemoteOrInMemoryBasedOnConfig(InMemoryOperatorService, RemoteOperatorService);
export const User: UserService = RemoteOrInMemoryBasedOnConfig(InMemoryUserService, RemoteUserService);
export const Configuration: ConfigurationService = RemoteConfigurationService;
export const Workstation: WorkstationService = RemoteOrInMemoryBasedOnConfig(InMemoryWorkstationService, RemoteWorkStationService);
export const Notification: NotificationService = RemoteOrInMemoryBasedOnConfig(InMemoryNotificationService, RemoteNotificationService);
export const Authentication: AuthenticationService = RemoteOrInMemoryBasedOnConfig(InMemoryAuthenticationService, RemoteAuthenticationService);
export const WorkOrder: WorkOrderService = RemoteOrInMemoryBasedOnConfig(InMemoryWorkOrderService, RemoteWorkOrderService);
export const WorkOrderActivity: WorkOrderActivityService = RemoteOrInMemoryBasedOnConfig(null, RemoteWorkOrderActivityService);
export const Advisor: AdvisorService = RemoteOrInMemoryBasedOnConfig(InMemoryAdvisorService, RemoteAdvisorService);
export const Holiday: HolidayService = RemoteOrInMemoryBasedOnConfig(InMemoryHolidayService, RemoteHolidayService);
export const Workshop: WorkshopService = RemoteOrInMemoryBasedOnConfig(RemoteWorkshopService);
export const Absent: AbsentService = RemoteOrInMemoryBasedOnConfig(InMemoryAbsentService, RemoteAbsentService);
export const EventLog: EventLogService = RemoteOrInMemoryBasedOnConfig(InMemoryEventLogService, RemoteEventLogService);
export const SystemEvents: SystemEventsWebSocket = RemoteOrInMemoryBasedOnConfig(InMemorySystemEventsWebSocket, RemoteSystemEventsWebSocket); 