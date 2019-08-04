# Proyecto backend de la aplicación

# Estructura del proyecto
## Proyectos
* app-backend-user: Expone la API que necesita la aplicación web destinada para uso del controlista. 
También se encarga de implementar los protocolos de autenticación y hacer validación de roles.
* app-logic: Implementa toda la lógica de negocio. 
Aquí NO deben de estar directamente consultas a la base de datos, todo debe realizarse mediante repositorios.
* app-reports: Implementa la generación y exportación de reportes a PDF y Excel. 
No deben de incluir consultas a la base de datos, este proyecto solo ha de recibir POCOs y generar los reportes a partir de ellos.
* app-persistence: Encargado de la comunicación con la base de datos. 
Se encarga de persistir y recuperar información que necesita el sistema.

## Jerarquía de proyetos
Los proyectos tienen el siguiente árbol de dependencias:
~~~~
    app-backend-user
    | +-- app-logic
    | | +-- app-reports
    | | +-- app-persistence
~~~~
El proyecto de backend depende del de lógica. Mientras que el de lógica del de reportes y de persistencia. 
Los proyectos de reportes y de persistencia no tienen dependencias de otros proyectos.
Bajo ninguna circunstancia debe crearse una dependencia adicional entre estos proyectos.

# Sobre la reportería
## Crear un nuevo reporte
Los reportes están hechos con la tecnología ReportViewer, en el formato RDLC. Estos reportes se pueden crear y modificar utilizando la siguiente extensión de Visual Studio:

https://marketplace.visualstudio.com/items?itemName=ProBITools.MicrosoftRdlcReportDesignerforVisualStudio-18001

Los reportes deben colocarse en la carpeta "Reports" del proyecto de reportes.

# Buenas prácticas de codificación
## Sobre Entity Framework Core
### Crear un índice único
Hay dos maneras de crear un índice único con Fluent API en la clase DbContext. 
1. La forma recomendada es:
~~~~
protected override void OnModelCreating(ModelBuilder modelBuilder)
{
    ...
    modelBuilder.Entity<Entity>().HasIndex(b => b.PropertyName).IsUnique();
    ...
}
~~~~

2. Por otro lado lo siguiente realiza cuando se desea utilizar el índice único como llave foránea. Cabe destacar que de esta forma EF no hará actualizaciones (UPDATE) sobre la columna aunque en tiempo de ejecución se le realicen modificaciones.
~~~~
protected override void OnModelCreating(ModelBuilder modelBuilder)
{
    ...
    modelBuilder.Entity<Entity>().HasAlternateKey(b => b.PropertyName);
    ...
}
~~~~