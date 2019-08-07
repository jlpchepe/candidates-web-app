using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ReclutaCVApi.Attributes;
using ReclutaCVApi.Authorization;
using Microsoft.AspNetCore.Mvc;
using ReclutaCVLogic.Servicios;
using ReclutaCVApi.Dtos;
using AppPersistence.Dtos;
using AppPersistence.Extensions;
using ReclutaCVData.Entidades;

namespace ReclutaCVApi.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class SolicitudVacanteController
    {
        public SolicitudVacanteController(
            SolicitudVacantesService service
        )
        {
            this.service = service;
        }

        private readonly SolicitudVacantesService service;

        [HttpGet]
        public async Task<ActionResult<Page<SolicitudVacanteConsultable>>> Get(
            [MinRequired(0)] int pageNumber,
            [MinRequired(1)] ushort pageSize
        )
        {
            return (await service.FindAll(pageNumber, pageSize))
                .Select(ToConsultable);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<SolicitudVacanteConsultable>> Get(int id) =>
            ToConsultable(await service.FindById(id));

        [HttpPost]
        public Task<int> Post([FromBody] SolicitudVacanteInsertable model) =>
            service.Insert(ToSolicitudVacante(null, model));

        [HttpPut]
        public Task Put([FromBody] SolicitudVacanteUpdatable model) =>
            service.Update(ToSolicitudVacante(model.Id, model));

        [HttpDelete("{id}")]
        public Task Delete(int id) => 
            service.Delete(id);

        private SolicitudVacanteConsultable ToConsultable(
            SolicitudVacante model
        ) => new SolicitudVacanteConsultable(
            model.Id,
            model.FolioCapitalHumano,
            model.FechaDeSolicitud,
            model.Motivo,
            model.EspecifiqueMotivo,
            model.NombreDelSolicitante,
            model.PuestoDelSolicitante,
            model.AreaDelSolicitante,
            model.EspecifiqueAreaDelSolicitante,
            model.Sueldo,
            model.TipoDeContrato,
            model.EspecifiqueTipoDeContrato,
            model.Estatus,
            model.PuestoSolicitado,
            model.EspecifiquePuestoSolicitado,
            model.PuestoSolicitadoNivel,
            model.NombreDelJefeInmediato,
            model.Proyecto,
            model.NivelIdiomaIngles,
            model.EdadRango,
            model.EstadoCivil,
            model.FechaEstimadaDeIngreso,
            model.ExperienciaLaboral,
            model.CompetenciasOHabilidades,
            model.CertificacionesNecesarias,
            model.TipoDeEvaluacion,
            model.Observaciones
        );

        private SolicitudVacante ToSolicitudVacante(
            int? id,
            SolicitudVacanteConsultable model
        ) =>
            new SolicitudVacante(
                id,
                model.FolioCapitalHumano,
                model.FechaDeSolicitud,
                model.Motivo,
                model.EspecifiqueMotivo,
                model.NombreDelSolicitante,
                model.PuestoDelSolicitante,
                model.AreaDelSolicitante,
                model.EspecifiqueAreaDelSolicitante,
                model.Sueldo,
                model.TipoDeContrato,
                model.EspecifiqueTipoDeContrato,
                model.Estatus,
                model.PuestoSolicitado,
                model.EspecifiquePuestoSolicitado,
                model.PuestoSolicitadoNivel,
                model.NombreDelJefeInmediato,
                model.Proyecto,
                model.NivelIdiomaIngles,
                model.EdadRango,
                model.EstadoCivil,
                model.FechaEstimadaDeIngreso,
                model.ExperienciaLaboral,
                model.CompetenciasOHabilidades,
                model.CertificacionesNecesarias,
                model.TipoDeEvaluacion,
                model.Observaciones
            );
    }
}