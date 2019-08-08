using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Threading.Tasks;
using ReclutaCVApi.Authorization;
using ReclutaCVApi.Dtos;
using AppPersistence.Validators;
using AppPersistence.Exceptions;
using AppPersistence.Repositories;
using AppPersistence.Repositories.Impl;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using ReclutaCVLogic.Utils.Extensions;
using ReclutaCVData;
using ReclutaCVLogic.Servicios;

namespace ReclutaCVApi.Extensions
{
    /// <summary>
    /// Extension methods used in the Startup class
    /// </summary>
    internal static class StartupConfigurationExtensions
    {
        public static void ConfigureCors(this IApplicationBuilder app)
        {
            app.UseCors(builder =>
            {
                //PERMITIMOS PETICIONES QUE VENGAN DE LOCALHOST O DE ALGUNO DE LAS URL INDICADAS
                builder.SetIsOriginAllowed(origin =>
                    // TODO: Quitar este true y poner una política CORS más estricta
                    true ||
                    origin.Contains("http://localhost:")
                );

                //PERMITIMOS CUALQUIER METODO
                builder.AllowAnyMethod();

                //PERMITIMOS CUALQUIER CABECERA EN LA PETICIÓN
                builder.AllowAnyHeader();

                //SE PERMITE VER EL HEADER CONTENT-DISPOSITION
                builder.WithExposedHeaders("Content-Disposition");

                // CREDENTIALS MUST BE ENABLED FOR USING SIGNALR, EVEN WHEN AUTHENTICATION IS NOT USED.
                builder.AllowCredentials();
            });
        }

        /// <summary>
        /// La autorización de la aplicación está basada en permisos
        /// Este método agrega la lógica para lograr este enfoqe
        /// </summary>
        /// <param name="services">Servicios</param>
        /// <param name="noAuthenticatedUserByPassAuthorization">Indica si se le permitirá a usuarios no autenticados saltar las validaciones de autorización</param>
        public static void AddPermissionBasedAuthorization(
            this IServiceCollection services,
            bool noAuthenticatedUserByPassAuthorization
        )
        {
            services.AddAuthorization(options =>
            {
                foreach (var permission in EnumExtensions.GetValues<Permission>())
                {
                    // Se agregan todos los valores del enum Permission como pólizas
                    options.AddPolicy(
                        permission.ToString(),
                        policy => policy.Requirements.Add(new PermissionRequirement(permission))
                    );
                }
            });

            // Registrarlo como alcance
            // Porque el repositorio de permisos podría usar un contexto a la DB
            services.AddScoped<IAuthorizationHandler, PermissionHandler>(
                sp => new PermissionHandler(noAuthenticatedUserByPassAuthorization)
            );
        }

        /// <summary>
        /// La autenticación de la aplicación está basada en tokens JWT
        /// Este método agrega la lógica para lograr este enfoqe
        /// </summary>
        /// <param name="services"></param>
        /// <param name="jwtConfiguration"></param>
        public static void AddJwtBasedAuthentication(
            this IServiceCollection services,
            JwtConfiguration jwtConfiguration
        )
        {
            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(options =>
            {
                options.RequireHttpsMetadata = false;
                options.SaveToken = true;
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(jwtConfiguration.SecretKey),
                    ValidateIssuer = false,
                    ValidateAudience = false
                };
            });
        }

