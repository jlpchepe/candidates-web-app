import { UsuarioRole } from "../enums/user-roles";


export interface UsuarioListable {
    id: number;
    name: string;
    active: boolean;
}

export interface UsuarioConsultable extends UsuarioUpdatable {
}

export interface UsuarioUpdatable {
    id: number;
    name: string;
    active: boolean;
}

export interface UsuarioInsertable {
    name: string;
    active: boolean;
    password?: string;
}