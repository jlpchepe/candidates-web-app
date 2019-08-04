import * as React from "react";
import { Usuario } from "../../../../../communication/services";
import { goToPath } from "../../../../../helpers/navigation-helper";
import { ListCatalog } from "../../../base/list-catalog";
import { WithItemsLoaderProps, withItemsLoading } from "../../../../hoc/with-items-loader";
import { UsuarioListable } from "../../../../../communication/dtos/user";
import { UsuarioRoleDescriptions } from "../../../../../communication/enums/user-roles";

const service = Usuario;

/**
 * Muestra el listado
 */
class UsuarioListSimple extends React.Component<WithItemsLoaderProps<UsuarioListable>> {

    private readonly onNewItem = () => goToPath(this.props.history, "user/new");

    render() {
        return (
            <ListCatalog
                title="Usuarios"
                items={this.props.items}
                pageNumber={this.props.pageNumber}
                onPageChange={this.props.onPageChange}
                pageSize={this.props.pageSize}
                totalPages={this.props.totalPages}
                columns={[
                    {
                        header: "Nombre",
                        contentSelector: item => item.name
                    },
                    {
                        header: "Rol",
                        contentSelector: item => UsuarioRoleDescriptions.get(item.role)
                    }
                ]}
                onNewItem={this.onNewItem}
                onItemEdit={item => goToPath(this.props.history, "user/" + item.id)}
                onItemSeeDetails={item => goToPath(this.props.history, "user/" + item.id + "/true")}
                onItemChangeStatus={{
                    statusProp: "active",
                    onItemsChange: this.props.onItemsChange,
                    changeStatus: item => {
                        const newStatus = !item.active;

                        return service.changeStatus(item.id, newStatus)
                            .then(() => newStatus);
                    },
                }}
                onItemDelete={this.props.onDeleteItem}
            ></ListCatalog>
        );
    }
}

export const UsuarioList = withItemsLoading(UsuarioListSimple, service.getPaginated,
    (item, justification, password) => service.delete(item.id, justification, password));