import * as React from "react";
import { Operator } from "../../../../../communication/services";
import { goToPath } from "../../../../../helpers/navigation-helper";
import { ListCatalog } from "../../../base/list-catalog";
import { withItemsLoading, WithItemsLoaderProps } from "../../../../hoc/with-items-loader";
import { OperatorListable } from "../../../../../communication/dtos/operator";
import { EmployeeTypeDescriptions, EmployeeType } from "../../../../../communication/enums/employee-type";
import { MechanicLevelDescriptions } from "../../../../../communication/enums/mechanic-level";

const service = Operator;

/**
 * Muestra el listado
 */
class OperatorListSimple extends React.Component<WithItemsLoaderProps<OperatorListable>> {

    private readonly onNewItem = () => goToPath(this.props.history, "operator/new");

    render() {
        return (
            <ListCatalog

                title="Operadores"
                items={this.props.items}
                pageNumber={this.props.pageNumber}
                onPageChange={this.props.onPageChange}
                pageSize={this.props.pageSize}
                totalPages={this.props.totalPages}
                columns={[
                    {
                        header: "Código",
                        contentSelector: item => item.code
                    },
                    {
                        header: "Nombre",
                        contentSelector: item => item.name
                    },
                    {
                        header: "Tipo empleado",
                        contentSelector: item => EmployeeTypeDescriptions.get(item.employeeType)
                    },
                    {
                        //solo mostramos el nivel del mecanico cuando el tipo de empleado sea mecanico
                        header: "Nivel mecánico",
                        contentSelector: item => item.employeeType == EmployeeType.Mechanic ? MechanicLevelDescriptions.get(item.mechanicLevel) : null
                    },
                    {
                        header: "Estación de trabajo",
                        contentSelector: item => item.workstationName
                    }
                ]}
                onNewItem={this.onNewItem}
                onItemEdit={item => goToPath(this.props.history, "operator/" + item.id)}
                onItemSeeDetails={item => goToPath(this.props.history, "operator/" + item.id + "/true")}
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

export const OperatorList = withItemsLoading(OperatorListSimple, service.getPaginated,
    (item, justification, password) => service.delete(item.id, justification, password));