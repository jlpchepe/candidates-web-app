import * as React from "react";
import { SolicitudVacante } from "../../../../../communication/services";
import { goToPath } from "../../../../../helpers/navigation-helper";
import { ListCatalog } from "../../../base/list-catalog";
import { withItemsLoading, WithItemsLoaderProps } from "../../../../hoc/with-items-loader";
import { SolicitudVacanteListable } from "../../../../../communication/dtos/solicitud-vacante";
import { LabeledTextInput, LabeledNumberInput } from "../../../../generic";
import { Column } from "../../../common/column";
import { DateHelper } from "../../../../../helpers/date-helper";
import { AreaDelSolicitanteDescriptions } from "../../../../../communication/enums/solicitud-vacante-enums";
import { RolCandidatoDescriptions, RolCandidato } from "../../../../../communication/enums/candidato";
import { Row } from "../../../common/row";
import { RolCandidatoCombo } from "../../candidato/combos/candidato-combos";

const service = SolicitudVacante;
interface SolicitudVacanteListFilters {
    busqueda: string | null;
    puestoSolicitado: RolCandidato | null;
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
                filters={
                    <Row>
                        <Column>
                            <LabeledTextInput
                                label="Búsqueda"
                                value={this.props.filters.busqueda}
                                onChange={busqueda => this.props.setFilters({ busqueda })}
                            />
                        </Column>
                        <Column>
                            <RolCandidatoCombo
                                label="Vacante"
                                value={this.props.filters.puestoSolicitado}
                                onChange={puestoSolicitado => this.props.setFilters({ puestoSolicitado })}
                            >
                            </RolCandidatoCombo>
                        </Column>
                    </Row>                    
                }
                items={this.props.items}
                pageNumber={this.props.pageNumber}
                onPageChange={this.props.onPageChange}
                pageSize={this.props.pageSize}
                totalPages={this.props.totalPages}
                columns={[
                    { header: "Folio", contentSelector: item => item.folioCapitalHumano },
                    { header: "Solicitante", contentSelector: item => item.nombreDelSolicitante },
                    { header: "Área", contentSelector: item => AreaDelSolicitanteDescriptions.get(item.areaDelSolicitante) },
                    { header: "Fecha" , contentSelector: item => DateHelper.formatShortDateLocal(item.fechaDeSolicitud) },
                    { header: "Vacante", contentSelector: item => RolCandidatoDescriptions.get(item.puestoSolicitado) },
                    { header: "Inglés", contentSelector: item => item.nivelIdiomaIngles },
                    { header: "Estado civil", contentSelector: item => item.estadoCivil },
                    { header: "Edad", contentSelector: item => item.edadRango },
                    { header: "Proyecto", contentSelector: item => item.proyecto },
                    { header: "Ingreso" , contentSelector: item => DateHelper.formatShortDateLocal(item.fechaEstimadaDeIngreso) },
                    { header: "Experiencia", contentSelector: item => item.experienciaLaboral },
                    { header: "Competencias" , contentSelector: item => item.competenciasOHabilidades },
                    { header: "Evaluación", contentSelector: item => item.tipoDeEvaluacion },
                    { header: "Sueldo", contentSelector: item => item.sueldo }
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
        service.getPaginated(pageNumber, pageSize, filters.busqueda, filters.puestoSolicitado),
    (item) => service.delete(item.id),
);
