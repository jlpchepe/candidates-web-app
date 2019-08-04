using ReclutaCVApi.Dtos;
using ReclutaCVApi.Extensions;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;

namespace ReclutaCVApi
{
    public class CoreBackendStartup
    {
        private readonly IConfiguration configuration;

        public CoreBackendStartup(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            //CONFIGURACIÓN NECESARIA PARA INDICAR LA VERSIÓN DE MVC A UTILIZAR
            services.AddMvc(options =>
                {
                    // Cambios para que se lean correctamente las fechas UTC-0 desde la URL
                    options.ModelBinderProviders.Insert(0, new UtcDateTimeModelBinderProvider());
                })
                .SetCompatibilityVersion(CompatibilityVersion.Version_2_2)
                .AddJsonOptions(jsonOptions =>
                {
                    jsonOptions.SerializerSettings.DateTimeZoneHandling = DateTimeZoneHandling.Utc;
                });

            // SE AGREGA LA LÓGICA PARA REALIZAR AUTORIZACIÓN BASADA EN PERMISOS
            var noAuthenticatedUserByPassAuthorization = configuration.GetValue<bool>("NoAuthenticatedUserByPassAuthorization");
            services.AddPermissionBasedAuthorization(noAuthenticatedUserByPassAuthorization);

            // SE AGREGA LA AUTENTICACIÓN BASADA EN JWT
            var jwtConfigurationSection = configuration.GetSection("Jwt");
            var secretKey = jwtConfigurationSection.GetValue<string>("SecretKey");
            var expireDays = jwtConfigurationSection.GetValue<int>("ExpireDays");
            var jwtConfiguration = new JwtConfiguration(secretKey, expireDays);
            services.AddSingleton<JwtConfiguration>(jwtConfiguration);
            services.AddJwtBasedAuthentication(jwtConfiguration);

            // SE AGREGAN LAS DEPENDENCIAS PROPIAS DEL DEL NEGOCIO DE LA APLICACIÓN
            var connectionString = configuration.GetConnectionString("DefaultConnection");
            services.AddBusinessDependencies(connectionString);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            // SE ACTIVA CORS PARA LAS URL DE SITIOS INDICADOS
            app.ConfigureCors();

            // SE ACTIVA LA AUTENTICACIÓN
            app.UseAuthentication();

            // SE CONFIGURA EL MANEJADOR DE EXCEPCIONES DE LA APLICACIÓN
            app.ConfigureExceptionHandler();

            // SE ACTIVA EL USO DE LOS MÉTODOS DE CONTROLADORES COMO ENDPOINTS DE LA API
            app.UseMvc();

        }
    }
}