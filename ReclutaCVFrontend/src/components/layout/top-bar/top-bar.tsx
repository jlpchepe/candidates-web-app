// Dependencias Globales
import React from "react";
import { withRouter, RouteComponentProps } from "react-router";
import { Subscription } from "rxjs";

// Servicios
import { WorkshopCapacity } from "../../../communication/dtos/workshop";
import { NotificationDroppable } from "../../../communication/dtos/notification";
import { Notification, Configuration, Workshop } from "../../../communication/services";
import {
    SystemEventType,
    isNotificationQueried,
    isNotificationCreated,
    isNotificationRead
} from "../../../communication/events/system-event";
import { NotificationRead } from "../../../communication/events/notification-read";

// Layouts
import NavBar from "../nav-bar";

// Assets
import logo from "../../../assets/img/logo-nissan-color.png";

// Helpers
import { CredentialsHelper, AuthenticatedUserInfo } from "../../../helpers/credentials-helper";
import { toObservable } from "../../../helpers/observable-helper";

// Components
import { UserMenuDropdown } from "./components";
import NotificationDropdown from "./components/notification-dropdown";
import WorkshopCapacityModal from "./components/workshop-capacity-modal";
import { Modal } from "../../generic";;
import { TopBarBrand } from "./components/top-bar-brand";
import { WorkshopCapacityButton } from "./components/workshop-capacity-button";
import { WorkOrderDetailsModal } from "../../domain/operatives/modals/work-order-detail-modal";

const workshopService = Workshop;
const notificationService = Notification;
const configurationService = Configuration;

export interface DropdownType {
    catalogsDropdown: boolean;
    notificationDropdown: boolean;
    userMenuDropdown: boolean;
    workshopCapacityModal: boolean;
}

interface TopBarState {
    activeWindow: string;
    notifications: NotificationDroppable[];
    userName: string;
    userRole: string;
    workshopCapacity: WorkshopCapacity;
    logoBase64: string;
    workshopCapacityDate: Date;
    workOrderModal: WorkOrderModalType;
}

enum WorkOrderModalTab {
    Details,
    Invalidation
}

interface WorkOrderModalType {
    currentWorkOrderId: number;
    isOpen: boolean;
}

/**
 * Barra superior para la aplicación
 */
class TopBar extends React.Component<RouteComponentProps, TopBarState> {
    state: TopBarState = {
        activeWindow: null,
        workOrderModal: {
            currentWorkOrderId: null,
            isOpen: false
        },
        workshopCapacityDate: new Date(),
        notifications: [],
        userName: "",
        userRole: "",
        workshopCapacity: {
            operators: [],
            workShopCapacityFactor: 0
        },
        logoBase64: undefined
    };

    private notificationSubscription: Subscription;

    componentDidMount() {
        const credentials: AuthenticatedUserInfo = CredentialsHelper.getRoleAndUserFromTokenInCookie();

        if (credentials != null) {
            this.setState({
                userName: credentials.userName,
                userRole: credentials.userRole
            });
        }

        this.notificationSubscription = notificationService.observe().subscribe(notificationEvent => {
            if (isNotificationQueried(notificationEvent)) {
                this.setState({ notifications: notificationEvent.event.notifications });
            } else if (isNotificationCreated(notificationEvent)) {
                this.setState(prevState => ({ notifications: [...prevState.notifications, notificationEvent.event] }));
            } else if (isNotificationRead(notificationEvent)) {
                this.removeNotification(notificationEvent.event.notificationId);
            }
        });

        this.getLogo();
    }

    componentWillUnmount() {
        this.notificationSubscription.unsubscribe();
    }

    private removeNotification(notificationId: number) {
        this.setState(prevState => ({
            notifications: prevState.notifications.filter(notification => notification.id != notificationId)
        }));
    }

    private onCloseSession = () => {
        CredentialsHelper.deleteSessionToken();
    };

    private onClickMarkAsRead = (notificationId: number) => {
        notificationService.markAsRead(notificationId).then(() => this.removeNotification(notificationId));
    };

    private onClickNotification = (id, workOrderId?) => {
        if (workOrderId != null) {
            this.setState({
                workOrderModal: {
                    ...this.state.workOrderModal,
                    currentWorkOrderId: workOrderId,
                    isOpen: !this.state.workOrderModal.isOpen
                }
            });
        }
    };

    private getLogo = () => {
        toObservable(configurationService.getSystemThemeConfiguration()).subscribe(response =>
            this.setState({
                logoBase64: response.companyLogoBase64 || logo
            })
        );
    };

    private onChangeWorkCapacityDate = (date: Date) => {
        workshopService.getCapacity(date).then(data => {
            this.setState({ workshopCapacity: data, workshopCapacityDate: date });
        });
    };

    private onToggleWorkorderModal = () => {
        this.setState({
            workOrderModal: {
                ...this.state.workOrderModal,
                isOpen: !this.state.workOrderModal.isOpen
            }
        });
    };

    private onClickActionButton = (activeWindow: string) => {
        if (this.state.activeWindow === activeWindow) {
            this.setState({ activeWindow: null });
        } else {
            this.setState({ activeWindow });
        }
    };

    private onClickWorkshopCapacityModal = () => this.onClickActionButton("workshopCapacityModal");
    private onClickNotificationDropdown = () => this.onClickActionButton("notificationDropdown");
    private onClickUserMenuDropdown = () => this.onClickActionButton("userMenuDropdown");
    private onClickCatalogsDropdown = () => this.onClickActionButton("catalogsDropdown");

    render() {
        const { activeWindow, logoBase64, notifications, userName, userRole, workshopCapacity } = this.state;
        return (
            <div className="top-bar">
                <div className="top-bar__container">
                    <TopBarBrand logoBase64={logoBase64} history={this.props.history} />
                    <div className="top-bar--collapse">
                        <div className="user-menu">
                            <WorkshopCapacityButton onClickActionButton={this.onClickWorkshopCapacityModal} />
                            <NotificationDropdown
                                activeWindow={activeWindow}
                                notifications={notifications}
                                onClickActionButton={this.onClickNotificationDropdown}
                                onClickMarkAsRead={this.onClickMarkAsRead}
                                onClick={this.onClickNotification}
                            />
                            <UserMenuDropdown
                                activeWindow={activeWindow}
                                onCloseSession={this.onCloseSession}
                                onClickActionButton={this.onClickUserMenuDropdown}
                                userName={userName}
                                userRole={userRole}
                            />
                        </div>
                    </div>
                </div>
                <div className="top-bar__container">
                    <NavBar activeWindow={activeWindow} onClickActionButton={this.onClickCatalogsDropdown} />
                </div>
                <WorkOrderDetailsModal 
                    readonly
                    isOpen={this.state.workOrderModal.isOpen}
                    onToggleModal={this.onToggleWorkorderModal} 
                    workOrderId={this.state.workOrderModal.currentWorkOrderId}
                />
                
                
            </div>
        );
    }
}

export default withRouter(TopBar);
