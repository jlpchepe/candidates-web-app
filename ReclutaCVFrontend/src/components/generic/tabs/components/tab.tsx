import React from "react";

interface TabProps {
    children: React.ReactNode;
    style: object;
}

export const Tab: React.FC<TabProps> = props => (
    <ul className="tab" style={props.style}>
        {props.children}
    </ul>
);