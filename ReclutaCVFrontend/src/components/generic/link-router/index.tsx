import React from "react";
import { NavLink } from "react-router-dom";
import classNames from "classnames";

interface LinkProps {
    to: string;
    onClick?: () => void;
}

export const Link: React.FC<LinkProps> = props => (
    <NavLink
        activeClassName="nav-bar__item--active"
        className="nav-bar__item"
        to={props.to || "#"}
        onClick={props.onClick}
    >
        {props.children}
    </NavLink>
);
