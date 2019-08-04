using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReclutaCVApi.Dtos
{
    /// <summary>
    /// Configuración para el manejo y creación de tokens de JWT
    /// </summary>
    public class JwtConfiguration
    {
        public JwtConfiguration(
            string secretKey,
            int expirationDays
        )
        {
            SecretKey = Encoding.ASCII.GetBytes(secretKey);
            ExpirationDays = expirationDays;
        }

        /// <summary>
        /// Llave secreta como bytes
        /// </summary>
        public byte[] SecretKey { get; }

        /// <summary>
        /// Días en los que expiran los token
        /// </summary>
        public int ExpirationDays { get; }
    }
}
