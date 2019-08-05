// Dependencias Globales
import React from "react";
import ReactDOM from "react-dom";
import { BrowserRouter, Route, Switch, Redirect } from "react-router-dom";

// Layouts
import { getCatalogRoutes, RedirectToLogin } from "./components/layout/catalogs";

// Domain
import { Login } from "./components/domain/operatives/login";

// Genéricos
import { NotificationCenter } from "./components/generic";
import { SessionWatcher } from "./components/layout/session-watcher";

// Estilos
import "@fortawesome/fontawesome-free/css/all.min.css";
import "animate.css/animate.css";
import "./assets/scss/theme.scss";
// Para el selector de fechas
import "react-datepicker/dist/react-datepicker.css";
import { CredentialsHelper } from "./helpers/credentials-helper";

const RedirectMainScreen : React.FC = () =>
    <Redirect to="/candidato" />;

interface AppState {
    userIsAuthenticated: boolean;
}

class App extends React.Component<{}, AppState>  {
    state: AppState = {
        userIsAuthenticated: CredentialsHelper.isAuthenticated()
    }

    handleAuthenticatedChanged = (userIsAuthenticated: boolean) => {
        this.setState({
            userIsAuthenticated
        });
    }

    render() {
        return (
            <>
                <NotificationCenter />
                <BrowserRouter>
                    <SessionWatcher onAuthenticatedChanged={this.handleAuthenticatedChanged}></SessionWatcher>
                    <Switch>
                        {getCatalogRoutes(this.state.userIsAuthenticated)} 
                        <Route 
                            exact 
                            path="/login" 
                            render={props => 
                                this.state.userIsAuthenticated ? 
                                    <RedirectMainScreen/> : 
                                    <Login {...props} /> 
                            } 
                        />
                        <Route
                            exact
                            path="*" 
                            render={props => (
                                this.state.userIsAuthenticated ?
                                    <RedirectMainScreen/> :
                                    <RedirectToLogin/>
                            )}
                        />
                    </Switch>
                </BrowserRouter>
            </>
        );
    }
}

ReactDOM.render(<App />, document.getElementById("app"));
