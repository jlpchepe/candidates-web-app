// Dependencias globales
import React from "react";
import { Row } from "reactstrap";
import { withRouter } from "react-router";
import { RouteComponentProps } from "react-router-dom";

// Servicios
import { NotificationDroppable } from "../../../../communication/dtos/notification";

// Componentes
import { Dropdown, DropdownItem, DropdownMenu, DropdownToggle, Icon, Label } from "../../../generic";
import { Column } from "../../../domain/common/column";
import { goToPath } from "../../../../helpers/navigation-helper";

interface NotificationDropwdownProps extends RouteComponentProps {
    activeWindow: string;
    notifications: NotificationDroppable[];
    onClickActionButton: () => void;
    onClickMarkAsRead?: (id) => void;
    onClick?: (id, workOrderId?) => void;
}

const NotificationDropdown: React.FC<NotificationDropwdownProps> = props => (
    <Dropdown>
        <DropdownToggle
            icon={
                <div className="user-menu__icon">
                    <div className="user-menu__icon-container">
                        <Icon icon="bell" />
                        {props.notifications.length > 0 && <div className="user-menu__icon--dot" />}
                    </div>
                </div>
            }
            onClick={props.onClickActionButton}
        />
        {props.activeWindow == "notificationDropdown" && (
            <DropdownMenu style={{ width: 400 }}>
                {props.notifications.length > 0 ? (
                    <>
                        {props.notifications.map((notification, i) => (
                            <DropdownItem className="list-group list-group-item" key={i}>
                                <Row>
                                    <Column
                                        size={10}
                                        onClick={() => props.onClick(notification.id, notification.workOrderId)}
                                    >
                                        <Label className="text-primary">{notification.subject}</Label>
                                        <p style={{ fontWeight: "normal" }}>{notification.message}</p>
                                    </Column>

                                    <Column className="d-flex align-items-center">
                                        <Icon
                                            className="hoverable"
                                            icon={"eye"}
                                            onClick={() => props.onClickMarkAsRead(notification.id)}
                                        />
                                    </Column>
                                </Row>
                            </DropdownItem>
                        ))}
                        <DropdownItem onClick={() => goToPath(props.history, "notification-tray")}>
                            Ir a bandeja
                        </DropdownItem>
                    </>
                ) : (
                    <DropdownItem>No hay nuevas notificaciones</DropdownItem>
                )}
            </DropdownMenu>
        )}
    </Dropdown>
);

export default withRouter(NotificationDropdown);
