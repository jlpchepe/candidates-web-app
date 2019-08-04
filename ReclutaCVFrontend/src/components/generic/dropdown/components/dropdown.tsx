import React, { ReactNode } from "react";

interface DropdownProps {
    children: ReactNode;
}

export const Dropdown: React.FC<DropdownProps> = props => (
    <div className="dropdown">
        {props.children}
    </div>
);