using AppPersistence.Dtos;
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
            CrudRepository<Usuario, int> repository
        )
        {
            this.repository = repository;
        }

        private readonly CrudRepository<Usuario, int?> repository;

        public async Task Save(
            int? id,
            string nombre,
            string contraseña,
            bool? active
        )
        {
            var usuario = await repository.FindById(id) ?? new Usuario();

            usuario.Nombre = nombre;
            if (!string.IsNullOrEmpty(contraseña))
            {
                usuario.Contraseña = HashPassword(contraseña);
            }
            usuario.Activo = active;

            await repository.Save(usuario);
        }

        public Task DeleteById(int id)
        {
            return Task.CompletedTask;
        }

        public async Task ChangeStatus(int id, bool active)
        {
            var usuario = await repository.FindById(id);

            usuario.Activo = active;

            await repository.Save(usuario);
        }

        public Task<Usuario> FindById(int id)
        {
            //TODO
            return null;
        }

        public Task<Page<Usuario>> FindAll(int pageNumber, ushort pageSize)
        {
            //TODO
            return null;
        }

        private string HashPassword(string plainPassword)
        {
            return 
        }
    }
}
