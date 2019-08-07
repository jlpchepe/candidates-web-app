import * as React from "react";
import { SolicitudVacante } from "../../../../../communication/services";
import { goToPath } from "../../../../../helpers/navigation-helper";
import { ListCatalog } from "../../../base/list-catalog";
import { withItemsLoading, WithItemsLoaderProps } from "../../../../hoc/with-items-loader";
import { SolicitudVacanteListable } from "../../../../../communication/dtos/solicitud-vacante";
import { LabeledTextInput, LabeledNumberInput } from "../../../../generic";
import { Column } from "../../../common/column";

const service = SolicitudVacante;
interface SolicitudVacanteListFilters {
    folio: number | null;
}
/**
 * Muestra el listado
 */
class SolicitudVacanteListSimple extends React.Component<WithItemsLoaderProps<SolicitudVacanteListable, SolicitudVacanteListFilters>> {
    private readonly onNewItem = () => goToPath(this.props.history, "solicitud-vacante/new");

    render() {
        return (
            <ListCatalog
                title="Solicitudes de vacantes"
                containerFluid
                overflow
                filters={
                    <Column size={6}>
                        <LabeledNumberInput
                            label="Filtro folio"
                            value={this.props.filters.folio}
                            onChange={folio => this.props.setFilters({ folio: folio })}
                        />
                    </Column>
                }
                items={this.props.items}
                pageNumber={this.props.pageNumber}
                onPageChange={this.props.onPageChange}
                pageSize={this.props.pageSize}
                totalPages={this.props.totalPages}
                columns={[
                    { header: "Folio", contentSelector: item => item.folioCapitalHumano }
                ]}
                onNewItem={this.onNewItem}
                onItemEdit={item => goToPath(this.props.history, "solicitud-vacante/" + item.id)}
                onItemSeeDetails={item => goToPath(this.props.history, "solicitud-vacante/" + item.id + "/true")}
                onItemDelete={item => this.props.onDeleteItem(item)}
            />
        );
    }
}

export const SolicitudVacanteList = withItemsLoading(
    SolicitudVacanteListSimple,
    (pageNumber: number, pageSize: number, filters: SolicitudVacanteListFilters) => 
        service.getPaginated(pageNumber, pageSize, filters.folio),
    (item) => service.delete(item.id),
);
