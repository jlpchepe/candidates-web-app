import * as React from "react";
import { Candidato } from "../../../../../communication/services";
import { goToPath } from "../../../../../helpers/navigation-helper";
import { ListCatalog } from "../../../base/list-catalog";
import { withItemsLoading, WithItemsLoaderProps } from "../../../../hoc/with-items-loader";
import { CandidatoListable } from "../../../../../communication/dtos/candidato";
import { DateHelper } from "../../../../../helpers/date-helper";
import { Row } from "../../../common/row";
import { LabeledTextInput } from "../../../../generic";
import { Column } from "../../../common/column";
import { EstatusCandidatoDescriptions, EstatusAcademicoDescriptions, BolsaTrabajoDescriptions, RolCandidatoDescriptions } from "../../../../../communication/enums/candidato";

const service = Candidato;
interface CandidatoListFilters {
    nombre: string;
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
                containerFluid
                filters={
                    <Column size={6}>
                        <LabeledTextInput
                            label="Filtro nombre"
                            value={this.props.filters.nombre}
                            onChange={nombre => this.props.setFilters({ nombre })}
                        >
                        </LabeledTextInput>
                    </Column>
                }
                items={this.props.items}
                pageNumber={this.props.pageNumber}
                onPageChange={this.props.onPageChange}
                pageSize={this.props.pageSize}
                totalPages={this.props.totalPages}
                columns={[
                    { header: "Clave puesto", contentSelector: item => item.puestoClave },
                    { header: "Puesto", contentSelector: item => item.puestoNombre },
                    { header: "Nombre", contentSelector: item => item.nombre },
                    { header: "Correo", contentSelector: item => item.correo },
                    { header: "Teléfono", contentSelector: item => item.telefono },
                    { header: "Estatus académico", contentSelector: item => EstatusAcademicoDescriptions.get(item.estatusAcademico) },
                    { header: "Estatus del candidato", contentSelector: item => EstatusCandidatoDescriptions.get(item.estatus) },
                    { header: "Fecha de actualización", contentSelector: item => DateHelper.formatShortDateLocal(item.fechaDeActualizacion) },
                    { header: "Proyecto", contentSelector: item => item.proyectoNombre },
                    { header: "Folio de solicitud", contentSelector: item => item.solicitudPersonalFolio },
                    { header: "Experiencia laboral", contentSelector: item => item.añosDeExperiencia },
                    { header: "Recepción de CV", contentSelector: item => DateHelper.formatShortDateLocal(item.fechaDeRecepcionCurriculum) },
                    { header: "Fecha de contacto", contentSelector: item => DateHelper.formatShortDateLocal(item.fechaDeContacto) },
                    { header: "Fecha preentrevista", contentSelector: item => DateHelper.formatShortDateLocal(item.fechaPreentrevistaTelefonica) },
                    { header: "Bolsa", contentSelector: item => BolsaTrabajoDescriptions.get(item.bolsa) },
                    { header: "Rol", contentSelector: item => RolCandidatoDescriptions.get(item.rol) },
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
    (pageNumber: number, pageSize: number, filters: CandidatoListFilters) => 
        service.getPaginated(pageNumber, pageSize, filters.nombre),
    (item) => service.delete(item.id),
);
