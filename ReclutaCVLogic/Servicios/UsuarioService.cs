using AppPersistence.Dtos;
using AppPersistence.Enums;
using AppPersistence.Exceptions;
using AppPersistence.Repositories;
using ReclutaCVData.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReclutaCVLogic.Servicios
{
    public class UsuarioService
    {
        public UsuarioService(
            CrudRepository<Usuario, int?> repository
        )
        {
            this.repository = repository;
        }

        private readonly CrudRepository<Usuario, int?> repository;

        /// <summary>
        /// Regresa el Id del usuario insertado
        /// </summary>
        /// <param name="id"></param>
        /// <param name="nombre"></param>
        /// <param name="contraseña"></param>
        /// <param name="activo"></param>
        /// <returns></returns>
        public async Task<int> Save(
            int? id,
            string nombre,
            string contraseña,
            bool? activo
        )
        {
            var usuario = await repository.FindById(id) ?? new Usuario();

            usuario.Nombre = nombre;
            if (!string.IsNullOrEmpty(contraseña))
            {
                usuario.Contraseña = HashPassword(contraseña);
            }
            usuario.Activo = activo ?? throw new ValidationErrorException(nameof(Usuario.Activo), ValidationErrorType.Required);

            await repository.Save(usuario);

            return usuario.Id;
        }

        public Task DeleteById(int id) =>
            repository.DeleteById(id);

        public async Task ChangeStatus(int id, bool active)
        {
            var usuario = await repository.FindById(id);

            usuario.Activo = active;

            await repository.Save(usuario);
        }

        public Task<Usuario> FindById(int id)
        {
            return repository.FindById(id);
        }

        public Task<Page<Usuario>> FindAll(int pageNumber, ushort pageSize)
        {
            return repository.Find(
                entity => entity,
                entity => true,
                entity => entity.Nombre,
                new Pageable(pageNumber, pageSize, OrderDirection.Ascending)
            );
        }

        private string HashPassword(string plainPassword)
        {
            var salt = BCrypt.Net.BCrypt.GenerateSalt();
            var hashPassword = BCrypt.Net.BCrypt.HashPassword(plainPassword, salt);

            return hashPassword;
        }
    }
}
