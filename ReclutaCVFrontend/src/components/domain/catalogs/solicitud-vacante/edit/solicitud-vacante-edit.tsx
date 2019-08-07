import * as React from "react";

import { LabeledTextAreaInput, LabeledCombo } from "../../../../generic";
import { Row } from "../../../common/row";
import { LabeledTextInput, LabeledDateInput, LabeledNumberInput, LabeledStatusInput } from "../../../../generic";
import { EditCatalog } from "../../../base/edit-catalog";
import { WithModelManagementProps, withModelLoading } from "../../../../hoc/with-model-loader";
import { OperatorCombo } from "../../operator/combo/operator-combo";
import { SolicitudVacante } from "../../../../../communication/services";
import { Column } from "../../../common/column";
import { addDays } from "date-fns/esm";
import { TabContent, TabPane, Nav, NavItem, NavLink } from "reactstrap";
import { Seccion } from "../../../common/section";
import { SolicitudVacanteInsertable, SolicitudVacanteUpdatable, SolicitudVacanteConsultable } from "../../../../../communication/dtos/solicitud-vacante";
import { TabElemento } from "../../../common/tab-element";
import { TabLink } from "../../../common/tab-link";
import { MotivoSolicitudCombo, EstatusSolicitudCombo, TipoDeContratoCombo, AreaDelSolicitanteCombo } from "../combos/solicitud-vacante-combos";
import { RolCandidatoCombo, NivelCandidatoCombo } from "../../candidato/combos/candidato-combos";

const service = SolicitudVacante;

type TModelEditable = SolicitudVacanteInsertable & SolicitudVacanteUpdatable & SolicitudVacanteConsultable;

interface SolicitudVacanteEditState {
    currentTab: SolicitudVacanteEditTab;
}

enum SolicitudVacanteEditTab{
    Generales,
    RequerimientosDelPuesto
}

class SolicitudVacanteEditSimple extends React.Component<WithModelManagementProps<TModelEditable>, SolicitudVacanteEditState> {
    state: SolicitudVacanteEditState = {
        currentTab: SolicitudVacanteEditTab.Generales
    }

    private setTab = (tab: SolicitudVacanteEditTab) => {
        if (this.state.currentTab !== tab) {
            this.setState({
                currentTab: tab
            });
        }
    }

    handleTabChanged = (tab: SolicitudVacanteEditTab) => {
        this.setState({ currentTab: tab });
    }

