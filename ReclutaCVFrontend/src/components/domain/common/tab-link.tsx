import * as React from "react";
import classnames from "classnames";
import { NavItem, NavLink } from "reactstrap";

export const TabLink: React.FC<{title: string, tab: number, onTabChanged: (tab: number) => void}> = (props) => (
    <NavItem>
        <NavLink
            className={classnames({ active: this.state.currentTab === props.tab })}
            onClick={() => { props.onTabChanged(props.tab); }}
        >{props.title}
        </NavLink>
    </NavItem>
);