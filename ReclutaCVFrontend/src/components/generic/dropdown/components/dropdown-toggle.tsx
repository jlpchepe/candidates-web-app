import React from "react";

interface DropdownToggleProps {
    icon?: React.ReactNode;
    label?: string;
    onClick: () => void;
}

export const DropdownToggle: React.FC<DropdownToggleProps> = props => (
    <button className="dropdown__toggle" onClick={props.onClick}>
        {props.label && <span>{props.label}</span>}
        {props.icon}
    </button>
);