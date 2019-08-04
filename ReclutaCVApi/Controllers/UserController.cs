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
    public class UserController
    {
        public UserController(UserService service, UserPasswordValidator userPasswordValidator)
        {
            this.service = service;
            this.userPasswordValidator = userPasswordValidator;
        }

        readonly UserService service;
        private readonly UserPasswordValidator userPasswordValidator;

        [HttpGet]
        public async Task<ActionResult<Page<UserListable>>> Get(
            [MinRequired(0)] int pageNumber,
            [MinRequired(1)] ushort pageSize
        )
        {
            return (await service.FindAll(pageNumber, pageSize))
                .Select(user =>
                    new UserListable
                    (
                        user.Id,
                        user.Nombre,
                        user.Activo
                    )
                );

        }

        [HttpGet("{id}")]
        public async Task<ActionResult<UserConsultable>> Get(int id)
        {
            var user = await service.FindById(id);

            return new UserConsultable(
                user.Id,
                user.Nombre,
                user.Activo
            );
        }

        [HttpPost]
        public Task Post([FromBody] UserInsertable model)
        {
            return service.Save(
                null,
                model.Name,
                model.Password,
                model.Active
            );
        }

        [HttpPut]
        public Task Put([FromBody] UserUpdatable model)
        {
            return service.Save(
                model.Id,
                model.Name,
                null,
                model.Active
            );
        }

        /// <summary>
        /// Cambia el estatus del usuario indicado
        /// </summary>
        /// <param name="request">Petición para cambiar el estatus</param>
        [HttpPut("status")]
        public Task Put([FromBody] UserChangeStatusRequest request) => 
            service.ChangeStatus(request.Id, request.Active);

        [HttpDelete("{id}")]
        public async Task Delete(int id, string justification, string password)
        {
            await userPasswordValidator.ValidateUserPasswordOrThrow(password);
            await service.DeleteById(id);
        }
    }
}
