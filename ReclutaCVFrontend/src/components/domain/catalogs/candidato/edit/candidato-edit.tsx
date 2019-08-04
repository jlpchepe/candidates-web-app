import * as React from "react";

import { LabeledTextAreaInput, LabeledCombo } from "../../../../generic";
import { Row } from "../../../common/row";
import { LabeledTextInput, LabeledDateInput, LabeledNumberInput, LabeledStatusInput } from "../../../../generic";
import { CandidatoInsertable, CandidatoUpdatable, CandidatoConsultable } from "../../../../../communication/dtos/candidato";
import { EditCatalog } from "../../../base/edit-catalog";
import { WithModelManagementProps, withModelLoading } from "../../../../hoc/with-model-loader";
import { OperatorCombo } from "../../operator/combo/operator-combo";
import { Candidato } from "../../../../../communication/services";
import { Column } from "../../../common/column";
import { addDays } from "date-fns/esm";

const service = Candidato;

type TModelEditable = CandidatoInsertable & CandidatoUpdatable & CandidatoConsultable;

interface CandidatoEditState {
    model: TModelEditable;
    candidatoType: number;
}

const Seccion: React.FC<{title: string}> = (props) => (
    <>
        <h5>{props.title}</h5>
        {props.children}
    </>    
);

class CandidatoEditSimple extends React.Component<WithModelManagementProps<TModelEditable>, CandidatoEditState> {
    render() {
        return (
            <EditCatalog 
                title="Candidato" 
                readonly={this.props.readonly} 
                onSave={this.props.onSaveModel}
            >
                <Seccion title="Generales">
                    <Row>
                        <LabeledTextInput label="Nombre" value={this.props.model.nombre} onChange={value => this.props.setModel({ nombre: value })} readonly={this.props.readonly}/>
                        <LabeledTextInput label="Correo electrónico" value={this.props.model.correo} onChange={value => this.props.setModel({ correo: value })} readonly={this.props.readonly}/>
                        <LabeledTextInput label="Teléfono" value={this.props.model.telefono} onChange={value => this.props.setModel({ telefono: value })} readonly={this.props.readonly}/>
                    </Row>
                    <Row>
                        <LabeledTextInput label="Estado civil" value={this.props.model.estadoCivil} onChange={value => this.props.setModel({ estadoCivil: value })} readonly={this.props.readonly}/>
                        <LabeledDateInput label="Fecha de nacimiento" value={this.props.model.fechaDeNacimiento} onChange={value => this.props.setModel({ fechaDeNacimiento: value })} readonly={this.props.readonly}/>
                        <LabeledTextInput label="Lugar de nacimiento" value={this.props.model.lugarNacimiento} onChange={value => this.props.setModel({ lugarNacimiento: value })} readonly={this.props.readonly}/>
                    </Row>
                    <Row>                    
                        <LabeledTextInput label="Comentarios generales" value={this.props.model.generalesComentarios} onChange={value => this.props.setModel({ generalesComentarios: value })} readonly={this.props.readonly}/>
                        <LabeledDateInput label="Fecha de actualización" value={this.props.model.fechaDeActualizacion} onChange={value => this.props.setModel({ fechaDeActualizacion: value })} readonly={this.props.readonly}/>
                    </Row>
                </Seccion>

                <Seccion title="Experiencia laboral">
                    <Row>
                        <LabeledTextInput label="Compañía" value={this.props.model.compañia} onChange={value => this.props.setModel({ compañia: value })} readonly={this.props.readonly}/>
                        <LabeledNumberInput label="Años de experiencia" value={this.props.model.añosDeExperiencia} onChange={value => this.props.setModel({ añosDeExperiencia: value })} readonly={this.props.readonly}/>
                        <LabeledNumberInput label="Sueldo actual" value={this.props.model.sueldoActual} onChange={value => this.props.setModel({ sueldoActual: value })} readonly={this.props.readonly}/>
                    </Row>
                    <LabeledTextInput label="Motivo de separación" value={this.props.model.motivoDeSeparacion} onChange={value => this.props.setModel({ motivoDeSeparacion: value })} readonly={this.props.readonly}/>
                </Seccion>
                <Seccion title="Educación">
                    <Row>
                        <LabeledTextInput label="Carrera" value={this.props.model.carrera} onChange={value => this.props.setModel({ carrera: value })} readonly={this.props.readonly}/>
                        <LabeledTextInput label="Institución" value={this.props.model.institucion} onChange={value => this.props.setModel({ institucion: value })} readonly={this.props.readonly}/>
                        {/* estatusAcademico: EstatusAcademico; */}
                    </Row>
                    <Row>
                        <LabeledTextInput label="Cursos" value={this.props.model.cursos} onChange={value => this.props.setModel({ cursos: value })} readonly={this.props.readonly}/>
                        <LabeledTextInput label="Certificaciones" value={this.props.model.certificaciones} onChange={value => this.props.setModel({ certificaciones: value })} readonly={this.props.readonly}/>
                        <LabeledTextInput label="Competencias o habilidades" value={this.props.model.competenciasOHabilidades} onChange={value => this.props.setModel({ competenciasOHabilidades: value })} readonly={this.props.readonly}/>
                    </Row>
                    <Row>
                        <LabeledTextInput label="Tecnologías que domina" value={this.props.model.tecnologiasQueDomina} onChange={value => this.props.setModel({ tecnologiasQueDomina: value })} readonly={this.props.readonly}/>
                        <LabeledTextInput label="Software que domina" value={this.props.model.softwareQueDomina} onChange={value => this.props.setModel({ softwareQueDomina: value })} readonly={this.props.readonly}/>
                    </Row>
                </Seccion>
                <Seccion title="Inglés">
                    <Row>
                        <LabeledTextInput label="Nivel" value={this.props.model.nivelDeIngles} onChange={value => this.props.setModel({ nivelDeIngles: value })} readonly={this.props.readonly}/>
                        <LabeledNumberInput label="Hablado" value={this.props.model.nivelDeInglesHablado} onChange={value => this.props.setModel({ nivelDeInglesHablado: value })} readonly={this.props.readonly}/>
                        <LabeledNumberInput label="Escrito" value={this.props.model.nivelDeInglesEscrito} onChange={value => this.props.setModel({ nivelDeInglesEscrito: value })} readonly={this.props.readonly}/>
                        <LabeledNumberInput label="Lectura" value={this.props.model.nivelDeInglesLectura} onChange={value => this.props.setModel({ nivelDeInglesLectura: value })} readonly={this.props.readonly}/>
                    </Row>
                </Seccion>
                <Seccion title="Proceso de reclutamiento">
                    <Row>
                        <LabeledNumberInput label="Folio de solicitud de personal" value={this.props.model.solicitudPersonalFolio} onChange={value => this.props.setModel({ solicitudPersonalFolio: value })} readonly={this.props.readonly}/>
                        <LabeledNumberInput label="Clave de puesto" value={this.props.model.puestoClave} onChange={value => this.props.setModel({ puestoClave: value })} readonly={this.props.readonly}/>
                        <LabeledTextInput label="Nombre de puesto" value={this.props.model.puestoNombre} onChange={value => this.props.setModel({ puestoNombre: value })} readonly={this.props.readonly}/>
                    </Row>
                    <Row>
                        <LabeledTextInput label="Nombre de proyecto" value={this.props.model.proyectoNombre} onChange={value => this.props.setModel({ proyectoNombre: value })} readonly={this.props.readonly}/>
                        <LabeledDateInput label="Fecha de recepción de CV" value={this.props.model.fechaDeRecepcionCurriculum} onChange={value => this.props.setModel({ fechaDeRecepcionCurriculum: value })} readonly={this.props.readonly}/>
                        <LabeledDateInput label="Fecha de contacto" value={this.props.model.fechaDeContacto} onChange={value => this.props.setModel({ fechaDeContacto: value })} readonly={this.props.readonly}/>
                    </Row>
                    <Row>
                        <LabeledDateInput label="Fecha de preentrevista telefónica" value={this.props.model.fechaPreentrevistaTelefonica} onChange={value => this.props.setModel({ fechaPreentrevistaTelefonica: value })} readonly={this.props.readonly}/>
                        <LabeledDateInput label="Fecha de recepcion de solicitud de registro" value={this.props.model.fechaRecepcionSolicitudRegistro} onChange={value => this.props.setModel({ fechaRecepcionSolicitudRegistro: value })} readonly={this.props.readonly}/>
                        <LabeledTextInput label="Quién lo contactó" value={this.props.model.quienLoContacto} onChange={value => this.props.setModel({ quienLoContacto: value })} readonly={this.props.readonly}/>
                    </Row>
                    <Row>
                        {/* bolsa: BolsaTrabajo; */}
                        <LabeledTextInput label="Otra bolsa" value={this.props.model.bolsaOtra} onChange={value => this.props.setModel({ bolsaOtra: value })} readonly={this.props.readonly}/>
                        {/* rol: RolCandidato; */}
                        <LabeledTextInput label="Otro rol" value={this.props.model.rolOtro} onChange={value => this.props.setModel({ rolOtro: value })} readonly={this.props.readonly}/>
                    </Row>
                    <Row>
                        <LabeledNumberInput label="Expectativa económica" value={this.props.model.expectativaEconomica} onChange={value => this.props.setModel({ expectativaEconomica: value })} readonly={this.props.readonly}/>
                        {/* estatus: EstatusCandidato; */}
                        <LabeledTextInput label="Comentarios de reclutamiento" value={this.props.model.reclutamientoComentarios} onChange={value => this.props.setModel({ reclutamientoComentarios: value })} readonly={this.props.readonly}/>
                    </Row>            
                </Seccion>         

                <Seccion title="Examen psicométrico"> 
                    <Row>
                        <LabeledTextInput label="Nombre" value={this.props.model.examenPsicometricoNombre} onChange={value => this.props.setModel({ examenPsicometricoNombre: value })} readonly={this.props.readonly}/>
                        <LabeledTextInput label="Resultados" value={this.props.model.examenPsicometricoResultados} onChange={value => this.props.setModel({ examenPsicometricoResultados: value })} readonly={this.props.readonly}/>
                        <LabeledTextInput label="Observaciones" value={this.props.model.examenPsicometricoObservaciones} onChange={value => this.props.setModel({ examenPsicometricoObservaciones: value })} readonly={this.props.readonly}/>
                    </Row>
                </Seccion>            

                <Seccion title="Examen psicométrico"> 
                    <Row>
                        <LabeledDateInput label="Fecha" value={this.props.model.examenProgramacionFecha} onChange={value => this.props.setModel({ examenProgramacionFecha: value })} readonly={this.props.readonly}/>
                        <LabeledTextInput label="IP de computadora" value={this.props.model.examenProgramacionIpComputadora} onChange={value => this.props.setModel({ examenProgramacionIpComputadora: value })} readonly={this.props.readonly}/>
                        <LabeledTextInput label="ID" value={this.props.model.examenProgramacionId} onChange={value => this.props.setModel({ examenProgramacionId: value })} readonly={this.props.readonly}/>
                    </Row>
                </Seccion> 
                <Seccion title="Examen de programación"> 
                    <Row>
                    </Row>
                    
                </Seccion> 

                {/* // examen de programación */}
                <LabeledNumberInput label="ExamenProgramacionUmlCalificacion" value={this.props.model.examenProgramacionUmlCalificacion} onChange={value => this.props.setModel({ examenProgramacionUmlCalificacion: value })} readonly={this.props.readonly}/>
                <LabeledNumberInput label="ExamenProgramacionUmlTotalReactivos" value={this.props.model.examenProgramacionUmlTotalReactivos} onChange={value => this.props.setModel({ examenProgramacionUmlTotalReactivos: value })} readonly={this.props.readonly}/>
                <LabeledNumberInput label="ExamenProgramacionAdooCalificacion" value={this.props.model.examenProgramacionAdooCalificacion} onChange={value => this.props.setModel({ examenProgramacionAdooCalificacion: value })} readonly={this.props.readonly}/>
                <LabeledNumberInput label="ExamenProgramacionAdooTotalReactivos" value={this.props.model.examenProgramacionAdooTotalReactivos} onChange={value => this.props.setModel({ examenProgramacionAdooTotalReactivos: value })} readonly={this.props.readonly}/>
                <LabeledNumberInput label="ExamenProgramacionPooCalificacion" value={this.props.model.examenProgramacionPooCalificacion} onChange={value => this.props.setModel({ examenProgramacionPooCalificacion: value })} readonly={this.props.readonly}/>
                <LabeledNumberInput label="ExamenProgramacionPooTotalReactivos" value={this.props.model.examenProgramacionPooTotalReactivos} onChange={value => this.props.setModel({ examenProgramacionPooTotalReactivos: value })} readonly={this.props.readonly}/>
                <LabeledNumberInput label="ExamenProgramacionLogicaCalificacion" value={this.props.model.examenProgramacionLogicaCalificacion} onChange={value => this.props.setModel({ examenProgramacionLogicaCalificacion: value })} readonly={this.props.readonly}/>
                <LabeledNumberInput label="ExamenProgramacionLogicaTotalReactivos" value={this.props.model.examenProgramacionLogicaTotalReactivos} onChange={value => this.props.setModel({ examenProgramacionLogicaTotalReactivos: value })} readonly={this.props.readonly}/>
                <LabeledNumberInput label="ExamenProgramacionWebCalificacion" value={this.props.model.examenProgramacionWebCalificacion} onChange={value => this.props.setModel({ examenProgramacionWebCalificacion: value })} readonly={this.props.readonly}/>
                <LabeledNumberInput label="ExamenProgramacionWebTotalReactivos" value={this.props.model.examenProgramacionWebTotalReactivos} onChange={value => this.props.setModel({ examenProgramacionWebTotalReactivos: value })} readonly={this.props.readonly}/>
                <LabeledNumberInput label="ExamenProgramacionJavascriptCalificacion" value={this.props.model.examenProgramacionJavascriptCalificacion} onChange={value => this.props.setModel({ examenProgramacionJavascriptCalificacion: value })} readonly={this.props.readonly}/>
                <LabeledNumberInput label="ExamenProgramacionJavascriptTotalReactivos" value={this.props.model.examenProgramacionJavascriptTotalReactivos} onChange={value => this.props.setModel({ examenProgramacionJavascriptTotalReactivos: value })} readonly={this.props.readonly}/>
                <LabeledNumberInput label="ExamenProgramacionScrumCalificacion" value={this.props.model.examenProgramacionScrumCalificacion} onChange={value => this.props.setModel({ examenProgramacionScrumCalificacion: value })} readonly={this.props.readonly}/>
                <LabeledNumberInput label="ExamenProgramacionScrumTotalReactivos" value={this.props.model.examenProgramacionScrumTotalReactivos} onChange={value => this.props.setModel({ examenProgramacionScrumTotalReactivos: value })} readonly={this.props.readonly}/>
                <LabeledNumberInput label="ExamenProgramacionTecnologiaCalificacion" value={this.props.model.examenProgramacionTecnologiaCalificacion} onChange={value => this.props.setModel({ examenProgramacionTecnologiaCalificacion: value })} readonly={this.props.readonly}/>
                <LabeledNumberInput label="ExamenProgramacionTecnologiaTotalReactivos" value={this.props.model.examenProgramacionTecnologiaTotalReactivos} onChange={value => this.props.setModel({ examenProgramacionTecnologiaTotalReactivos: value })} readonly={this.props.readonly}/>
                <LabeledNumberInput label="ExamenProgramacionAciertos" value={this.props.model.examenProgramacionAciertos} onChange={value => this.props.setModel({ examenProgramacionAciertos: value })} readonly={this.props.readonly}/>
                <LabeledNumberInput label="ExamenProgramacionTotalReactivos" value={this.props.model.examenProgramacionTotalReactivos} onChange={value => this.props.setModel({ examenProgramacionTotalReactivos: value })} readonly={this.props.readonly}/>
                <LabeledTextInput label="ExamenProgramacionRango" value={this.props.model.examenProgramacionRango} onChange={value => this.props.setModel({ examenProgramacionRango: value })} readonly={this.props.readonly}/>

                {/* // examen de analista */}
                <LabeledDateInput label="ExamenAnalistaFecha" value={this.props.model.examenAnalistaFecha} onChange={value => this.props.setModel({ examenAnalistaFecha: value })} readonly={this.props.readonly}/>
                <LabeledTextInput label="ExamenAnalistaIpComputadora" value={this.props.model.examenAnalistaIpComputadora} onChange={value => this.props.setModel({ examenAnalistaIpComputadora: value })} readonly={this.props.readonly}/>
                {/* // Teórico */}
                <LabeledTextInput label="ExamenAnalistaTeoricoId" value={this.props.model.examenAnalistaTeoricoId} onChange={value => this.props.setModel({ examenAnalistaTeoricoId: value })} readonly={this.props.readonly}/>
                <LabeledNumberInput label="ExamenAnalistaTeoricoAciertos" value={this.props.model.examenAnalistaTeoricoAciertos} onChange={value => this.props.setModel({ examenAnalistaTeoricoAciertos: value })} readonly={this.props.readonly}/>
                <LabeledNumberInput label="ExamenAnalistaTeoricoTotalReactivos" value={this.props.model.examenAnalistaTeoricoTotalReactivos} onChange={value => this.props.setModel({ examenAnalistaTeoricoTotalReactivos: value })} readonly={this.props.readonly}/>
                <LabeledTextInput label="ExamenAnalistaTeoricoRango" value={this.props.model.examenAnalistaTeoricoRango} onChange={value => this.props.setModel({ examenAnalistaTeoricoRango: value })} readonly={this.props.readonly}/>
                {/* // Práctico */}
                <LabeledTextInput label="ExamenAnalistaPracticoId" value={this.props.model.examenAnalistaPracticoId} onChange={value => this.props.setModel({ examenAnalistaPracticoId: value })} readonly={this.props.readonly}/>
                <LabeledNumberInput label="ExamenAnalistaPracticoNumeroCaso" value={this.props.model.examenAnalistaPracticoNumeroCaso} onChange={value => this.props.setModel({ examenAnalistaPracticoNumeroCaso: value })} readonly={this.props.readonly}/>
                <LabeledNumberInput label="ExamenAnalistaPracticoAciertos" value={this.props.model.examenAnalistaPracticoAciertos} onChange={value => this.props.setModel({ examenAnalistaPracticoAciertos: value })} readonly={this.props.readonly}/>
                <LabeledNumberInput label="ExamenAnalistaPracticoTotalReactivos" value={this.props.model.examenAnalistaPracticoTotalReactivos} onChange={value => this.props.setModel({ examenAnalistaPracticoTotalReactivos: value })} readonly={this.props.readonly}/>
                <LabeledTextInput label="ExamenAnalistaPracticoRango" value={this.props.model.examenAnalistaPracticoRango} onChange={value => this.props.setModel({ examenAnalistaPracticoRango: value })} readonly={this.props.readonly}/>

                {/* // examen de ingeniero de pruebas */}
                <LabeledDateInput label="ExamenIngenieroPruebasFecha" value={this.props.model.examenIngenieroPruebasFecha} onChange={value => this.props.setModel({ examenIngenieroPruebasFecha: value })} readonly={this.props.readonly}/>
                <LabeledTextInput label="ExamenIngenieroPruebasIpComputadora" value={this.props.model.examenIngenieroPruebasIpComputadora} onChange={value => this.props.setModel({ examenIngenieroPruebasIpComputadora: value })} readonly={this.props.readonly}/>
                {/* // Teórico */}
                <LabeledNumberInput label="ExamenIngenieroPruebasTeoricoId" value={this.props.model.examenIngenieroPruebasTeoricoId} onChange={value => this.props.setModel({ examenIngenieroPruebasTeoricoId: value })} readonly={this.props.readonly}/>
                <LabeledNumberInput label="ExamenIngenieroPruebasTeoricoAciertos" value={this.props.model.examenIngenieroPruebasTeoricoAciertos} onChange={value => this.props.setModel({ examenIngenieroPruebasTeoricoAciertos: value })} readonly={this.props.readonly}/>
                <LabeledNumberInput label="ExamenIngenieroPruebasTeoricoTotalReactivos" value={this.props.model.examenIngenieroPruebasTeoricoTotalReactivos} onChange={value => this.props.setModel({ examenIngenieroPruebasTeoricoTotalReactivos: value })} readonly={this.props.readonly}/>
                <LabeledTextInput label="ExamenIngenieroPruebasTeoricoRango" value={this.props.model.examenIngenieroPruebasTeoricoRango} onChange={value => this.props.setModel({ examenIngenieroPruebasTeoricoRango: value })} readonly={this.props.readonly}/>
                {/* // Práctico */}
                <LabeledNumberInput label="ExamenIngenieroPruebasPracticoId" value={this.props.model.examenIngenieroPruebasPracticoId} onChange={value => this.props.setModel({ examenIngenieroPruebasPracticoId: value })} readonly={this.props.readonly}/>
                <LabeledNumberInput label="ExamenIngenieroPruebasPracticoCalificacion" value={this.props.model.examenIngenieroPruebasPracticoCalificacion} onChange={value => this.props.setModel({ examenIngenieroPruebasPracticoCalificacion: value })} readonly={this.props.readonly}/>
                <LabeledNumberInput label="ExamenIngenieroPruebasPracticoPuntos" value={this.props.model.examenIngenieroPruebasPracticoPuntos} onChange={value => this.props.setModel({ examenIngenieroPruebasPracticoPuntos: value })} readonly={this.props.readonly}/>
                <LabeledTextInput label="ExamenIngenieroPruebasPracticoRango" value={this.props.model.examenIngenieroPruebasPracticoRango} onChange={value => this.props.setModel({ examenIngenieroPruebasPracticoRango: value })} readonly={this.props.readonly}/>
                {/* // SQL */}
                <LabeledNumberInput label="ExamenIngenieroPruebasSqlTotalReactivos" value={this.props.model.examenIngenieroPruebasSqlTotalReactivos} onChange={value => this.props.setModel({ examenIngenieroPruebasSqlTotalReactivos: value })} readonly={this.props.readonly}/>
                <LabeledNumberInput label="ExamenIngenieroPruebasSqlCalificacion" value={this.props.model.examenIngenieroPruebasSqlCalificacion} onChange={value => this.props.setModel({ examenIngenieroPruebasSqlCalificacion: value })} readonly={this.props.readonly}/>

                {/* // examen de administrador de proyectos */}
                <LabeledDateInput label="ExamenAdministradorProyectoFecha" value={this.props.model.examenAdministradorProyectoFecha} onChange={value => this.props.setModel({ examenAdministradorProyectoFecha: value })} readonly={this.props.readonly}/>
                <LabeledTextInput label="ExamenAdministradorProyectoIpComputadora" value={this.props.model.examenAdministradorProyectoIpComputadora} onChange={value => this.props.setModel({ examenAdministradorProyectoIpComputadora: value })} readonly={this.props.readonly}/>
                <LabeledNumberInput label="ExamenAdministradorProyectoId" value={this.props.model.examenAdministradorProyectoId} onChange={value => this.props.setModel({ examenAdministradorProyectoId: value })} readonly={this.props.readonly}/>
                <LabeledNumberInput label="ExamenAdministradorProyectoAciertos" value={this.props.model.examenAdministradorProyectoAciertos} onChange={value => this.props.setModel({ examenAdministradorProyectoAciertos: value })} readonly={this.props.readonly}/>
                <LabeledNumberInput label="ExamenAdministradorProyectoTotalReactivos" value={this.props.model.examenAdministradorProyectoTotalReactivos} onChange={value => this.props.setModel({ examenAdministradorProyectoTotalReactivos: value })} readonly={this.props.readonly}/>
                <LabeledTextInput label="ExamenAdministradorProyectoRango" value={this.props.model.examenAdministradorProyectoRango} onChange={value => this.props.setModel({ examenAdministradorProyectoRango: value })} readonly={this.props.readonly}/>

                {/* // examen de soporte - BD */}
                <LabeledDateInput label="ExamenPracticoSoporteBdFecha" value={this.props.model.examenPracticoSoporteBdFecha} onChange={value => this.props.setModel({ examenPracticoSoporteBdFecha: value })} readonly={this.props.readonly}/>
                <LabeledNumberInput label="ExamenPracticoSoporteBdAciertos" value={this.props.model.examenPracticoSoporteBdAciertos} onChange={value => this.props.setModel({ examenPracticoSoporteBdAciertos: value })} readonly={this.props.readonly}/>
                <LabeledNumberInput label="ExamenPracticoSoporteBdTotalReactivos" value={this.props.model.examenPracticoSoporteBdTotalReactivos} onChange={value => this.props.setModel({ examenPracticoSoporteBdTotalReactivos: value })} readonly={this.props.readonly}/>
                <LabeledTextInput label="ExamenPracticoSoporteBdRango" value={this.props.model.examenPracticoSoporteBdRango} onChange={value => this.props.setModel({ examenPracticoSoporteBdRango: value })} readonly={this.props.readonly}/>

                {/* // Etapa de entrevistas */}
                <LabeledDateInput label="EntrevistaCapitalHumanoFecha" value={this.props.model.entrevistaCapitalHumanoFecha} onChange={value => this.props.setModel({ entrevistaCapitalHumanoFecha: value })} readonly={this.props.readonly}/>
                <LabeledTextInput label="EntrevistaCapitalHumanoComentarios" value={this.props.model.entrevistaCapitalHumanoComentarios} onChange={value => this.props.setModel({ entrevistaCapitalHumanoComentarios: value })} readonly={this.props.readonly}/>
                <LabeledDateInput label="EntrevistaCoordinadorYEquipoTecnicoFecha" value={this.props.model.entrevistaCoordinadorYEquipoTecnicoFecha} onChange={value => this.props.setModel({ entrevistaCoordinadorYEquipoTecnicoFecha: value })} readonly={this.props.readonly}/>
                <LabeledTextInput label="EntrevistaCoordinadorYEquipoTecnicoComentarios" value={this.props.model.entrevistaCoordinadorYEquipoTecnicoComentarios} onChange={value => this.props.setModel({ entrevistaCoordinadorYEquipoTecnicoComentarios: value })} readonly={this.props.readonly}/>
                <LabeledDateInput label="EntrevistaInglesFecha" value={this.props.model.entrevistaInglesFecha} onChange={value => this.props.setModel({ entrevistaInglesFecha: value })} readonly={this.props.readonly}/>
                <LabeledTextInput label="EntrevistaInglesComentarios" value={this.props.model.entrevistaInglesComentarios} onChange={value => this.props.setModel({ entrevistaInglesComentarios: value })} readonly={this.props.readonly}/>
                <LabeledDateInput label="EntrevistaGerenteAreaFecha" value={this.props.model.entrevistaGerenteAreaFecha} onChange={value => this.props.setModel({ entrevistaGerenteAreaFecha: value })} readonly={this.props.readonly}/>
                <LabeledTextInput label="EntrevistaGerenteAreaComentarios" value={this.props.model.entrevistaGerenteAreaComentarios} onChange={value => this.props.setModel({ entrevistaGerenteAreaComentarios: value })} readonly={this.props.readonly}/>
                {/* veredictoFinal: VeredictoFinalCandidato; */}
                <LabeledTextInput label="VeredictoFinalNivelIdentificado" value={this.props.model.veredictoFinalNivelIdentificado} onChange={value => this.props.setModel({ veredictoFinalNivelIdentificado: value })} readonly={this.props.readonly}/>
                <LabeledTextInput label="VeredictoFinalComentarios" value={this.props.model.veredictoFinalComentarios} onChange={value => this.props.setModel({ veredictoFinalComentarios: value })} readonly={this.props.readonly}/>

                {/* // Propuesta económica */}
                <LabeledDateInput label="PropuestaEconomicaFecha" value={this.props.model.propuestaEconomicaFecha} onChange={value => this.props.setModel({ propuestaEconomicaFecha: value })} readonly={this.props.readonly}/>
                {/* propuestaEconomicaEstatus: PropuestaEconomicaEstatus; */}
                <LabeledNumberInput label="PropuestaEconomicaSueldo" value={this.props.model.propuestaEconomicaSueldo} onChange={value => this.props.setModel({ propuestaEconomicaSueldo: value })} readonly={this.props.readonly}/>
                <LabeledTextInput label="PropuestaEconomicaComentarios" value={this.props.model.propuestaEconomicaComentarios} onChange={value => this.props.setModel({ propuestaEconomicaComentarios: value })} readonly={this.props.readonly}/>

                {/* // Ingreso */}
                <LabeledDateInput label="IngresoFecha" value={this.props.model.ingresoFecha} onChange={value => this.props.setModel({ ingresoFecha: value })} readonly={this.props.readonly}/>
                <LabeledTextInput label="IngresoTipoContrato" value={this.props.model.ingresoTipoContrato} onChange={value => this.props.setModel({ ingresoTipoContrato: value })} readonly={this.props.readonly}/>
                <LabeledDateInput label="IngresoVencimientoContratoDeterminado" value={this.props.model.ingresoVencimientoContratoDeterminado} onChange={value => this.props.setModel({ ingresoVencimientoContratoDeterminado: value })} readonly={this.props.readonly}/>
                <LabeledTextInput label="IngresoObservaciones" value={this.props.model.ingresoObservaciones} onChange={value => this.props.setModel({ ingresoObservaciones: value })} readonly={this.props.readonly}/>
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
