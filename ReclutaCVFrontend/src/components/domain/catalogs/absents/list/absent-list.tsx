import * as React from "react";
import { Absent } from "../../../../../communication/services";
import { goToPath } from "../../../../../helpers/navigation-helper";
import { ListCatalog } from "../../../base/list-catalog";
import { withItemsLoading, WithItemsLoaderProps } from "../../../../hoc/with-items-loader";
import { AbsentListable } from "../../../../../communication/dtos/absent";
import { DateHelper } from "../../../../../helpers/date-helper";

const service = Absent;
interface AbsentListFilters {

}
/**
 * Muestra el listado
 */
class AbsentListSimple extends React.Component<WithItemsLoaderProps<AbsentListable, AbsentListFilters>> {
    private readonly onNewItem = () => goToPath(this.props.history, "absent/new");

    render() {
        return (
            <ListCatalog
                title="Ausencias"
                items={this.props.items}
                pageNumber={this.props.pageNumber}
                onPageChange={this.props.onPageChange}
                pageSize={this.props.pageSize}
                totalPages={this.props.totalPages}
                columns={[
                    {
                        header: "Operador",
                        contentSelector: item => item.operatorName
                    },
                    {
                        header: "Motivo",
                        contentSelector: item => item.reason
                    },
                    {
                        header: "Fecha inicio",
                        contentSelector: item => DateHelper.formatShortDateUtc(item.startDate)
                    },
                    {
                        header: "Fecha fin",
                        contentSelector: item => DateHelper.formatShortDateUtc(item.dueDate)
                    },
                    {
                        header: "Horas ",
                        contentSelector: item => item.hoursOfAbsent
                    }
                ]}
                onNewItem={this.onNewItem}
                onItemEdit={item => goToPath(this.props.history, "absent/" + item.id)}
                onItemSeeDetails={item => goToPath(this.props.history, "absent/" + item.id + "/true")}
                onItemDelete={item => this.props.onDeleteItem(item)}
            />
        );
    }
}

export const AbsentList = withItemsLoading(
    AbsentListSimple,
    service.getPaginated,
    (item, justification, password) => service.delete(item.id, justification, password));
