// Dependencias Globales
import React from "react";
import { withRouter, RouteComponentProps } from "react-router";
import { Dropdown, DropdownToggle, DropdownMenu } from "reactstrap";

// Layout
import { RountingRelationRepository } from "./routing-relation-repository";

// Componentes
import { Link } from "../generic";

interface NavBarProps extends RouteComponentProps {
    activeWindow: string;
    onClickActionButton: () => void;
}

const getRoutesWithPath = (routes, props) => {
    const currentLocation = props.location.pathname;
    return routes
        .filter(route => route.label)
        .map(routingRelation => {
            if (routingRelation.submenu) {
                return (
                    <Dropdown
                        key={routingRelation.path}
                        isOpen={props.activeWindow == "catalogsDropdown"}
                        toggle={props.onClickActionButton}
                    >
                        <DropdownToggle
                            tag="li"
                            className={`nav-bar__item${
                                routingRelation.submenu.find(submenu => submenu.path === currentLocation)
                                    ? " nav-bar__item--active"
                                    : ""
                            }`}
                            caret
                        >
                            {routingRelation.label}
                        </DropdownToggle>
                        <DropdownMenu>
                            {routingRelation.submenu.map(submenu => (
                                <Link key={submenu.path} to={submenu.path} onClick={props.onClickActionButton}>
                                    {submenu.label}
                                </Link>
                            ))}
                        </DropdownMenu>
                    </Dropdown>
                );
            }
            return (
                <Link key={routingRelation.path} to={routingRelation.path}>
                    {routingRelation.label}
                </Link>
            );
        });
};

/**
 * Barra de navegación para la aplicación
 */
const NavBar: React.FC<NavBarProps> = props => {
    return <ul className="nav-bar">{getRoutesWithPath(RountingRelationRepository, props)}</ul>;
};

export default withRouter(NavBar);
