using AppPersistence.Repositories;
using ReclutaCVData.Entidades;
using ReclutaCVLogic.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReclutaCVLogic.Servicios
{
    /// <summary>
    /// Servicio para la autenticación de usuarios
    /// </summary>
    public class AuthService
    {
        public AuthService(CrudRepository<Usuario, int> repository) =>
            this.repository = repository;

        private readonly CrudRepository<Usuario, int> repository;

        /// <summary>
        /// Valida las credenciales del usuario
        /// Si el usuario no existe, o si la contraseña es incorrecta, se regresa null
        /// Si las credenciales son válidas, se regresa la información del usuario
        /// </summary>
        /// <param name="username">Nombre de usuario</param>
        /// <param name="plainPassword">Contraseña plana a validarse</param>
        /// <returns></returns>
        public async Task<bool> ValidatePassword(
            int userId,
            string plainPassword
        )
        {
            var password =
                (await repository.Find(
                    u => u.Contraseña,
                    u => u.Id == userId,
                    u => true
                ))
                .FirstOrDefault();

            return IsValidPassword(plainPassword, password);
        }

        /// <summary>
        /// Valida las credenciales del usuario
        /// Si el usuario no existe, o si la contraseña es incorrecta, se regresa null
        /// Si las credenciales son válidas, se regresa la información del usuario
        /// </summary>
        /// <param name="username">Nombre de usuario</param>
        /// <param name="plainPassword">Contraseña plana a validarse</param>
        /// <returns></returns>
        public async Task<UsuarioAutenticado> ValidateUserCredential(
            string username,
            string plainPassword
        )
        {
            var lowercaseUsername = username?.ToLower();
            var user =
                (await repository.FindFirstOrDefault(
                    u => new
                    {
                        u.Id,
                        u.Nombre,
                        u.Contraseña,
                        u.Activo
                    },
                    u => u.Nombre.ToLower() == lowercaseUsername,
                    u => u.Nombre
                ));

            var validCredentials =
                user != null &&
                user.Activo &&
                IsValidPassword(plainPassword, user.Contraseña);

            return validCredentials ?
                new UsuarioAutenticado(
                    user.Id,
                    user.Nombre
                ) : null;
        }

        /// <summary>
        /// Válida que la contraseña plana sea congruente con la contraseña que tiene hash
        /// </summary>
        /// <param name="plainPassword"></param>
        /// <param name="hashedPassword"></param>
        /// <returns>True si la contraseña concuerda, false si no</returns>
        private bool IsValidPassword(
            string plainPassword,
            string hashedPassword
        ) => BCrypt.Net.BCrypt.Verify(plainPassword, hashedPassword);
    }
}
