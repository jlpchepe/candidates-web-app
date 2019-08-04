import { UsuarioService } from "../user-service";
import { UsuarioInsertable, UsuarioUpdatable } from "../../dtos/user";

const sampleUsuario = {
    id: 1,
    name: "Luis",
    firstLastName: "Rodríguez",
    secondLastName: "López",
    role: 1,
    password: "",
    active: true
};
export const InMemoryUsuarioService: UsuarioService = {
    getPaginated: (pageNumberZeroBased: number, pageSize: number) => ({
        items: [sampleUsuario],
        totalPages: 1
    }),
    getById: (id: number) => sampleUsuario,
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