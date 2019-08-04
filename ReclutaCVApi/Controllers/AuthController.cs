using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Threading.Tasks;
using ReclutaCVApi.Dtos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using ReclutaCVLogic.Servicios;

namespace ReclutaCVApi.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly AuthService authService;
        private readonly JwtConfiguration secretKeyProvider;

        public AuthController(
            AuthService authService,
            JwtConfiguration secretKeyProvider
        )
        {
            this.authService = authService;
            this.secretKeyProvider = secretKeyProvider;
        }

        [HttpPost]
        public async Task<ActionResult<string>> Login(AuthRequest request)
        {
            var userOrNullIfInvalidCredentials = 
                await authService.ValidateUserCredential(
                    request.Username, 
                    request.Password
                );

            if(userOrNullIfInvalidCredentials == null)
            {
                return Unauthorized();
            }

            // Creamos los claims (pertenencias, características) del usuario
            var claimIdentity =
                new ClaimsIdentity(new Claim[]
                {
                    // Se especifica el ID del usuario
                    new Claim(ClaimTypes.NameIdentifier, userOrNullIfInvalidCredentials.Id.ToString()),
                    // Se especifica el nombre del usuario
                    new Claim(ClaimTypes.Name, userOrNullIfInvalidCredentials.Nombre)
                });

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = claimIdentity,
                // Nuestro token va a durar un día
                Expires = DateTime.UtcNow.AddDays(secretKeyProvider.ExpirationDays),
                // Credenciales para generar el token usando nuestro secretykey y el algoritmo hash 256
                SigningCredentials = new SigningCredentials(
                    new SymmetricSecurityKey(secretKeyProvider.SecretKey), 
                    SecurityAlgorithms.HmacSha256Signature
                )
            };

            var tokenHandler = new JwtSecurityTokenHandler();
            var createdToken = tokenHandler.CreateToken(tokenDescriptor);

            return tokenHandler.WriteToken(createdToken);
        }
    }
}