        /// <summary>
        /// Agrega como Singletons las clases que necesita la aplicación
        /// </summary>
        /// <param name="services"></param>
        /// <param name="connectionString">Cadena de conexión a la base de datos a utilizarse</param>
        public static void AddBusinessDependencies(
            this IServiceCollection services,
            string connectionString
        )
        {
            // Creación de contexto con base de datos
            Func<Db> dbFactory = () => new Db(connectionString);

            services.AddSingleton(sp => dbFactory);
            services.AddSingleton(sp => new DbRepository(dbFactory));
            services.AddSingleton(typeof(CrudRepository<,>), typeof(DbCrudRepository<,>));

            // Se agrega el validador de entidades que estará utilizando la aplicación
            services.AddSingleton<ModelValidator, DbModelValidator>();

            void AddNamespaceClassesAsScoped(Assembly assembly, string nameSpace)
            {
                assembly
                .GetTypes()
                .Where(type =>
                {
                    return type.IsPublic &&
                        type.IsClass &&
                        type.Namespace.Contains(nameSpace) &&
                        !type.IsAbstract;
                })
                .ToList()
                .ForEach(serviceType => services.AddScoped(serviceType));
            }


            // AGREGAMOS LOS SERVICIOS DE LA CAPA DE LÓGICA
            // OBTENEMOS EL TIPO DE ALGUNA CLASE QUE SE ENCUENTRE DENTRO DEL ESPACIO DE NOMBRES <see cref="AppLogic.Services"/>
            var appLogicServicesNamespace = typeof(CandidatoService);
            AddNamespaceClassesAsScoped(appLogicServicesNamespace.Assembly, appLogicServicesNamespace.Namespace);

            // PARA QUE A LOS SERVICIOS SE LES PUEDA INYECTAR INFORMACIÓN SOBRE LA SESIÓN ACTUAL, SE HABILITA ESTE ACCESOR
            services.TryAddSingleton<IHttpContextAccessor, HttpContextAccessor>();
        }

        /// <summary>
        /// Se configura el manejador de excepciones de la aplicación
        /// Una de las tareas de este debe ser atrapar los errores de validaciones de las entidades que se intenten insertar o actualizar
        /// </summary>
        /// <param name="app"></param>
        public static void ConfigureExceptionHandler(this IApplicationBuilder app)
        {
            var validationErrorMessageTranspiler = new ValidationErrorMessageTranspiler();

            app.UseExceptionHandler(appError =>
            {
                appError.Run(async context =>
                {
                    // Ante errores, siempre se responderá con un JSON
                    context.Response.ContentType = "application/json";

                    var contextFeature = context.Features.Get<IExceptionHandlerFeature>();

                    // Si es una excepción de validación, se transpila una respuesta que contenga el error
                    if (contextFeature.Error is ValidationErrorException validationError)
                    {
                        await EmitValidationErrorResponse(
                            context.Response,
                            validationError,
                            validationErrorMessageTranspiler
                        );
                    } else if (contextFeature.Error is RecordChildrenException childrenException)
                    {
                        var errorMessage = "No es posible eliminar, otro registro depende de él";

                        await context.Response.WriteAsync(
                            JsonConvert.SerializeObject(
                                new ValidationErrorResponse(errorMessage)
                            )
                        );
                    } else
                    {
                        await EmitSystemUnhandledErrorResponse(
                            context.Response,
                            contextFeature.Error as Exception
                        );
                    }
                });
            });
        }

        /// <summary>
        /// Emite una respuesta en JSON de un error debido a validación
        /// </summary>
        /// <param name="response">Respuesta que se escribirá</param>
        /// <param name="error">Error de validación arrojado</param>
        /// <param name="errorMessageTranspiler">Transpilador de mensajes amigables a partir de errores</param>
        /// <returns></returns>
        private static async Task EmitValidationErrorResponse(
            HttpResponse response,
            ValidationErrorException error,
            ValidationErrorMessageTranspiler errorMessageTranspiler
        )
        {
            response.StatusCode = (int)HttpStatusCode.BadRequest;

            var errorMessage = errorMessageTranspiler.TranspileFriendlyMessage(error);

            await response.WriteAsync(
                JsonConvert.SerializeObject(
                    new ValidationErrorResponse(errorMessage)
                )
            );
        }

        /// <summary>
        /// Emite una respuesta JSON de un error debido a una excepción no controlada del sistema
        /// </summary>
        /// <param name="response">Respuesta que se escribirá</param>
        /// <param name="systemUnhandledError">Error no manejado</param>
        /// <returns></returns>
        private static Task EmitSystemUnhandledErrorResponse(
            HttpResponse response,
            Exception systemUnhandledError
        ) => response.WriteAsync(
                JsonConvert.SerializeObject(
                    new SystemUnhandledErrorResponse(systemUnhandledError)
                )
            );
    }
}