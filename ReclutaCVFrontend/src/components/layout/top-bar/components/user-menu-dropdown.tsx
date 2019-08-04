import React from "react";
import { Dropdown, DropdownItem, DropdownMenu, DropdownToggle, Icon } from "../../../generic";

interface UsuarioMenuProps {
    activeWindow: string;
    onCloseSession: () => void;
    onClickActionButton: () => void;
    userName: string;
    userRole: string;
}

export const UsuarioMenuDropdown: React.FC<UsuarioMenuProps> = props => (
    <Dropdown>
        <DropdownToggle
            icon={
                <div className="user-menu__toggle">
                    <div className="user-menu__image">
                        <Icon icon="user-circle" size="2x" />
                    </div>
                    <div className="user-menu__info">
                        <p>{props.userName}</p>
                        <p>{props.userRole}</p>
                    </div>
                    <div className="user-menu__icon">
                        <Icon icon="chevron-down" />
                    </div>
                </div>
            }
            onClick={props.onClickActionButton}
        />
        {props.activeWindow == "userMenuDropdown" && (
            <DropdownMenu style={{ width: "100%" }}>
                <DropdownItem onClick={props.onCloseSession}>Cerrar sesión</DropdownItem>
            </DropdownMenu>
        )}
    </Dropdown>
);
