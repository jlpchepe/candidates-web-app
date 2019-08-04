import { UserRole } from "../enums/user-roles";


export interface UserListable {
    id: number;
    name: string;
    role: UserRole;
    active: boolean;
}

export interface UserConsultable extends UserUpdatable {
}

export interface UserUpdatable {
    id: number;
    name: string;
    role: UserRole;
    active: boolean;
    advisorId: number;
}

export interface UserInsertable {
    name: string;
    role: UserRole;
    active: boolean;
    advisorId: number;
    password?: string;
}