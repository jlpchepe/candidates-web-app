using System.Threading.Tasks;
using ReclutaCVApi.Attributes;
using ReclutaCVApi.Dtos;
using AppPersistence.Dtos;
using Microsoft.AspNetCore.Mvc;
using LogicDtos = AppPersistence.Dtos;
using ReclutaCVLogic.Servicios;
using ReclutaCVData.Entidades;
using AppPersistence.Extensions;
using System;
using System.Linq.Expressions;
using ReclutaCVLogic.Dtos;

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
            return (await service.FindAll(GetToConsultableExpression(false), pageNumber, pageSize, nombre));
        }

        [HttpGet("{id}")]
        public Task<CandidatoConsultable> Get(
            int id
        ) => service.FindById(id, GetToConsultableExpression(true));
    
        [HttpPut("curriculum")]
        public Task Put([FromBody] CandidatoCurriculumToSave model)
        {
            return service.SaveCurriculum(
                model.CandidatoId,
                model.Curriculum,
                model.CurriculumFileName
            );
        }

        [HttpPost]
        public Task<int> Post([FromBody] CandidatoInsertable model)
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

        private Expression<Func<Candidato, CandidatoConsultable>> GetToConsultableExpression(bool includeCurriculumFile) {
            return model =>
            new CandidatoConsultable
            {
                Id = model.Id,
                Nombre = model.Nombre,
                Correo = model.Correo,
                Telefono = model.Telefono,
                FechaDeNacimiento = model.FechaDeNacimiento,
                EstadoCivil = model.EstadoCivil,
                LugarNacimiento = model.LugarNacimiento,
                GeneralesComentarios = model.GeneralesComentarios,
                FechaDeActualizacion = model.FechaDeActualizacion,
                Compañia = model.Compañia,
                AñosDeExperiencia = model.AñosDeExperiencia,
                SueldoActual = model.SueldoActual,
                MotivoDeSeparacion = model.MotivoDeSeparacion,
                Carrera = model.Carrera,
                Institucion = model.Institucion,
                EstatusAcademico = model.EstatusAcademico,
                Cursos = model.Cursos,
                Certificaciones = model.Certificaciones,
                CompetenciasOHabilidades = model.CompetenciasOHabilidades,
                TecnologiasQueDomina = model.TecnologiasQueDomina,
                SoftwareQueDomina = model.SoftwareQueDomina,
                NivelDeIngles = model.NivelDeIngles,
                NivelDeInglesHablado = model.NivelDeInglesHablado,
                NivelDeInglesEscrito = model.NivelDeInglesEscrito,
                NivelDeInglesLectura = model.NivelDeInglesLectura,
                SolicitudPersonalFolio = model.SolicitudPersonalFolio,
                PuestoClave = model.PuestoClave,
                PuestoNombre = model.PuestoNombre,
                ProyectoNombre = model.ProyectoNombre,
                FechaDeRecepcionCurriculum = model.FechaDeRecepcionCurriculum,
                FechaDeContacto = model.FechaDeContacto,
                FechaPreentrevistaTelefonica = model.FechaPreentrevistaTelefonica,
                FechaRecepcionSolicitudRegistro = model.FechaRecepcionSolicitudRegistro,
                QuienLoContacto = model.QuienLoContacto,
                Bolsa = model.Bolsa,
                BolsaOtra = model.BolsaOtra,
                Rol = model.Rol,
                RolOtro = model.RolOtro,
                ExpectativaEconomica = model.ExpectativaEconomica,
                Estatus = model.Estatus,
                ReclutamientoComentarios = model.ReclutamientoComentarios,
                ExamenPsicometricoNombre = model.ExamenPsicometricoNombre,
                ExamenPsicometricoResultados = model.ExamenPsicometricoResultados,
                ExamenPsicometricoObservaciones = model.ExamenPsicometricoObservaciones,
                ExamenProgramacionFecha = model.ExamenProgramacionFecha,
                ExamenProgramacionIpComputadora = model.ExamenProgramacionIpComputadora,
                ExamenProgramacionId = model.ExamenProgramacionId,
                ExamenProgramacionUmlCalificacion = model.ExamenProgramacionUmlCalificacion,
                ExamenProgramacionUmlTotalReactivos = model.ExamenProgramacionUmlTotalReactivos,
                ExamenProgramacionAdooCalificacion = model.ExamenProgramacionAdooCalificacion,
                ExamenProgramacionAdooTotalReactivos = model.ExamenProgramacionAdooTotalReactivos,
                ExamenProgramacionPooCalificacion = model.ExamenProgramacionPooCalificacion,
                ExamenProgramacionPooTotalReactivos = model.ExamenProgramacionPooTotalReactivos,
                ExamenProgramacionLogicaCalificacion = model.ExamenProgramacionLogicaCalificacion,
                ExamenProgramacionLogicaTotalReactivos = model.ExamenProgramacionLogicaTotalReactivos,
                ExamenProgramacionWebCalificacion = model.ExamenProgramacionWebCalificacion,
                ExamenProgramacionWebTotalReactivos = model.ExamenProgramacionWebTotalReactivos,
                ExamenProgramacionJavascriptCalificacion = model.ExamenProgramacionJavascriptCalificacion,
                ExamenProgramacionJavascriptTotalReactivos = model.ExamenProgramacionJavascriptTotalReactivos,
                ExamenProgramacionScrumCalificacion = model.ExamenProgramacionScrumCalificacion,
                ExamenProgramacionScrumTotalReactivos = model.ExamenProgramacionScrumTotalReactivos,
                ExamenProgramacionTecnologiaCalificacion = model.ExamenProgramacionTecnologiaCalificacion,
                ExamenProgramacionTecnologiaTotalReactivos = model.ExamenProgramacionTecnologiaTotalReactivos,
                ExamenProgramacionAciertos = model.ExamenProgramacionAciertos,
                ExamenProgramacionTotalReactivos = model.ExamenProgramacionTotalReactivos,
                ExamenProgramacionRango = model.ExamenProgramacionRango,
                ExamenAnalistaFecha = model.ExamenAnalistaFecha,
                ExamenAnalistaIpComputadora = model.ExamenAnalistaIpComputadora,
                ExamenAnalistaTeoricoId = model.ExamenAnalistaTeoricoId,
                ExamenAnalistaTeoricoAciertos = model.ExamenAnalistaTeoricoAciertos,
                ExamenAnalistaTeoricoTotalReactivos = model.ExamenAnalistaTeoricoTotalReactivos,
                ExamenAnalistaTeoricoRango = model.ExamenAnalistaTeoricoRango,
                ExamenAnalistaPracticoId = model.ExamenAnalistaPracticoId,
                ExamenAnalistaPracticoNumeroCaso = model.ExamenAnalistaPracticoNumeroCaso,
                ExamenAnalistaPracticoAciertos = model.ExamenAnalistaPracticoAciertos,
                ExamenAnalistaPracticoTotalReactivos = model.ExamenAnalistaPracticoTotalReactivos,
                ExamenAnalistaPracticoRango = model.ExamenAnalistaPracticoRango,
                ExamenIngenieroPruebasFecha = model.ExamenIngenieroPruebasFecha,
                ExamenIngenieroPruebasIpComputadora = model.ExamenIngenieroPruebasIpComputadora,
                ExamenIngenieroPruebasTeoricoId = model.ExamenIngenieroPruebasTeoricoId,
                ExamenIngenieroPruebasTeoricoAciertos = model.ExamenIngenieroPruebasTeoricoAciertos,
                ExamenIngenieroPruebasTeoricoTotalReactivos = model.ExamenIngenieroPruebasTeoricoTotalReactivos,
                ExamenIngenieroPruebasTeoricoRango = model.ExamenIngenieroPruebasTeoricoRango,
                ExamenIngenieroPruebasPracticoId = model.ExamenIngenieroPruebasPracticoId,
                ExamenIngenieroPruebasPracticoCalificacion = model.ExamenIngenieroPruebasPracticoCalificacion,
                ExamenIngenieroPruebasPracticoPuntos = model.ExamenIngenieroPruebasPracticoPuntos,
                ExamenIngenieroPruebasPracticoRango = model.ExamenIngenieroPruebasPracticoRango,
                ExamenIngenieroPruebasSqlTotalReactivos = model.ExamenIngenieroPruebasSqlTotalReactivos,
                ExamenIngenieroPruebasSqlCalificacion = model.ExamenIngenieroPruebasSqlCalificacion,
                ExamenAdministradorProyectoFecha = model.ExamenAdministradorProyectoFecha,
                ExamenAdministradorProyectoIpComputadora = model.ExamenAdministradorProyectoIpComputadora,
                ExamenAdministradorProyectoId = model.ExamenAdministradorProyectoId,
                ExamenAdministradorProyectoAciertos = model.ExamenAdministradorProyectoAciertos,
                ExamenAdministradorProyectoTotalReactivos = model.ExamenAdministradorProyectoTotalReactivos,
                ExamenAdministradorProyectoRango = model.ExamenAdministradorProyectoRango,
                ExamenPracticoSoporteBdFecha = model.ExamenPracticoSoporteBdFecha,
                ExamenPracticoSoporteBdAciertos = model.ExamenPracticoSoporteBdAciertos,
                ExamenPracticoSoporteBdTotalReactivos = model.ExamenPracticoSoporteBdTotalReactivos,
                ExamenPracticoSoporteBdRango = model.ExamenPracticoSoporteBdRango,
                EntrevistaCapitalHumanoFecha = model.EntrevistaCapitalHumanoFecha,
                EntrevistaCapitalHumanoComentarios = model.EntrevistaCapitalHumanoComentarios,
                EntrevistaCoordinadorYEquipoTecnicoFecha = model.EntrevistaCoordinadorYEquipoTecnicoFecha,
                EntrevistaCoordinadorYEquipoTecnicoComentarios = model.EntrevistaCoordinadorYEquipoTecnicoComentarios,
                EntrevistaInglesFecha = model.EntrevistaInglesFecha,
                EntrevistaInglesComentarios = model.EntrevistaInglesComentarios,
                EntrevistaGerenteAreaFecha = model.EntrevistaGerenteAreaFecha,
                EntrevistaGerenteAreaComentarios = model.EntrevistaGerenteAreaComentarios,
                VeredictoFinal = model.VeredictoFinal,
                VeredictoFinalNivelIdentificado = model.VeredictoFinalNivelIdentificado,
                VeredictoFinalComentarios = model.VeredictoFinalComentarios,
                PropuestaEconomicaFecha = model.PropuestaEconomicaFecha,
                PropuestaEconomicaEstatus = model.PropuestaEconomicaEstatus,
                PropuestaEconomicaSueldo = model.PropuestaEconomicaSueldo,
                PropuestaEconomicaComentarios = model.PropuestaEconomicaComentarios,
                IngresoFecha = model.IngresoFecha,
                IngresoTipoContrato = model.IngresoTipoContrato,
                IngresoVencimientoContratoDeterminado = model.IngresoVencimientoContratoDeterminado,
                IngresoObservaciones = model.IngresoObservaciones,
                Curriculum = includeCurriculumFile ? model.Curriculum : null,
                CurriculumFileName = model.CurriculumFileName
            };
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
                model.IngresoObservaciones,
                model.Curriculum,
                model.CurriculumFileName
            );
    }
}