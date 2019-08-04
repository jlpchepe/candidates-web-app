import * as React from "react";
import { User } from "../../../../../communication/services";
import { goToPath } from "../../../../../helpers/navigation-helper";
import { ListCatalog } from "../../../base/list-catalog";
import { WithItemsLoaderProps, withItemsLoading } from "../../../../hoc/with-items-loader";
import { UserListable } from "../../../../../communication/dtos/user";
import { UserRoleDescriptions } from "../../../../../communication/enums/user-roles";

const service = User;

/**
 * Muestra el listado
 */
class UserListSimple extends React.Component<WithItemsLoaderProps<UserListable>> {

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
                        contentSelector: item => UserRoleDescriptions.get(item.role)
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

export const UserList = withItemsLoading(UserListSimple, service.getPaginated,
    (item, justification, password) => service.delete(item.id, justification, password));