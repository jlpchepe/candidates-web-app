using System.Threading.Tasks;
using ReclutaCVApi.Attributes;
using ReclutaCVApi.Authorization;
using ReclutaCVApi.Dtos;
using AppPersistence.Services;
using AppPersistence.Dtos;
using Microsoft.AspNetCore.Mvc;
using LogicDtos = AppPersistence.Dtos;
using ReclutaCVLogic.Servicios;

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
        public async Task<ActionResult<Page<LogicDtos.CandidatoListable>>> Get(
           [MinRequired(0)] int pageNumber,
           [MinRequired(0)] ushort pageSize
        )
        {
            return await service.FindAll(pageNumber, pageSize);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<CandidatoConsultable>> Get(int id)
        {
            var Candidato = await service.FindById(id);

            return new CandidatoConsultable(
                Candidato.Id,
                Candidato.Reason,
                Candidato.StartDate,
                Candidato.DueDate,
                Candidato.OperatorId,
                Candidato.HoursOfCandidato
            );
        }

        [HttpPost]
        public Task Post([FromBody] CandidatoInsertable model)
        {
            return service.Save(
                model.Reason,
                model.StartDate,
                model.DueDate,
                model.HoursOfCandidato,
                model.OperatorId,
                null
            );
        }

        [HttpPut]
        public Task Put([FromBody] CandidatoUpdatable model)
        {
            return service.Save(
                model.Reason,
                model.StartDate,
                model.DueDate,
                model.HoursOfCandidato,
                model.OperatorId,
                model.Id
            );
        }

        [HttpDelete("{id}")]
        public async Task Delete(int id, string justification, string password)
        {
            await userPasswordValidator.ValidateUserPasswordOrThrow(password);
            await service.DeleteById(id, justification);
        }
    }
}