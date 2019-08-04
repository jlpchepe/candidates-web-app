export interface UsuarioListable {
    id: number;
    nombre: string;
    activo: boolean;
}

export interface UsuarioConsultable extends UsuarioUpdatable {
}

export interface UsuarioUpdatable {
    id: number;
    nombre: string;
    activo: boolean;
}

export interface UsuarioInsertable {
    nombre: string;
    activo: boolean;
    contraseña?: string;
}