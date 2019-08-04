using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ReclutaCVApi.Dtos
{
    /// <summary>
    /// Una petición para autenticarse en el sistema
    /// </summary>
    public class AuthRequest
    {
        public string Username { get; set; }
        public string Password { get; set; }
    }
}
