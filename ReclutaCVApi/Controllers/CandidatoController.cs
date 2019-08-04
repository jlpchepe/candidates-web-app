using System.Threading.Tasks;
using ReclutaCVApi.Attributes;
using ReclutaCVApi.Dtos;
using AppPersistence.Dtos;
using Microsoft.AspNetCore.Mvc;
using LogicDtos = AppPersistence.Dtos;
using ReclutaCVLogic.Servicios;
using ReclutaCVData.Entidades;
using AppPersistence.Extensions;

namespace ReclutaCVApi.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class CandidatoController
    {
        public CandidatoController(
            CandidatoService service
        )
        {
            this.service = service;
        }

        private readonly CandidatoService service;

        [HttpGet]
        public async Task<Page<CandidatoConsultable>> Get(
           [MinRequired(0)] int pageNumber,
           [MinRequired(0)] ushort pageSize,
           [FromQuery] string nombre
        )
        {
            return (await service.FindAll(pageNumber, pageSize, nombre))
                .Select(ToConsultable);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<CandidatoConsultable>> Get(
            int id
        )
        {
            return ToConsultable(await service.FindById(id));
        }

        [HttpPost]
        public Task Post([FromBody] CandidatoInsertable model)
        {
            return service.Insert(
                ToCandidato(null, model)
            );
        }

        [HttpPut]
        public Task Put([FromBody] CandidatoUpdatable model)
        {
            return service.Update(
                ToCandidato(model.Id, model)
            );
        }

        [HttpDelete("{id}")]
        public Task Delete(int id) => service.Delete(id);

        private CandidatoConsultable ToConsultable(Candidato model)
        {
            return new CandidatoConsultable(
                model.Id,
                model.Nombre,
                model.Correo,
                model.Telefono,
                model.FechaDeNacimiento,
                model.EstadoCivil,
                model.LugarNacimiento,
                model.GeneralesComentarios,
                model.FechaDeActualizacion,
                model.Compañia,
                model.AñosDeExperiencia,
                model.SueldoActual,
                model.MotivoDeSeparacion,
                model.Carrera,
                model.Institucion,
                model.EstatusAcademico,
                model.Cursos,
                model.Certificaciones,
                model.CompetenciasOHabilidades,
                model.TecnologiasQueDomina,
                model.SoftwareQueDomina,
                model.NivelDeIngles,
                model.NivelDeInglesHablado,
                model.NivelDeInglesEscrito,
                model.NivelDeInglesLectura,
                model.SolicitudPersonalFolio,
                model.PuestoClave,
                model.PuestoNombre,
                model.ProyectoNombre,
                model.FechaDeRecepcionCurriculum,
                model.FechaDeContacto,
                model.FechaPreentrevistaTelefonica,
                model.FechaRecepcionSolicitudRegistro,
                model.QuienLoContacto,
                model.Bolsa,
                model.BolsaOtra,
                model.Rol,
                model.RolOtro,
                model.ExpectativaEconomica,
                model.Estatus,
                model.ReclutamientoComentarios,
                model.ExamenPsicometricoNombre,
                model.ExamenPsicometricoResultados,
                model.ExamenPsicometricoObservaciones,
                model.ExamenProgramacionFecha,
                model.ExamenProgramacionIpComputadora,
                model.ExamenProgramacionId,
                model.ExamenProgramacionUmlCalificacion,
                model.ExamenProgramacionUmlTotalReactivos,
                model.ExamenProgramacionAdooCalificacion,
                model.ExamenProgramacionAdooTotalReactivos,
                model.ExamenProgramacionPooCalificacion,
                model.ExamenProgramacionPooTotalReactivos,
                model.ExamenProgramacionLogicaCalificacion,
                model.ExamenProgramacionLogicaTotalReactivos,
                model.ExamenProgramacionWebCalificacion,
                model.ExamenProgramacionWebTotalReactivos,
                model.ExamenProgramacionJavascriptCalificacion,
                model.ExamenProgramacionJavascriptTotalReactivos,
                model.ExamenProgramacionScrumCalificacion,
                model.ExamenProgramacionScrumTotalReactivos,
                model.ExamenProgramacionTecnologiaCalificacion,
                model.ExamenProgramacionTecnologiaTotalReactivos,
                model.ExamenProgramacionAciertos,
                model.ExamenProgramacionTotalReactivos,
                model.ExamenProgramacionRango,
                model.ExamenAnalistaFecha,
                model.ExamenAnalistaIpComputadora,
                model.ExamenAnalistaTeoricoId,
                model.ExamenAnalistaTeoricoAciertos,
                model.ExamenAnalistaTeoricoTotalReactivos,
                model.ExamenAnalistaTeoricoRango,
                model.ExamenAnalistaPracticoId,
                model.ExamenAnalistaPracticoNumeroCaso,
                model.ExamenAnalistaPracticoAciertos,
                model.ExamenAnalistaPracticoTotalReactivos,
                model.ExamenAnalistaPracticoRango,
                model.ExamenIngenieroPruebasFecha,
                model.ExamenIngenieroPruebasIpComputadora,
                model.ExamenIngenieroPruebasTeoricoId,
                model.ExamenIngenieroPruebasTeoricoAciertos,
                model.ExamenIngenieroPruebasTeoricoTotalReactivos,
                model.ExamenIngenieroPruebasTeoricoRango,
                model.ExamenIngenieroPruebasPracticoId,
                model.ExamenIngenieroPruebasPracticoCalificacion,
                model.ExamenIngenieroPruebasPracticoPuntos,
                model.ExamenIngenieroPruebasPracticoRango,
                model.ExamenIngenieroPruebasSqlTotalReactivos,
                model.ExamenIngenieroPruebasSqlCalificacion,
                model.ExamenAdministradorProyectoFecha,
                model.ExamenAdministradorProyectoIpComputadora,
                model.ExamenAdministradorProyectoId,
                model.ExamenAdministradorProyectoAciertos,
                model.ExamenAdministradorProyectoTotalReactivos,
                model.ExamenAdministradorProyectoRango,
                model.ExamenPracticoSoporteBdFecha,
                model.ExamenPracticoSoporteBdAciertos,
                model.ExamenPracticoSoporteBdTotalReactivos,
                model.ExamenPracticoSoporteBdRango,
                model.EntrevistaCapitalHumanoFecha,
                model.EntrevistaCapitalHumanoComentarios,
                model.EntrevistaCoordinadorYEquipoTecnicoFecha,
                model.EntrevistaCoordinadorYEquipoTecnicoComentarios,
                model.EntrevistaInglesFecha,
                model.EntrevistaInglesComentarios,
                model.EntrevistaGerenteAreaFecha,
                model.EntrevistaGerenteAreaComentarios,
                model.VeredictoFinal,
                model.VeredictoFinalNivelIdentificado,
                model.VeredictoFinalComentarios,
                model.PropuestaEconomicaFecha,
                model.PropuestaEconomicaEstatus,
                model.PropuestaEconomicaSueldo,
                model.PropuestaEconomicaComentarios,
                model.IngresoFecha,
                model.IngresoTipoContrato,
                model.IngresoVencimientoContratoDeterminado,
                model.IngresoObservaciones
            );
        }

        private Candidato ToCandidato(
            int? id,
            CandidatoConsultable model
        ) =>
            new Candidato(
                model.Id,
                model.Nombre,
                model.Correo,
                model.Telefono,
                model.FechaDeNacimiento,
                model.EstadoCivil,
                model.LugarNacimiento,
                model.GeneralesComentarios,
                model.FechaDeActualizacion,
                model.Compañia,
                model.AñosDeExperiencia,
                model.SueldoActual,
                model.MotivoDeSeparacion,
                model.Carrera,
                model.Institucion,
                model.EstatusAcademico,
                model.Cursos,
                model.Certificaciones,
                model.CompetenciasOHabilidades,
                model.TecnologiasQueDomina,
                model.SoftwareQueDomina,
                model.NivelDeIngles,
                model.NivelDeInglesHablado,
                model.NivelDeInglesEscrito,
                model.NivelDeInglesLectura,
                model.SolicitudPersonalFolio,
                model.PuestoClave,
                model.PuestoNombre,
                model.ProyectoNombre,
                model.FechaDeRecepcionCurriculum,
                model.FechaDeContacto,
                model.FechaPreentrevistaTelefonica,
                model.FechaRecepcionSolicitudRegistro,
                model.QuienLoContacto,
                model.Bolsa,
                model.BolsaOtra,
                model.Rol,
                model.RolOtro,
                model.ExpectativaEconomica,
                model.Estatus,
                model.ReclutamientoComentarios,
                model.ExamenPsicometricoNombre,
                model.ExamenPsicometricoResultados,
                model.ExamenPsicometricoObservaciones,
                model.ExamenProgramacionFecha,
                model.ExamenProgramacionIpComputadora,
                model.ExamenProgramacionId,
                model.ExamenProgramacionUmlCalificacion,
                model.ExamenProgramacionUmlTotalReactivos,
                model.ExamenProgramacionAdooCalificacion,
                model.ExamenProgramacionAdooTotalReactivos,
                model.ExamenProgramacionPooCalificacion,
                model.ExamenProgramacionPooTotalReactivos,
                model.ExamenProgramacionLogicaCalificacion,
                model.ExamenProgramacionLogicaTotalReactivos,
                model.ExamenProgramacionWebCalificacion,
                model.ExamenProgramacionWebTotalReactivos,
                model.ExamenProgramacionJavascriptCalificacion,
                model.ExamenProgramacionJavascriptTotalReactivos,
                model.ExamenProgramacionScrumCalificacion,
                model.ExamenProgramacionScrumTotalReactivos,
                model.ExamenProgramacionTecnologiaCalificacion,
                model.ExamenProgramacionTecnologiaTotalReactivos,
                model.ExamenProgramacionAciertos,
                model.ExamenProgramacionTotalReactivos,
                model.ExamenProgramacionRango,
                model.ExamenAnalistaFecha,
                model.ExamenAnalistaIpComputadora,
                model.ExamenAnalistaTeoricoId,
                model.ExamenAnalistaTeoricoAciertos,
                model.ExamenAnalistaTeoricoTotalReactivos,
                model.ExamenAnalistaTeoricoRango,
                model.ExamenAnalistaPracticoId,
                model.ExamenAnalistaPracticoNumeroCaso,
                model.ExamenAnalistaPracticoAciertos,
                model.ExamenAnalistaPracticoTotalReactivos,
                model.ExamenAnalistaPracticoRango,
                model.ExamenIngenieroPruebasFecha,
                model.ExamenIngenieroPruebasIpComputadora,
                model.ExamenIngenieroPruebasTeoricoId,
                model.ExamenIngenieroPruebasTeoricoAciertos,
                model.ExamenIngenieroPruebasTeoricoTotalReactivos,
                model.ExamenIngenieroPruebasTeoricoRango,
                model.ExamenIngenieroPruebasPracticoId,
                model.ExamenIngenieroPruebasPracticoCalificacion,
                model.ExamenIngenieroPruebasPracticoPuntos,
                model.ExamenIngenieroPruebasPracticoRango,
                model.ExamenIngenieroPruebasSqlTotalReactivos,
                model.ExamenIngenieroPruebasSqlCalificacion,
                model.ExamenAdministradorProyectoFecha,
                model.ExamenAdministradorProyectoIpComputadora,
                model.ExamenAdministradorProyectoId,
                model.ExamenAdministradorProyectoAciertos,
                model.ExamenAdministradorProyectoTotalReactivos,
                model.ExamenAdministradorProyectoRango,
                model.ExamenPracticoSoporteBdFecha,
                model.ExamenPracticoSoporteBdAciertos,
                model.ExamenPracticoSoporteBdTotalReactivos,
                model.ExamenPracticoSoporteBdRango,
                model.EntrevistaCapitalHumanoFecha,
                model.EntrevistaCapitalHumanoComentarios,
                model.EntrevistaCoordinadorYEquipoTecnicoFecha,
                model.EntrevistaCoordinadorYEquipoTecnicoComentarios,
                model.EntrevistaInglesFecha,
                model.EntrevistaInglesComentarios,
                model.EntrevistaGerenteAreaFecha,
                model.EntrevistaGerenteAreaComentarios,
                model.VeredictoFinal,
                model.VeredictoFinalNivelIdentificado,
                model.VeredictoFinalComentarios,
                model.PropuestaEconomicaFecha,
                model.PropuestaEconomicaEstatus,
                model.PropuestaEconomicaSueldo,
                model.PropuestaEconomicaComentarios,
                model.IngresoFecha,
                model.IngresoTipoContrato,
                model.IngresoVencimientoContratoDeterminado,
                model.IngresoObservaciones
            );
    }
}