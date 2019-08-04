using System;
using System.Threading.Tasks;
using ReclutaCVApi.Extensions;
using AppPersistence.Services;
using AppPersistence;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace ReclutaCVApi
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var webHost = CreateWebHostBuilder(args).Build();

            using (var scope = webHost.Services.CreateScope())
            {
                // Abrimos el contexto por primera vez de forma disparar y olvidar para que no retrase el resto de procesos
                // Ya que la primera creación del contexto en EF toma bastante tiempo
                var dbContext = scope.ServiceProvider.GetRequiredService<Func<Db>>()();
                // Nos aseguramos de que todas las migraciones estén ejecutadas en la base de datos a la que se apunta
                await dbContext.Database.MigrateAsync();

                // Habilitamos al agregador de eventos
                StartupConfigurationExtensions.SubscribeServicesToEventAggregator(
                    scope.ServiceProvider
                );

                // Se cargan todas las tareas de temporizador pendientes de ser disparadas
                await scope.ServiceProvider
                    .GetRequiredService<TimerTasksLoaderService>()
                    .LoadAllPendingTimerTasks();
            }

            // Se ejecuta el WebHost, e inicia la aceptación de peticiones
            // Hay una carga asincrona, así que aquí se ejecuta WebHost de esta manera
            await webHost.RunAsync();
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args).UseStartup<CoreBackendStartup>();
    }
}
