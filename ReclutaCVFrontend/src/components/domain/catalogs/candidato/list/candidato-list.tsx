import * as React from "react";
import { Candidato } from "../../../../../communication/services";
import { goToPath } from "../../../../../helpers/navigation-helper";
import { ListCatalog } from "../../../base/list-catalog";
import { withItemsLoading, WithItemsLoaderProps } from "../../../../hoc/with-items-loader";
import { CandidatoListable } from "../../../../../communication/dtos/candidato";
import { DateHelper } from "../../../../../helpers/date-helper";

const service = Candidato;
interface CandidatoListFilters {

}
/**
 * Muestra el listado
 */
class CandidatoListSimple extends React.Component<WithItemsLoaderProps<CandidatoListable, CandidatoListFilters>> {
    private readonly onNewItem = () => goToPath(this.props.history, "candidato/new");

    render() {
        return (
            <ListCatalog
                title="Candidatos"
                items={this.props.items}
                pageNumber={this.props.pageNumber}
                onPageChange={this.props.onPageChange}
                pageSize={this.props.pageSize}
                totalPages={this.props.totalPages}
                columns={[
                    {
                        header: "Nombre",
                        contentSelector: item => item.nombre
                    }
                ]}
                onNewItem={this.onNewItem}
                onItemEdit={item => goToPath(this.props.history, "candidato/" + item.id)}
                onItemSeeDetails={item => goToPath(this.props.history, "candidato/" + item.id + "/true")}
                onItemDelete={item => this.props.onDeleteItem(item)}
            />
        );
    }
}

export const CandidatoList = withItemsLoading(
    CandidatoListSimple,
    service.getPaginated,
    (item) => service.delete(item.id)
);
