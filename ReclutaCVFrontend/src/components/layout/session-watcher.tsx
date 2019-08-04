import * as React from "react";
import { withRouter, RouteComponentProps } from "react-router";
import { goToPath } from "../../helpers/navigation-helper";
import { CredentialsHelper } from "../../helpers/credentials-helper";
import { Subscription } from "rxjs";
import { NotificationHelper } from "../../helpers/notification-helper";



/**
 * Componente encargado de llevar seguimiento del logout del sistema
 */
class SessionWatcherSimple extends React.Component<RouteComponentProps> {
    private onLogoutSubscription : Subscription;
    private onLoginSubscription : Subscription;

    componentDidMount() {
        this.onLogoutSubscription = CredentialsHelper.onLogout(() => {
            goToPath(this.props.history, "");
        });
        
        this.onLoginSubscription = CredentialsHelper.onLogin(() => {
            
        });
    }

    componentWillUnmount() {
        this.onLogoutSubscription.unsubscribe();
        this.onLoginSubscription.unsubscribe();
    }

    render(){
        return <></>;
    }
};


export const SessionWatcher = withRouter(SessionWatcherSimple);