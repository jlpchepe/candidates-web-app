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
    Id: 1,
    Nombre: undefined,
    Correo: undefined,
    Telefono: undefined,
    FechaDeNacimiento: undefined,
    EstadoCivil: undefined,
    LugarNacimiento: undefined,
    GeneralesComentarios: undefined,
    FechaDeActualizacion: undefined,
    Compañia: undefined,
    AñosDeExperiencia: undefined,
    SueldoActual: undefined,
    MotivoDeSeparacion: undefined,
    Carrera: undefined,
    Institucion: undefined,
    EstatusAcademico: undefined,
    Cursos: undefined,
    Certificaciones: undefined,
    CompetenciasOHabilidades: undefined,
    TecnologiasQueDomina: undefined,
    SoftwareQueDomina: undefined,
    NivelDeIngles: undefined,
    NivelDeInglesHablado: undefined,
    NivelDeInglesEscrito: undefined,
    NivelDeInglesLectura: undefined,
    SolicitudPersonalFolio: undefined,
    PuestoClave: undefined,
    PuestoNombre: undefined,
    ProyectoNombre: undefined,
    FechaDeRecepcionCurriculum: undefined,
    FechaDeContacto: undefined,
    FechaPreentrevistaTelefonica: undefined,
    FechaRecepcionSolicitudRegistro: undefined,
    QuienLoContacto: undefined,
    Bolsa: undefined,
    BolsaOtra: undefined,
    Rol: undefined,
    RolOtro: undefined,
    ExpectativaEconomica: undefined,
    Estatus: undefined,
    ReclutamientoComentarios: undefined,
    ExamenPsicometricoNombre: undefined,
    ExamenPsicometricoResultados: undefined,
    ExamenPsicometricoObservaciones: undefined,
    ExamenProgramacionFecha: undefined,
    ExamenProgramacionIpComputadora: undefined,
    ExamenProgramacionId: undefined,
    ExamenProgramacionUmlCalificacion: undefined,
    ExamenProgramacionUmlTotalReactivos: undefined,
    ExamenProgramacionAdooCalificacion: undefined,
    ExamenProgramacionAdooTotalReactivos: undefined,
    ExamenProgramacionPooCalificacion: undefined,
    ExamenProgramacionPooTotalReactivos: undefined,
    ExamenProgramacionLogicaCalificacion: undefined,
    ExamenProgramacionLogicaTotalReactivos: undefined,
    ExamenProgramacionWebCalificacion: undefined,
    ExamenProgramacionWebTotalReactivos: undefined,
    ExamenProgramacionJavascriptCalificacion: undefined,
    ExamenProgramacionJavascriptTotalReactivos: undefined,
    ExamenProgramacionScrumCalificacion: undefined,
    ExamenProgramacionScrumTotalReactivos: undefined,
    ExamenProgramacionTecnologiaCalificacion: undefined,
    ExamenProgramacionTecnologiaTotalReactivos: undefined,
    ExamenProgramacionAciertos: undefined,
    ExamenProgramacionTotalReactivos: undefined,
    ExamenProgramacionRango: undefined,
    ExamenAnalistaFecha: undefined,
    ExamenAnalistaIpComputadora: undefined,
    ExamenAnalistaTeoricoId: undefined,
    ExamenAnalistaTeoricoAciertos: undefined,
    ExamenAnalistaTeoricoTotalReactivos: undefined,
    ExamenAnalistaTeoricoRango: undefined,
    ExamenAnalistaPracticoId: undefined,
    ExamenAnalistaPracticoNumeroCaso: undefined,
    ExamenAnalistaPracticoAciertos: undefined,
    ExamenAnalistaPracticoTotalReactivos: undefined,
    ExamenAnalistaPracticoRango: undefined,
    ExamenIngenieroPruebasFecha: undefined,
    ExamenIngenieroPruebasIpComputadora: undefined,
    ExamenIngenieroPruebasTeoricoId: undefined,
    ExamenIngenieroPruebasTeoricoAciertos: undefined,
    ExamenIngenieroPruebasTeoricoTotalReactivos: undefined,
    ExamenIngenieroPruebasTeoricoRango: undefined,
    ExamenIngenieroPruebasPracticoId: undefined,
    ExamenIngenieroPruebasPracticoCalificacion: undefined,
    ExamenIngenieroPruebasPracticoPuntos: undefined,
    ExamenIngenieroPruebasPracticoRango: undefined,
    ExamenIngenieroPruebasSqlTotalReactivos: undefined,
    ExamenIngenieroPruebasSqlCalificacion: undefined,
    ExamenAdministradorProyectoFecha: undefined,
    ExamenAdministradorProyectoIpComputadora: undefined,
    ExamenAdministradorProyectoId: undefined,
    ExamenAdministradorProyectoAciertos: undefined,
    ExamenAdministradorProyectoTotalReactivos: undefined,
    ExamenAdministradorProyectoRango: undefined,
    ExamenPracticoSoporteBdFecha: undefined,
    ExamenPracticoSoporteBdAciertos: undefined,
    ExamenPracticoSoporteBdTotalReactivos: undefined,
    ExamenPracticoSoporteBdRango: undefined,
    EntrevistaCapitalHumanoFecha: undefined,
    EntrevistaCapitalHumanoComentarios: undefined,
    EntrevistaCoordinadorYEquipoTecnicoFecha: undefined,
    EntrevistaCoordinadorYEquipoTecnicoComentarios: undefined,
    EntrevistaInglesFecha: undefined,
    EntrevistaInglesComentarios: undefined,
    EntrevistaGerenteAreaFecha: undefined,
    EntrevistaGerenteAreaComentarios: undefined,
    VeredictoFinal: undefined,
    VeredictoFinalNivelIdentificado: undefined,
    VeredictoFinalComentarios: undefined,
    PropuestaEconomicaFecha: undefined,
    PropuestaEconomicaEstatus: undefined,
    PropuestaEconomicaSueldo: undefined,
    PropuestaEconomicaComentarios: undefined,
    IngresoFecha: undefined,
    IngresoTipoContrato: undefined,
    IngresoVencimientoContratoDeterminado: undefined,
    IngresoObservaciones: undefined,
});

export const CandidatoEdit = withModelLoading(
    CandidatoEditSimple,
    getNewCandidato,
    service.getById,
    service.insert,
    service.update
);
