import { UserService } from "../user-service";
import { UserInsertable, UserUpdatable } from "../../dtos/user";

const sampleUser = {
    id: 1,
    name: "Luis",
    firstLastName: "Rodríguez",
    secondLastName: "López",
    role: 1,
    password: "",
    active: true
};
export const InMemoryUserService: UserService = {
    getPaginated: (pageNumberZeroBased: number, pageSize: number) => ({
        items: [sampleUser],
        totalPages: 1
    }),
    getById: (id: number) => sampleUser,
    insert: (model: UserInsertable) => {
        console.log("Insertado");
    },
    update: (model: UserUpdatable) => {
        console.log("Actualizado");
    },
    changeStatus: (id: number, active: boolean) => {
        console.log("Estatus modificado");
        return Promise.resolve();
    }
};