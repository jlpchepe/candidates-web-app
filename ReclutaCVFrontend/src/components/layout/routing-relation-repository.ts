import * as React from "react";
import { UsuarioEdit } from "./../domain/catalogs/users/edit/user-edit";
import { UsuarioList } from "./../domain/catalogs/users/list/user-list";
import { RouteComponentProps } from "react-router-dom";
import { CandidatoList } from "../domain/catalogs/candidato/list/candidato-list";
import { CandidatoEdit } from "../domain/catalogs/candidato/edit/candidato-edit";

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
        component: CandidatoList,
        path: "/candidato",
        label: "Candidatos"
    },
    {
        component: UsuarioList,
        path: "/user",
        label: "Usuarios"
    },
    {
        component: CandidatoEdit,
        path: "/candidato/:id/:readonly?"
    },
    {
        component: UsuarioEdit,
        path: "/usuario/:id/:readonly?"
    }
];
