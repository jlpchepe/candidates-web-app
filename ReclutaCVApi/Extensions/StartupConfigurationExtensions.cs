using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Threading.Tasks;
using ReclutaCVApi.Authorization;
using ReclutaCVApi.Dtos;
using ReclutaCVApi.WebSockets;
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

namespace ReclutaCVApi.Extensions
{
    /// <summary>
    /// Extension methods used in the Startup class
    /// </summary>
    internal static class StartupConfigurationExtensions
    {
        private static string GetWorkOrderWebSocketPath() => "/WorkOrderHub";

        private static string GetSystemWebSocketPath() => "/NotificationHub";

        public static void UseSignalR(this IApplicationBuilder app)
        {
            app.UseSignalR(routes =>
            {
                // MAPS INCOMING REQUESTS TO THE SPECIFIED PATH TO THE SPECIFIED HUB TYPE
                routes.MapHub<SystemWebSocket>(GetSystemWebSocketPath());
                routes.MapHub<WorkOrderWebSocket>(GetWorkOrderWebSocketPath());
            });
        }

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

                // We have to hook the OnMessageReceived event in order to
                // allow the JWT authentication handler to read the access
                // token from the query string when a WebSocket or
                // Server-Sent Events request comes in.
                options.Events = new JwtBearerEvents
                {
                    OnMessageReceived = context =>
                    {
                        // If the request is for our hub...
                        var path = context.HttpContext.Request.Path.Value;

                        if (
                            path.Contains(GetSystemWebSocketPath()) ||
                            path.Contains(GetWorkOrderWebSocketPath())
                        )
                        {
                            // Read the token out of the query string
                            var accessToken = context.Request.Query["access_token"];
                            context.Token = accessToken;
                        }

                        return Task.CompletedTask;
                    }
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
            services.AddSingleton<WorkOrderBoardRepository, DbWorkOrderBoardRepository>();

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
            var appLogicServicesNamespace = typeof(WorkstationService);
            AddNamespaceClassesAsScoped(appLogicServicesNamespace.Assembly, appLogicServicesNamespace.Namespace);

            // PARA QUE A LOS SERVICIOS SE LES PUEDA INYECTAR INFORMACIÓN SOBRE LA SESIÓN ACTUAL, SE HABILITA ESTE ACCESOR
            services.TryAddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddScoped(sp =>
            {
                var requestContext = sp.GetRequiredService<IHttpContextAccessor>();
                // El contexto HTTP podría ser null si este servicio no se llama debido a una petición
                var userId = AuthenticationHelper.GetAuthenticatedUserId(requestContext.HttpContext?.User);
                return new CurrentAuthenticatedUser(userId);
            });

            // SE AGREGADOR EL AGREGADOR DE EVENTOS PARA REGULAR LA SUSCRIPCIÓN Y PUBLICACIÓN DE EVENTOS
            services.AddScoped<GenericEventAggregator>();
            services.AddScoped<EventAggregatorPublisher>(sp => sp.GetRequiredService<GenericEventAggregator>());

            // SE AGREGA EL ADMINISTRADOR DE TAREAS DISPARADAS POR TEMPORIZADOR
            services.AddSingleton<TimerWatchdogTaskAggregatorService>();

            // AGREGAMOS LOS GENERADORES DE LA CAPA DE REPORTES
            // OBTENEMOS EL TIPO DE ALGUNA CLASE QUE SE ENCUENTRE DENTRO DEL ESPACIO DE NOMBRE <see cref="AppReports.Generators"/>
            var appReportGeneratorsNamespace = typeof(ServiceOrderReportGenerator);
            AddNamespaceClassesAsScoped(appReportGeneratorsNamespace.Assembly, appReportGeneratorsNamespace.Namespace);

            // SE AGREGA EL VALIDADOR DE CONTRASEÑAS
            services.AddScoped<UserPasswordValidator>();

            // SE AGREGAN LAS CLASES DE LOS WEBSOCKETS AL CONTENEDOR
            services.AddSingleton<SystemWebSocket>();
            services.AddSingleton<WorkOrderWebSocket>();
        }

        public static void SubscribeServicesToEventAggregator(IServiceProvider sp)
        {
            var eventAggregatorSubcribers = new HashSet<object>()
                {
                    sp.GetRequiredService<WorkOrderWebSocket>(),
                    sp.GetRequiredService<SystemWebSocket>(),
                    sp.GetRequiredService<NotificationService>(),
                    sp.GetRequiredService<EventLogService>(),
                    sp.GetRequiredService<TimerWatchdogAssistantService>()
                };

            var eventAggregator = sp.GetRequiredService<GenericEventAggregator>();

            // SE SUSCRIBE LOS SERVICIOS AL AGREGADOR DE EVENTOS
            eventAggregator.Subscribe(eventAggregatorSubcribers);
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