import React from "react";
import { RouteComponentProps } from "react-router";

// Generics
import { Icon, PasswordInput, Checkbox } from "../../../../generic";

// Services
import { Authentication } from "../../../../../communication/services";

// Helpers
import { CredentialsHelper } from "../../../../../helpers/credentials-helper";

import logo from "../../../../../assets/img/logo-login.png";
import { NotificationHelper } from "../../../../../helpers/notification-helper";

interface LoginState {
    user: string;
    password: string;
    rememberSession: boolean;
}

export class Login extends React.Component<RouteComponentProps, LoginState> {
    state = {
        user: "",
        password: "",
        rememberSession: false
    }

    onChangeUsuario = e => {
        const { value } = e.target;
        this.setState({ user: value });
    }

    onChangePassword = password => {
        this.setState({ password });
    }

    onSubmitHandler = (e) => {
        e.preventDefault();
        Authentication.authenticateUsuario(this.state.user, this.state.password)
            .then(token => {
                CredentialsHelper.setSessionToken(token);
                this.props.history.push("/service-board");
            })
            .catch(_ =>
                NotificationHelper.notifyError(
                    "Error",
                    "Usuario y/o contraseña inválidos"
                )
            );
    };

    render() {
        return (
            <div className="login jumbotron jumbotron-fluid h-100 m-0">
                <div className="row">
                    <div className="login__container animated fadeInDown">
                        <div className="login__brand text-center">
                            <img alt="logo" src={logo} height={90} />
                        </div>
                        <p className="login__title">Inicio de sesión</p>
                        <form onSubmit={this.onSubmitHandler}>
                            <input
                                type="text"
                                className="form-control mb-3 text-center"
                                aria-describedby="Nombre de usuario"
                                placeholder="Usuario"
                                value={this.state.user}
                                onChange={this.onChangeUsuario}
                            />
                            <PasswordInput
                                className="form-control mb-3 text-center"
                                value={this.state.password}
                                placeholder={"Contraseña"}
                                readonly={false}
                                onChange={this.onChangePassword}

                            />
                            <button type="submit" className="btn btn-primary btn-block">
                                <div className="d-flex justify-content-between">
                                    <span className="btn__label">Iniciar sesión</span>
                                    <span className="btn__icon">
                                        <Icon icon="sign-in-alt" />
                                    </span>
                                </div>
                            </button>
                        </form>
                        <div className="d-flex justify-content-center mt-3">
                            <button className="btn btn-link text-white">Recuperar contraseña</button>
                        </div>
                    </div>
                </div>
            </div >
        );
    }
}