using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using AppPersistence.Extensions;
using AppPersistence.Enums;
using Microsoft.AspNetCore.Authorization;
using ReclutaCVLogic.Utils.Extensions;

namespace ReclutaCVApi.Authorization
{
    /// <summary>
    /// Manejador de los permisos de la aplicación
    /// Está encargado de determinar si el usuario autenticado tiene permiso de llevar a cabo alguna acción
    /// </summary>
    public class PermissionHandler : AuthorizationHandler<PermissionRequirement>
    {
        /// <param name="noAuthenticatedUserByPassAuthorization">Indica si un usuario no autenticado va a saltar la seguridad de la aplicación</param>
        public PermissionHandler(bool noAuthenticatedUserByPassAuthorization)
        {
            var allPermissions = 
                new HashSet<Permission>(EnumExtensions.GetValues<Permission>());

            var allUsers = new int[] { };

            // TODO: POR AHORA, TODOS LOS USUARIOS TENDRÁN TODOS LOS PERMISOS
            permissionsPerUser = 
                allUsers.ToDictionary(
                    userId => userId, 
                    _ => allPermissions
                );

            this.noAuthenticatedUserByPassAuthorization = noAuthenticatedUserByPassAuthorization;
        }

        /// <summary>
        /// Diccionario que contiene los permisos a los que tiene acceso cada rol
        /// </summary>
        private readonly Dictionary<int, HashSet<Permission>> permissionsPerUser;

        private readonly bool noAuthenticatedUserByPassAuthorization;

        private bool UserHasPermission(
            ClaimsPrincipal user, 
            Permission permission
        )
        {
            var authenticatedUserId =
                AuthenticationHelper.GetAuthenticatedUserId(user);

            if (authenticatedUserId == null)
            {
                // TODO: quitar esto cuando se llegue a una versión más avanzada del aplicativo
                return noAuthenticatedUserByPassAuthorization;
            }


            // TODO: Terminar de implementar permisos
            return true ||
                (
                    permissionsPerUser.ContainsKey(authenticatedUserId.Value) &&
                    permissionsPerUser[authenticatedUserId.Value].Contains(permission)
                );
        }

        protected override Task HandleRequirementAsync(
            AuthorizationHandlerContext context, 
            PermissionRequirement requirement
        )
        {
            var hasPermission = UserHasPermission(context.User, requirement.Permission);
            if (hasPermission)
            {
                context.Succeed(requirement);
            } else
            {
                // No user authorizedd. Alternatively call context.Fail() to ensure a failure 
                // as another handler for this requirement may succeed
                context.Fail();
            }

            return Task.FromResult(0);
        }
    }
}
