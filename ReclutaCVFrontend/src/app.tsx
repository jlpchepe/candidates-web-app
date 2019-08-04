// Dependencias Globales
import React from "react";
import ReactDOM from "react-dom";
import { BrowserRouter, Route, Switch } from "react-router-dom";

// Layouts
import { Catalogs } from "./components/layout/catalogs";

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

class App extends React.Component {

    render() {
        return (
            <>
                <NotificationCenter />
                <BrowserRouter>
                    <SessionWatcher></SessionWatcher>
                    <Switch>
                        <Route exact path="/" render={props => <Login {...props} />} />
                        <Catalogs />
                    </Switch>
                </BrowserRouter>
            </>
        );
    }
}

ReactDOM.render(<App />, document.getElementById("app"));
