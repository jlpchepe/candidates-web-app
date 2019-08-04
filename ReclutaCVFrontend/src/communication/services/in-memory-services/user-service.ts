import { UsuarioService } from "../user-service";
import { UsuarioInsertable, UsuarioUpdatable, UsuarioConsultable } from "../../dtos/user";

const sample : UsuarioConsultable & UsuarioInsertable = {
    id: 1,
    nombre: "Luis",
    contraseña: "",
    activo: true
};
export const InMemoryUsuarioService: UsuarioService = {
    getPaginated: (pageNumberZeroBased: number, pageSize: number) => ({
        items: [sample],
        totalPages: 1
    }),
    getById: (id: number) => sample,
    insert: (model: UsuarioInsertable) => {
        console.log("Insertado");
    },
    update: (model: UsuarioUpdatable) => {
        console.log("Actualizado");
    },
    changeStatus: (id: number, active: boolean) => {
        console.log("Estatus modificado");
        return Promise.resolve();
    },
    delete: (id) => {
        console.log("Eliminado");
    }
};