// Dependencias Globales
import React from "react";

// Layouts
import { TopBar } from "./top-bar";
import { RountingRelationRepository, RoutingRelation } from "./routing-relation-repository";

// Genéricos
import { CredentialsHelper } from "../../helpers/credentials-helper";
import { Redirect, Route } from "react-router";

export const RedirectToLogin : React.FC = () =>
    <Redirect to="/login" />;

export const getCatalogRoutes = (userIsAuthenticated: boolean) => {
    return RountingRelationRepository.map((routingRelation, routingRelationIndex) => {
        return (
            <Route
                key={routingRelationIndex}
                exact
                path={routingRelation.path}
                render={props => userIsAuthenticated ? 
                    (
                        <>
                            <TopBar />
                            <routingRelation.component {...props} />
                        </>
                    ) : <RedirectToLogin />
                }
            />
        );
    });
};
