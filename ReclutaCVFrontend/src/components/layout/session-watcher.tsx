import * as React from "react";
import { withRouter, RouteComponentProps } from "react-router";
import { goToPath } from "../../helpers/navigation-helper";
import { CredentialsHelper } from "../../helpers/credentials-helper";
import { Subscription } from "rxjs";
import { isUsuarioDisabled } from "../../communication/events/system-event";
import { NotificationHelper } from "../../helpers/notification-helper";
import { WorkOrder, SystemEvents } from "../../communication/services";



/**
 * Componente encargado de llevar seguimiento del logout del sistema
 */
class SessionWatcherSimple extends React.Component<RouteComponentProps> {
    private onLogoutSubscription : Subscription;
    private onLoginSubscription : Subscription;
    private onUsuarioDisabledSubscription : Subscription;

    tryUnsubscribeDisableUsuarioEvent = () => {
        if(this.onUsuarioDisabledSubscription != null){
            this.onUsuarioDisabledSubscription.unsubscribe();
        }
    }

    subscribeDisableUsuarioEvent = () => {
        this.tryUnsubscribeDisableUsuarioEvent();

        this.onUsuarioDisabledSubscription = SystemEvents
            .observe()
            .subscribe(systemEvent => {
                if(isUsuarioDisabled(systemEvent)){
                    NotificationHelper.notifyWarning("Usuario deshabilitado", "Su usuario fue deshabilitado");

                    // Ante la deshabilitación de usuario, sacamos al usuario del sistema
                    CredentialsHelper.deleteSessionToken();
                }
            });
    }

    componentDidMount() {
        if(CredentialsHelper.isAuthenticated()){
            this.subscribeDisableUsuarioEvent();
        }

        this.onLogoutSubscription = CredentialsHelper.onLogout(() => {
            SystemEvents.dropConnection();
            WorkOrder.dropConnection();
            this.tryUnsubscribeDisableUsuarioEvent();
            goToPath(this.props.history, "");
        });
        
        this.onLoginSubscription = CredentialsHelper.onLogin(() => {
            this.subscribeDisableUsuarioEvent();
        });
    }

    componentWillUnmount() {
        this.onLogoutSubscription.unsubscribe();
        this.onLoginSubscription.unsubscribe();
        this.tryUnsubscribeDisableUsuarioEvent();
    }

    render(){
        return <></>;
    }
};


export const SessionWatcher = withRouter(SessionWatcherSimple);