    render() {
        return (
            <EditCatalog 
                title="Solicitud de vacante" 
                readonly={this.props.readonly} 
                onSave={this.props.onSaveModel}
            >
                <TabContent activeTab={this.state.currentTab}>
                    <Nav tabs style={{ marginBottom: "8px" }}>
                        <TabLink title="Generales" tab={SolicitudVacanteEditTab.Generales} onTabChanged={this.handleTabChanged}></TabLink>
                        <TabLink title="Requerimientos del puesto" tab={SolicitudVacanteEditTab.RequerimientosDelPuesto} onTabChanged={this.handleTabChanged}></TabLink>
                    </Nav>
                    <TabElemento tab={SolicitudVacanteEditTab.Generales}>
                        <Seccion title="Generales">
                            <Row>
                                <LabeledNumberInput label="Folio de capital humano" value={this.props.model.folioCapitalHumano} onChange={folioCapitalHumano => this.props.setModel({ folioCapitalHumano })} readonly={this.props.readonly}/>
                                <LabeledDateInput label="Fecha de solicitud" value={this.props.model.fechaDeSolicitud} onChange={fechaDeSolicitud => this.props.setModel({ fechaDeSolicitud })} readonly={this.props.readonly}/>
                                <MotivoSolicitudCombo label="Motivo" value={this.props.model.motivo} onChange={motivo => this.props.setModel({ motivo })} readonly={this.props.readonly} />
                                <LabeledTextInput label="Especifique motivo" value={this.props.model.especifiqueMotivo} onChange={especifiqueMotivo => this.props.setModel({ especifiqueMotivo })} readonly={this.props.readonly}/>                
                            </Row>
                            <Row>
                                <LabeledTextInput label="Nombre del solicitante" value={this.props.model.nombreDelSolicitante} onChange={nombreDelSolicitante => this.props.setModel({ nombreDelSolicitante })} readonly={this.props.readonly}/>
                                <LabeledTextInput label="Puesto del solicitante" value={this.props.model.puestoDelSolicitante} onChange={puestoDelSolicitante => this.props.setModel({ puestoDelSolicitante })} readonly={this.props.readonly}/>
                                <AreaDelSolicitanteCombo label="Area del solicitante" value={this.props.model.areaDelSolicitante} onChange={areaDelSolicitante => this.props.setModel({ areaDelSolicitante })} readonly={this.props.readonly} />
                                <LabeledTextInput label="Especifique el área del solicitante" value={this.props.model.especifiqueAreaDelSolicitante} onChange={especifiqueAreaDelSolicitante => this.props.setModel({ especifiqueAreaDelSolicitante })} readonly={this.props.readonly}/>
                            </Row>
                        </Seccion>
                        <Seccion title="Capital humano">
                            <Row>
                                <LabeledNumberInput label="Sueldo" value={this.props.model.sueldo} onChange={sueldo => this.props.setModel({ sueldo })} readonly={this.props.readonly}/>
                                <TipoDeContratoCombo label="Tipo de contrato" value={this.props.model.tipoDeContrato} onChange={tipoDeContrato => this.props.setModel({ tipoDeContrato })} readonly={this.props.readonly} />
                                <LabeledTextInput label="Especifique tipo de contrato" value={this.props.model.especifiqueTipoDeContrato} onChange={especifiqueTipoDeContrato => this.props.setModel({ especifiqueTipoDeContrato })} readonly={this.props.readonly}/>
                                <EstatusSolicitudCombo label="Estatus de solicitud" value={this.props.model.estatus} onChange={estatus => this.props.setModel({ estatus })} readonly={this.props.readonly} />
                            </Row>
                        </Seccion>
                    </TabElemento>
                    <TabElemento tab={SolicitudVacanteEditTab.RequerimientosDelPuesto}>
                        <Seccion title="Requerimientos del puesto">
                            <Row>
                                <RolCandidatoCombo label="Puesto solicitado" value={this.props.model.puestoSolicitado} onChange={puestoSolicitado => this.props.setModel({ puestoSolicitado })} readonly={this.props.readonly} />
                                <LabeledTextInput label="Especifique puesto solicitado" value={this.props.model.especifiquePuestoSolicitado} onChange={especifiquePuestoSolicitado => this.props.setModel({ especifiquePuestoSolicitado })} readonly={this.props.readonly}/>
                                <NivelCandidatoCombo label="Nivel de puesto solicitado" value={this.props.model.puestoSolicitadoNivel} onChange={puestoSolicitadoNivel => this.props.setModel({ puestoSolicitadoNivel })} readonly={this.props.readonly} />
                                <LabeledTextInput label="Nombre del jefe inmediato" value={this.props.model.nombreDelJefeInmediato} onChange={nombreDelJefeInmediato => this.props.setModel({ nombreDelJefeInmediato })} readonly={this.props.readonly}/>
                            </Row>
                            <Row>
                                <LabeledTextInput label="Proyecto" value={this.props.model.proyecto} onChange={proyecto => this.props.setModel({ proyecto })} readonly={this.props.readonly}/>
                                <LabeledNumberInput label="Nivel de idioma inglés" value={this.props.model.nivelIdiomaIngles} onChange={nivelIdiomaIngles => this.props.setModel({ nivelIdiomaIngles })} readonly={this.props.readonly}/>
                                <LabeledTextInput label="Rango de edad" value={this.props.model.edadRango} onChange={edadRango => this.props.setModel({ edadRango })} readonly={this.props.readonly}/>
                                <LabeledTextInput label="Estado civil" value={this.props.model.estadoCivil} onChange={estadoCivil => this.props.setModel({ estadoCivil })} readonly={this.props.readonly}/>
                            </Row>
                            <Row>
                                <LabeledDateInput label="Fecha estimada de ingreso" value={this.props.model.fechaEstimadaDeIngreso} onChange={fechaEstimadaDeIngreso => this.props.setModel({ fechaEstimadaDeIngreso })} readonly={this.props.readonly}/>
                                <LabeledTextInput label="Experiencia laboral" value={this.props.model.experienciaLaboral} onChange={experienciaLaboral => this.props.setModel({ experienciaLaboral })} readonly={this.props.readonly}/>
                                <LabeledTextInput label="Competencias o habilidades" value={this.props.model.competenciasOHabilidades} onChange={competenciasOHabilidades => this.props.setModel({ competenciasOHabilidades })} readonly={this.props.readonly}/>
                                <LabeledTextInput label="Certificaciones necesarias" value={this.props.model.certificacionesNecesarias} onChange={certificacionesNecesarias => this.props.setModel({ certificacionesNecesarias })} readonly={this.props.readonly}/>
                            </Row>
                            <Row>
                                <LabeledTextInput label="Tipo de evaluación que se aplicará" value={this.props.model.tipoDeEvaluacion} onChange={tipoDeEvaluacion => this.props.setModel({ tipoDeEvaluacion })} readonly={this.props.readonly}/>
                                <LabeledTextInput label="Observaciones y comentarios" value={this.props.model.observaciones} onChange={observaciones => this.props.setModel({ observaciones })} readonly={this.props.readonly}/>
                            </Row>
                        </Seccion>
                    </TabElemento>
                </TabContent>
            </EditCatalog>
        );
    }
}

const getNewSolicitudVacante: () => TModelEditable = () => ({
    id: undefined,
    folioCapitalHumano: undefined,
    fechaDeSolicitud: undefined,
    motivo: undefined,
    especifiqueMotivo: undefined,
    nombreDelSolicitante: undefined,
    puestoDelSolicitante: undefined,
    areaDelSolicitante: undefined,
    especifiqueAreaDelSolicitante: undefined,
    sueldo: undefined,
    tipoDeContrato: undefined,
    especifiqueTipoDeContrato: undefined,
    estatus: undefined,
    puestoSolicitado: undefined,
    especifiquePuestoSolicitado: undefined,
    puestoSolicitadoNivel: undefined,
    nombreDelJefeInmediato: undefined,
    proyecto: undefined,
    nivelIdiomaIngles: undefined,
    edadRango: undefined,
    estadoCivil: undefined,
    fechaEstimadaDeIngreso: undefined,
    experienciaLaboral: undefined,
    competenciasOHabilidades: undefined,
    certificacionesNecesarias: undefined,
    tipoDeEvaluacion: undefined,
    observaciones: undefined
});

export const SolicitudVacanteEdit = withModelLoading(
    SolicitudVacanteEditSimple,
    getNewSolicitudVacante,
    service.getById,
    service.insert,
    service.update
);
