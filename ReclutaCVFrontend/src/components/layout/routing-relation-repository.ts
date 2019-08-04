import { ServiceBoard } from "../domain/operatives/service-board";
import { OperatorEdit } from "./../domain/catalogs/operator/edit/operator-edit";
import { WorkstationList } from "./../domain/catalogs/workstation/list/workstation-list";
import { WorkstationEdit } from "./../domain/catalogs/workstation/edit/workstation-edit";
import { UserEdit } from "./../domain/catalogs/users/edit/user-edit";
import { OperatorList } from "./../domain/catalogs/operator/list/operator-list";
import { ActivityEdit } from "./../domain/catalogs/activities/edit/activity-edit";
import { ActivityList } from "./../domain/catalogs/activities/list/activity-list";
import { UserList } from "./../domain/catalogs/users/list/user-list";
import { ActivityKitEdit } from "../domain/catalogs/activity-kit/edit/activity-kit-edit";
import { ActivityKitList } from "../domain/catalogs/activity-kit/list/activity-kit-list";
import { RouteComponentProps } from "react-router-dom";
import { ConfigurationEdit } from "./../domain/catalogs/config/configuration-edit";
import { AdvisorEdit } from "../domain/catalogs/advisors/edit/advisor-edit";
import { AdvisorList } from "../domain/catalogs/advisors/list/advisor-list";
import { HolidayEdit } from "../domain/catalogs/holidays/edit/holiday-edit";
import { HolidayList } from "../domain/catalogs/holidays/list/holiday-list";
import { AbsentList } from "../domain/catalogs/absents/list/absent-list";
import { AbsentEdit } from "../domain/catalogs/absents/edit/absent-edit";
import { EventLogList } from "../domain/catalogs/event-log/list/event-log-list";
import { NotificationTray } from "../domain/catalogs/notification-tray/notification-tray-list";
import { WorkOrderList } from "../domain/catalogs/work-order/list/work-order-list";
import { WorkOrderEdit } from "../domain/catalogs/work-order/edit/work-order-edit";

export type TRouteComponent = React.ComponentType<RouteComponentProps<any>> | React.ComponentType<any>;

/**
 * Relación de ruteo, termina relacionando el componente que se dibujará cuando una cierta ruta esté en el navegador
 */
export interface RoutingRelation {
    component: TRouteComponent;
    label?: string;
    submenu?: RoutingRelation[];
    /**
     * Ruta que se comparará contra la del navegador para determinar si el componente se muestra
     */
    path: string;
}

/**
 * Este repositorio en memoria usará el listado de relaciones de ruteo
 * Para mostrar en el cuerpo de la aplicación la ruta que se seleccione
 * Este repositorio termina relacionando a los componentes {@link Body} y {@link SideBar}
 */
export const RountingRelationRepository: RoutingRelation[] = [
    {
        component: ServiceBoard,
        path: "/service-board",
        label: "Tablero de servicios"
    },
    {
        component: null,
        label: "Catálogos",
        path: null,
        submenu: [
            {
                component: ActivityList,
                path: "/activity",
                label: "Actividades"
            },
            {
                component: WorkstationList,
                path: "/workstation",
                label: "Estaciones de trabajo"
            },
            {
                component: AdvisorList,
                path: "/advisor",
                label: "Asesores"
            },
            {
                component: OperatorList,
                path: "/operator",
                label: "Operadores"
            },
            {
                component: ActivityKitList,
                path: "/activity-kit",
                label: "Kits de Actividades"
            },
            {
                component: UserList,
                path: "/user",
                label: "Usuarios"
            },
            {
                component: HolidayList,
                path: "/holiday",
                label: "Días inhábiles"
            },
            {
                component: AbsentList,
                path: "/absent",
                label: "Ausencias"
            },
            {
                component: WorkOrderList,
                path: "/work-order",
                label: "Órdenes de trabajo"
            },
        ]
    },
    {
        component: EventLogList,
        path: "/event-log",
        label: "Bitácora"
    },
    {
        component: NotificationTray,
        path: "/notification-tray",
        label: "Bandeja de notificaciones"
    },
    {
        component: ActivityEdit,
        path: "/activity/:id/:readonly?"
    },
    {
        component: WorkstationEdit,
        path: "/workstation/:id/:readonly?"
    },
    {
        component: AdvisorEdit,
        path: "/advisor/:id/:readonly?"
    },
    {
        component: OperatorEdit,
        path: "/operator/:id/:readonly?"
    },
    {
        component: ActivityKitEdit,
        path: "/service-type/:id/:readonly?"
    },
    {
        component: ActivityKitEdit,
        path: "/activity-kit/:id/:readonly?"
    },
    {
        component: HolidayEdit,
        path: "/holiday/:id/:readonly?"
    },
    {
        component: AbsentEdit,
        path: "/absent/:id/:readonly?"
    },
    {
        component: UserEdit,
        path: "/user/:id/:readonly?"
    },
    {
        component: WorkOrderEdit,
        path: "/work-order/:id/:readonly?"
    },
    {
        component: ConfigurationEdit,
        path: "/config",
        label: "Configuración"
    }
];
