import React from "react";
import classnames from "classnames";

interface TabItemProps {
    isActive?: boolean;
    onClick: () => void;
    text: string;
}

export const TabItem: React.FC<TabItemProps> = props => (
    <li className={classnames("tab__item", { "tab__item--active": props.isActive })} onClick={props.onClick}>{props.text}</li>
);