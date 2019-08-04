import React from "react";
import classnames from "classnames";

interface SideBarProps {
    className?: string;
    items: {
        isActive: boolean;
        label: string;
        onClick: () => void;
    }[];
    style?: React.CSSProperties;
}

export const SideBar: React.FC<SideBarProps> = props => (
    <ul className={classnames("side-bar__nav", props.className)} style={props.style}>
        {props.items.map((item, iItem) => (
            <li
                className={`side-bar__nav-item${
                    item.isActive ? " side-bar__nav-item--active" : ""}`}
                key={iItem}
                onClick={item.onClick}
            >
                {item.label}
            </li>
        ))}
    </ul>
);
