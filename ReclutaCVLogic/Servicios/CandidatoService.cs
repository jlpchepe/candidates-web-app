using AppPersistence.Dtos;
using AppPersistence.Enums;
using AppPersistence.Repositories;
using ReclutaCVData;
using ReclutaCVData.Entidades;
using ReclutaCVLogic.Dtos;
using ReclutaCVLogic.Reportes;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ReclutaCVLogic.Servicios
{
    public class CandidatoService
    {
        public CandidatoService(
            CrudRepository<Candidato, int> repository,
            GeneradorReporteCandidatos generadorReporteCandidatos
        )
        {
            this.repository = repository;
            this.generadorReporteCandidatos = generadorReporteCandidatos;
        }

        private readonly CrudRepository<Candidato, int> repository;
        private readonly GeneradorReporteCandidatos generadorReporteCandidatos;

        /// <summary>
        /// Obtiene todos los candidatos existentes
        /// </summary>
        public async Task<IReadOnlyCollection<Candidato>> FindAll() => 
            await repository.Find(
                entity => entity,
                entity => true,
                entity => entity.FechaDeContacto,
                OrderDirection.Descending
            );

        /// <summary>
        /// Obtiene todos los candidatos existentes
        /// </summary>
        public async Task<Page<TResult>> FindAll<TResult>(
            Expression<Func<Candidato, TResult>> selector,
            Expression<Func<TResult, DateTime?>> sort,
            int pageNumber,
            int pageSize,
            string nombre
        )
        {
            var fixedNombre = nombre ?? "";

            return await repository.Find(
                selector,
                entity =>
                    fixedNombre == "" ||
                    entity.Nombre.ToLower().Contains(nombre.ToLower())
                ,
                sort,
                new Pageable(pageNumber, pageSize, OrderDirection.Descending)
            );
        }

        public async Task SaveCurriculum(
            int candidatoId, 
            byte[] curriculum, 
            string curriculumFileName
        )
        {
            var candidato = await FindById(candidatoId, entity => entity);
            candidato.Curriculum = curriculum;
            candidato.CurriculumFileName = curriculumFileName;

            await Update(candidato);
        }

        public async Task<CandidatoCurriculumConsultable> GetCurriculum(int id)
        {
            return await FindById(
                id,
                entity => new CandidatoCurriculumConsultable
                {
                    Curriculum = entity.Curriculum,
                    CurriculumFileName = entity.CurriculumFileName
                }
            );
        }

        public async Task<Reporte> GetReporteCandidatos(string busqueda)
        {
            var candidatos = 
                (await FindAll(
                    model => new FilaReporteCandidato
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
                        IngresoObservaciones = model.IngresoObservaciones
                    },
                    entity => entity.FechaDeContacto,
                    0,
                    int.MaxValue, 
                    busqueda
                ))
                .Items;

            return await generadorReporteCandidatos.GenerarReporteCandidatos(candidatos);
        }

        /// <summary>
        /// Obtiene el candidato con el id especificado
        /// </summary>
        public Task<TResult> FindById<TResult>(
            int id,
            Expression<Func<Candidato, TResult>> selector
        ) => 
            repository.FindFirstOrDefault(
                selector,
                entity => entity.Id == id,
                entity => true
            );

        public Task Update(
            Candidato nuevaInformacionCandidato
        ) {
            nuevaInformacionCandidato.FechaDeActualizacion = DateTime.Now;
            return repository.Save(nuevaInformacionCandidato);
        }

        /// <summary>
        /// Regresa la llave primaria del registro
        /// </summary>
        /// <param name="candidatoAInsertar"></param>
        /// <returns></returns>
        public async Task<int> Insert(Candidato candidatoAInsertar)
        {
            candidatoAInsertar.FechaDeActualizacion = DateTime.Now;
            await repository.Save(candidatoAInsertar);

            return candidatoAInsertar.Id;
        }

        public Task Delete(int id) => 
            repository.DeleteById(id);
    }
}
