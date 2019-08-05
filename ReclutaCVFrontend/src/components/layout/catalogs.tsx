// Dependencias Globales
import React from "react";

// Layouts
import { TopBar } from "./top-bar";
import { RountingRelationRepository, RoutingRelation } from "./routing-relation-repository";

// Genéricos
import { Route } from "../generic";
import { CredentialsHelper } from "../../helpers/credentials-helper";
import { Redirect } from "react-router";

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
export const Catalogs = props => 
(
    CredentialsHelper.isAuthenticated() ?
        <>
            <TopBar />
            {getRoutesWithPath(RountingRelationRepository)}
        </> :
        <Redirect to="/" />
);
