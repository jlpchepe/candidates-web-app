using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ReclutaCVApi.Authorization
{
    /// <summary>
    /// Un permiso de algo que puede hacer un <see cref="AppPersistence.Entities.User"/> en el sistema en función de su <see cref="AppPersistence.Enums.UserRole"/>
    /// </summary>
    public enum Permission
    {
        CanGetWorkstation
    }
}
