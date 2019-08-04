using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ReclutaCVApi.Attributes;
using ReclutaCVApi.Authorization;
using Microsoft.AspNetCore.Mvc;
using ReclutaCVLogic.Servicios;

namespace ReclutaCVApi.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class SolicitudVacanteController
    {
        public SolicitudVacanteController(SolicitudVacantesService service, UserPasswordValidator userPasswordValidator)
        {
            this.service = service;
            this.userPasswordValidator = userPasswordValidator;
        }

        private readonly SolicitudVacantesService service;
        private readonly UserPasswordValidator userPasswordValidator;

        [HttpGet("all")]
        public async Task<ActionResult<IReadOnlyList<SolicitudVacanteSelectable>>> Get() =>
            new ActionResult<IReadOnlyList<SolicitudVacanteSelectable>>(await service.FindAll());

        [HttpGet]
        public async Task<ActionResult<Page<SolicitudVacanteListable>>> Get(
            [MinRequired(0)] int pageNumber,
            [MinRequired(1)] ushort pageSize
        )
        {
            return (await service.FindAll(pageNumber, pageSize))
                .Select(SolicitudVacante =>
                    new SolicitudVacanteListable(
                        SolicitudVacante.Id,
                        SolicitudVacante.Name,
                        SolicitudVacante.Code,
                        SolicitudVacante.EmployeeType,
                        SolicitudVacante.MechanicLevel,
                        SolicitudVacante.EstimatedMinutes,
                        SolicitudVacante.Active
                    )
                );
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<SolicitudVacanteConsultable>> Get(int id)
        {
            var p = await service.FindById(id);

            return new SolicitudVacanteConsultable(
                p.Id,
                p.Name,
                p.Code,
                p.EmployeeType,
                p.MechanicLevel,
                p.EstimatedMinutes,
                p.Active
            );
        }

        [HttpPost]
        public Task Post([FromBody] SolicitudVacanteInsertable model)
        {
            return service.Save(
                model.Name,
                model.Code,
                model.EmployeeType,
                model.MechanicLevel,
                model.EstimatedMinutes,
                model.Active
            );
        }

        [HttpPut]
        public Task Put([FromBody] SolicitudVacanteUpdatable model)
        {
            return service.Save(
                model.Name,
                model.Code,
                model.EmployeeType,
                model.MechanicLevel,
                model.EstimatedMinutes,
                model.Active,
                model.Id
            );
        }

        /// <summary>
        /// Cambia el estatus de la actividad indicada
        /// </summary>
        /// <param name="request">Petición para cambiar el estatus</param>
        [HttpPut("status")]
        public Task Put([FromBody] SolicitudVacanteChangeStatusRequest request) =>
            service.ChangeStatus(request.Id, request.Active);

        [HttpDelete("{id}")]
        public async Task Delete(int id, string justification, string password)
        {
            await userPasswordValidator.ValidateUserPasswordOrThrow(password);
            await service.DeleteById(id, justification);
        }
    }
}