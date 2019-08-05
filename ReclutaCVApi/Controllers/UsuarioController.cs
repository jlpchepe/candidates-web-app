using System.Linq;
using System.Threading.Tasks;
using ReclutaCVApi.Attributes;
using ReclutaCVApi.Authorization;
using ReclutaCVApi.Dtos;
using AppPersistence.Dtos;
using Microsoft.AspNetCore.Mvc;
using ReclutaCVLogic.Servicios;
using AppPersistence.Extensions;

namespace ReclutaCVApi.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class UsuarioController
    {
        public UsuarioController(UsuarioService service)
        {
            this.service = service;
        }

        readonly UsuarioService service;

        [HttpGet]
        public async Task<ActionResult<Page<UsuarioListable>>> Get(
            [MinRequired(0)] int pageNumber,
            [MinRequired(1)] ushort pageSize
        )
        {
            return (await service.FindAll(pageNumber, pageSize))
                .Select(user =>
                    new UsuarioListable
                    (
                        user.Id,
                        user.Nombre,
                        user.Activo
                    )
                );

        }

        [HttpGet("{id}")]
        public async Task<ActionResult<UsuarioConsultable>> Get(int id)
        {
            var user = await service.FindById(id);

            return new UsuarioConsultable(
                user.Id,
                user.Nombre,
                user.Activo
            );
        }

        [HttpPost]
        public Task<int> Post([FromBody] UsuarioInsertable model)
        {
            return service.Save(
                null,
                model.Nombre,
                model.Contraseña,
                model.Activo
            );
        }

        [HttpPut]
        public Task Put([FromBody] UsuarioUpdatable model)
        {
            return service.Save(
                model.Id,
                model.Nombre,
                model.Contraseña,
                model.Activo
            );
        }

        /// <summary>
        /// Cambia el estatus del usuario indicado
        /// </summary>
        /// <param name="request">Petición para cambiar el estatus</param>
        [HttpPut("status")]
        public Task Put([FromBody] UsuarioChangeStatusRequest request) => 
            service.ChangeStatus(request.Id, request.Activo);

        [HttpDelete("{id}")]
        public async Task Delete(int id)
        {
            await service.DeleteById(id);
        }
    }
}
