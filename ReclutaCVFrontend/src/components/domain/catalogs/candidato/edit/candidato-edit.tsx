import * as React from "react";

import { LabeledTextAreaInput, LabeledCombo } from "../../../../generic";
import { Row } from "../../../common/row";
import { CandidatoInsertable, CandidatoUpdatable, CandidatoConsultable } from "../../../../../communication/dtos/candidato";
import { EditCatalog } from "../../../base/edit-catalog";
import { WithModelManagementProps, withModelLoading } from "../../../../hoc/with-model-loader";
import { OperatorCombo } from "../../operator/combo/operator-combo";
import { Candidato } from "../../../../../communication/services";
import { LabeledDateInput, LabeledNumberInput } from "../../../../generic/input";
import { Column } from "../../../common/column";
import { addDays } from "date-fns/esm";

const service = Candidato;

type TModelEditable = CandidatoInsertable & CandidatoUpdatable & CandidatoConsultable;

interface CandidatoEditState {
    model: TModelEditable;
    candidatoType: number;
}

class CandidatoEditSimple extends React.Component<WithModelManagementProps<TModelEditable>, CandidatoEditState> {
    render() {
        return (
            <EditCatalog 
                title="Candidato" 
                readonly={this.props.readonly} 
                onSave={this.props.onSaveModel}
            >
                <Row>

                </Row>
            </EditCatalog>
        );
    }
}

const getNewCandidato: () => TModelEditable = () => ({
    id: 1,
    nombre: undefined,
    correo: undefined,
    telefono: undefined,
    fechaDeNacimiento: undefined,
    estadoCivil: undefined,
    lugarNacimiento: undefined,
    generalesComentarios: undefined,
    fechaDeActualizacion: undefined,
    compañia: undefined,
    añosDeExperiencia: undefined,
    sueldoActual: undefined,
    motivoDeSeparacion: undefined,
    carrera: undefined,
    institucion: undefined,
    estatusAcademico: undefined,
    cursos: undefined,
    certificaciones: undefined,
    competenciasOHabilidades: undefined,
    tecnologiasQueDomina: undefined,
    softwareQueDomina: undefined,
    nivelDeIngles: undefined,
    nivelDeInglesHablado: undefined,
    nivelDeInglesEscrito: undefined,
    nivelDeInglesLectura: undefined,
    solicitudPersonalFolio: undefined,
    puestoClave: undefined,
    puestoNombre: undefined,
    proyectoNombre: undefined,
    fechaDeRecepcionCurriculum: undefined,
    fechaDeContacto: undefined,
    fechaPreentrevistaTelefonica: undefined,
    fechaRecepcionSolicitudRegistro: undefined,
    quienLoContacto: undefined,
    bolsa: undefined,
    bolsaOtra: undefined,
    rol: undefined,
    rolOtro: undefined,
    expectativaEconomica: undefined,
    estatus: undefined,
    reclutamientoComentarios: undefined,
    examenPsicometricoNombre: undefined,
    examenPsicometricoResultados: undefined,
    examenPsicometricoObservaciones: undefined,
    examenProgramacionFecha: undefined,
    examenProgramacionIpComputadora: undefined,
    examenProgramacionId: undefined,
    examenProgramacionUmlCalificacion: undefined,
    examenProgramacionUmlTotalReactivos: undefined,
    examenProgramacionAdooCalificacion: undefined,
    examenProgramacionAdooTotalReactivos: undefined,
    examenProgramacionPooCalificacion: undefined,
    examenProgramacionPooTotalReactivos: undefined,
    examenProgramacionLogicaCalificacion: undefined,
    examenProgramacionLogicaTotalReactivos: undefined,
    examenProgramacionWebCalificacion: undefined,
    examenProgramacionWebTotalReactivos: undefined,
    examenProgramacionJavascriptCalificacion: undefined,
    examenProgramacionJavascriptTotalReactivos: undefined,
    examenProgramacionScrumCalificacion: undefined,
    examenProgramacionScrumTotalReactivos: undefined,
    examenProgramacionTecnologiaCalificacion: undefined,
    examenProgramacionTecnologiaTotalReactivos: undefined,
    examenProgramacionAciertos: undefined,
    examenProgramacionTotalReactivos: undefined,
    examenProgramacionRango: undefined,
    examenAnalistaFecha: undefined,
    examenAnalistaIpComputadora: undefined,
    examenAnalistaTeoricoId: undefined,
    examenAnalistaTeoricoAciertos: undefined,
    examenAnalistaTeoricoTotalReactivos: undefined,
    examenAnalistaTeoricoRango: undefined,
    examenAnalistaPracticoId: undefined,
    examenAnalistaPracticoNumeroCaso: undefined,
    examenAnalistaPracticoAciertos: undefined,
    examenAnalistaPracticoTotalReactivos: undefined,
    examenAnalistaPracticoRango: undefined,
    examenIngenieroPruebasFecha: undefined,
    examenIngenieroPruebasIpComputadora: undefined,
    examenIngenieroPruebasTeoricoId: undefined,
    examenIngenieroPruebasTeoricoAciertos: undefined,
    examenIngenieroPruebasTeoricoTotalReactivos: undefined,
    examenIngenieroPruebasTeoricoRango: undefined,
    examenIngenieroPruebasPracticoId: undefined,
    examenIngenieroPruebasPracticoCalificacion: undefined,
    examenIngenieroPruebasPracticoPuntos: undefined,
    examenIngenieroPruebasPracticoRango: undefined,
    examenIngenieroPruebasSqlTotalReactivos: undefined,
    examenIngenieroPruebasSqlCalificacion: undefined,
    examenAdministradorProyectoFecha: undefined,
    examenAdministradorProyectoIpComputadora: undefined,
    examenAdministradorProyectoId: undefined,
    examenAdministradorProyectoAciertos: undefined,
    examenAdministradorProyectoTotalReactivos: undefined,
    examenAdministradorProyectoRango: undefined,
    examenPracticoSoporteBdFecha: undefined,
    examenPracticoSoporteBdAciertos: undefined,
    examenPracticoSoporteBdTotalReactivos: undefined,
    examenPracticoSoporteBdRango: undefined,
    entrevistaCapitalHumanoFecha: undefined,
    entrevistaCapitalHumanoComentarios: undefined,
    entrevistaCoordinadorYEquipoTecnicoFecha: undefined,
    entrevistaCoordinadorYEquipoTecnicoComentarios: undefined,
    entrevistaInglesFecha: undefined,
    entrevistaInglesComentarios: undefined,
    entrevistaGerenteAreaFecha: undefined,
    entrevistaGerenteAreaComentarios: undefined,
    veredictoFinal: undefined,
    veredictoFinalNivelIdentificado: undefined,
    veredictoFinalComentarios: undefined,
    propuestaEconomicaFecha: undefined,
    propuestaEconomicaEstatus: undefined,
    propuestaEconomicaSueldo: undefined,
    propuestaEconomicaComentarios: undefined,
    ingresoFecha: undefined,
    ingresoTipoContrato: undefined,
    ingresoVencimientoContratoDeterminado: undefined,
    ingresoObservaciones: undefined,
});

export const CandidatoEdit = withModelLoading(
    CandidatoEditSimple,
    getNewCandidato,
    service.getById,
    service.insert,
    service.update
);
