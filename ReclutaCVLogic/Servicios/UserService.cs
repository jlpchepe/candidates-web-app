using AppPersistence.Dtos;
using ReclutaCVData.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReclutaCVLogic.Servicios
{
    public class UserService
    {
        public Task Save(
            int? id,
            string name,
            string password,
            bool? active
        )
        {
            //TODO
            return Task.CompletedTask;
        }

        public Task DeleteById(int id)
        {
            return Task.CompletedTask;
        }

        public Task ChangeStatus(int id, bool active)
        {
            return Task.CompletedTask;
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
    }
}
