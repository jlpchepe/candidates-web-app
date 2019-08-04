import React from "react";

interface DropdownItemProps {
    children: React.ReactNode;
    onClick?: () => void;
    className?: string;
}

export const DropdownItem: React.FC<DropdownItemProps> = props => (
    <li className={props.className || "dropdown__item"} onClick={props.onClick}>
        {props.children}
    </li>
);