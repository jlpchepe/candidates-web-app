import { MotivoSolicitud, AreaDelSolicitante, TipoDeContrato, EstatusSolicitud } from "../enums/solicitud-vacante-enums";
import { RolCandidato, NivelCandidato } from "../enums/candidato";

export interface SolicitudVacanteInsertable extends SolicitudVacanteConsultable {
}

export interface SolicitudVacanteUpdatable extends SolicitudVacanteConsultable {
}

export interface SolicitudVacanteListable extends SolicitudVacanteConsultable {
}

export interface SolicitudVacanteConsultable {
    id: number;
    folioCapitalHumano: number;
    fechaDeSolicitud: Date;
    motivo: MotivoSolicitud;
    especifiqueMotivo: string;
    nombreDelSolicitante: string;
    puestoDelSolicitante: string;
    areaDelSolicitante: AreaDelSolicitante;
    especifiqueAreaDelSolicitante: string;
    sueldo: number | null;
    tipoDeContrato: TipoDeContrato;
    especifiqueTipoDeContrato: string;
    estatus: EstatusSolicitud;
    puestoSolicitado: RolCandidato;
    especifiquePuestoSolicitado: string;
    puestoSolicitadoNivel: NivelCandidato | null;
    nombreDelJefeInmediato: string;
    proyecto: string;
    nivelIdiomaIngles: number | null;
    edadRango: string;
    estadoCivil: string;
    fechaEstimadaDeIngreso: Date | null;
    experienciaLaboral: string;
    competenciasOHabilidades: string;
    certificacionesNecesarias: string;
    tipoDeEvaluacion: string;
    observaciones: string;
}