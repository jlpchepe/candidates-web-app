using System.Threading.Tasks;
using AppPersistence.Dtos;
using AppPersistence.Enums;
using AppPersistence.Services;
using AppPersistence.Exceptions;

namespace ReclutaCVApi.Authorization
{
    public class UserPasswordValidator
    {
        private readonly AuthService auth;
        private readonly CurrentAuthenticatedUser authenticatedUser;

        public UserPasswordValidator(
            AuthService auth,
            CurrentAuthenticatedUser authenticatedUser
        )
        {
            this.auth = auth;
            this.authenticatedUser = authenticatedUser;
        }

        /// <summary>
        /// Valida la contraseña del usuario actualmente autenticado, si es válido no hace nada, si es inválido lanza una excepción
        /// </summary>
        /// <param name="password"></param>
        /// <returns></returns>
        public async Task ValidateUserPasswordOrThrow(string password)
        {
            if (authenticatedUser.UserId == null || !await auth.ValidatePassword(authenticatedUser.UserId.Value, password))
            {
                throw new ValidationErrorException("VALIDATION_PASSWORD", ValidationErrorType.Invalid);
            }
        }
    }
}