// Dependencias Globales
import * as React from "react";
import { withRouter, RouteComponentProps } from "react-router";
import { Subscription } from "rxjs";

// Layouts
import NavBar from "../nav-bar";

// Assets
import logo from "../../../assets/img/logo-topbar.png";

// Helpers
import { CredentialsHelper, AuthenticatedUsuarioInfo } from "../../../helpers/credentials-helper";

// Components
import { UsuarioMenuDropdown } from "./components";
import { TopBarBrand } from "./components/top-bar-brand";

export interface DropdownType {
    catalogsDropdown: boolean;
    notificationDropdown: boolean;
    userMenuDropdown: boolean;
    workshopCapacityModal: boolean;
}

interface TopBarState {
    activeWindow: string;
    userName: string;
    userRole: string;
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
        userName: "",
        userRole: "",
        logoBase64: undefined
    };

    componentDidMount() {
        const credentials: AuthenticatedUsuarioInfo = CredentialsHelper.getRoleAndUsuarioFromTokenInCookie();

        if (credentials != null) {
            this.setState({
                userName: credentials.userName,
                userRole: credentials.userRole
            });
        }
        this.getLogo();
    }

    private removeNotification(notificationId: number) {
    }

    private onCloseSession = () => {
        CredentialsHelper.deleteSessionToken();
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
        this.setState({
            logoBase64: logo
        })
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
    private onClickUsuarioMenuDropdown = () => this.onClickActionButton("userMenuDropdown");
    private onClickCatalogsDropdown = () => this.onClickActionButton("catalogsDropdown");

    render() {
        const { activeWindow, logoBase64, userName, userRole } = this.state;
        return (
            <div className="top-bar">
                <div className="top-bar__container">
                    <TopBarBrand logoBase64={logoBase64} history={this.props.history} />
                    <div className="top-bar--collapse">
                        <div className="user-menu">
                            <UsuarioMenuDropdown
                                activeWindow={activeWindow}
                                onCloseSession={this.onCloseSession}
                                onClickActionButton={this.onClickUsuarioMenuDropdown}
                                userName={userName}
                                userRole={userRole}
                            />
                        </div>
                    </div>
                </div>
                <div className="top-bar__container">
                    <NavBar activeWindow={activeWindow} onClickActionButton={this.onClickCatalogsDropdown} />
                </div>
            </div>
        );
    }
}

export default withRouter(TopBar);
