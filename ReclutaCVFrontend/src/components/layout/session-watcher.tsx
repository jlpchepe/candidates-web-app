import * as React from "react";
import { withRouter, RouteComponentProps } from "react-router";
import { goToPath } from "../../helpers/navigation-helper";
import { CredentialsHelper } from "../../helpers/credentials-helper";
import { Subscription } from "rxjs";
import { NotificationHelper } from "../../helpers/notification-helper";

interface SessionWatcherProps extends RouteComponentProps {
    onAuthenticatedChanged: (userIsAuthenticated: boolean) => void;
}

/**
 * Componente encargado de llevar seguimiento del logout del sistema
 */
class SessionWatcherSimple extends React.Component<SessionWatcherProps> {
    private onLogoutSubscription : Subscription;
    private onLoginSubscription : Subscription;

    componentDidMount() {
        this.onLogoutSubscription = CredentialsHelper.onLogout(() => {
            this.props.onAuthenticatedChanged(false);
            goToPath(this.props.history, "/");
        });
        
        this.onLoginSubscription = CredentialsHelper.onLogin(() => {
            this.props.onAuthenticatedChanged(true);            
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