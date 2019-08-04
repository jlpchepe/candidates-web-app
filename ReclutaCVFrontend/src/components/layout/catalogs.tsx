// Dependencias Globales
import React from "react";

// Layouts
import { TopBar } from "./top-bar";
import { RountingRelationRepository, RoutingRelation } from "./routing-relation-repository";

// Genéricos
import { Route } from "../generic";

const getRoutesWithPath = (routes : RoutingRelation[]) => {
    return routes.map((routingRelation, routingRelationIndex) => {
        if (routingRelation.submenu) {
            return getRoutesWithPath(routingRelation.submenu);
        }
        return (
            <Route
                key={routingRelationIndex}
                path={routingRelation.path}
                component={props => <routingRelation.component {...props} />}
            />
        );
    });
};

/**
 * Esta plantilla se utiliza para los catálogos
 */
export const Catalogs = props => (
    <>
        <TopBar />
        {getRoutesWithPath(RountingRelationRepository)}
    </>
);