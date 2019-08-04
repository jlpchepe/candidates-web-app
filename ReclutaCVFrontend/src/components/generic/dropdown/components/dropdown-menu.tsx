import React from "react";

interface DropdownMenuProps {
    children: React.ReactNode;
    renderAs?: string;
    style?: React.CSSProperties;
}

export const DropdownMenu: React.FC<DropdownMenuProps> = props => {
    const Tag = props.renderAs || "ul";
    return (
        <Tag className="dropdown__menu animated fadeIn" style={props.style}>
            {props.children}
        </Tag>
    );
};