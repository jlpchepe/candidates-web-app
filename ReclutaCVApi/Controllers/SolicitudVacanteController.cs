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
        public async Task<ActionResult<Page<SolicitudVacanteListable>>> Get(
            [MinRequired(0)] int pageNumber,
            [MinRequired(1)] ushort pageSize
        )
        {
            return (await service.FindAll(pageNumber, pageSize))
                // TODO
                .Select(entity => new SolicitudVacanteListable());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<SolicitudVacanteConsultable>> Get(int id)
        {
            var p = await service.FindById(id);

            return new SolicitudVacanteConsultable(
            );
        }

        [HttpPost]
        public Task<int> Post([FromBody] SolicitudVacanteInsertable model) =>
            service.Insert();


        [HttpPut]
        public Task Put([FromBody] SolicitudVacanteUpdatable model)
        {
            //TODO
            return Task.CompletedTask;
        }

        [HttpDelete("{id}")]
        public async Task Delete(int id)
        {
            await service.Delete(id);
        }
    }
}