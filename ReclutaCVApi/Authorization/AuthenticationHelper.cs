using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using AppPersistence.Extensions;
using AppPersistence.Enums;

namespace ReclutaCVApi.Authorization
{
    /// <summary>
    /// Métodos de ayuda para obtener los datos de un usuario autenticado en el sistema
    /// </summary>
    public class AuthenticationHelper
    {
        /// <summary>
        /// Obtiene el rol que tiene el usuario indicado
        /// Regresa null si no hay usaurio autenticado
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public static UserRole? GetAuthenticatedUserRole(
            ClaimsPrincipal user
        )
        {
            var userRoleClaimValue = 
                user.Claims
                .FirstOrDefault(x => x.Type == ClaimTypes.Role)
                ?.Value;

            var userRole = 
                EnumExtensions.GetEnumValue<UserRole>(userRoleClaimValue);

            return userRole;
        }
        
        /// <summary>
        /// Obtiene el ID del usuario indicado
        /// Regresa null si no hay usuario autenticado
        /// </summary>
        /// <returns></returns>
        public static int? GetAuthenticatedUserId(
            ClaimsPrincipal user
        )
        {
            var userIdClaimValue =
                user
                ?.Claims
                .FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier)
                ?.Value;

            return userIdClaimValue != null ? 
                Convert.ToInt32(userIdClaimValue) : 
                (int?)null;
        }
    }
}
