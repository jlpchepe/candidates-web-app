# Comandos útiles del proyecto

## Iniciar la aplicación por primera vez
`npm run install:start`

## Iniciar la aplicación, con HMR
`npm start`

## Iniciar la aplicación, sin HMR
`npm run start-no-hmr`

## Solo generar archivos de despliegue
`npm run build`

## Limpiar el código de errores y malas prácticas de codificación
`npm run clean-code`

## Generar una versión desplegable con Express.js
Se puede generar un distribuible de esta aplicación. Se usa Express.js para servir la aplicación en un puerto con HTTP.
El servidor en el cual se despliegue este distribuible debe contar con Node.js.

Para generar el distribuible, ejecutar el siguiente comando:
`npm run build`

En la carpeta "serve/dist" se depositarán todos los archivos necesarios para hacer el despliegue.
Para desplegar en el servidor, desde la línea de comandos estando en la carpeta donde se pegaron los archivos del distribuible, se debe ejecutarse lo siguiente:
`node index.js`

Asegurarse que el puerto de la aplicación están abiertos en el servidor

# Tecnologías y filosofía del proyecto
El proyecto está construido utilizando TypeScript y React.

Se hizo un esfuerzo para que las ventanas de negocio dependan en lo mínimo de componentes nativos de HTML. Esto para poder dejar lo más adaptativa posible la aplicación.

# Distribución del código por carpetas
El código está distribuido en carpetas, donde cada una almacena:
## Communication
Los DTO, enums y servicios de los que depende la aplicación externamente. 
Es decir, los servicios que se comunican con la RESTful API.
Los DTO y enums que utilice la aplicación, pero no sean parte de la API, deben estar fuera de esta carpeta.

## Components
Los componentes de React de la aplicación. Dentro contiene un subconjunto de carpetas.
### Domain
Define las ventanas y demás componentes especializados en el negocio.
### Generic
Esta carpeta es de vital relevancia. Son componentes que envuelven a los elementos HTML nativos. Esto para que las ventanas de negocio no dependan de elementos nativos, aumentando con ello la adaptabilidad de la aplicación considerablemente.
### Hoc
Define componentes de alto orden de React.
### Layout
Contiene componentes cuyo proposito es ocupar un lugar en la forma en la que se distribuye la aplicación. Aquí va están la barra lateral, cabecera, cuerpo, pie de página, etc.

## Helpers
Métodos de ayuda útiles para trabajar algunos tipos de datos y realizar funciones comunmente usadas en la aplicación.

## Assets
Esta carpeta contiene elementos visuales de la aplicación como las hojas de estilo, imágenes, vendors, etc.

### Img
Imágenes de la aplicación.

### Scss
Contiene las hojas de estilo del proyecto donde se distribuyen en carpetas, donde cada una almacena:

- Core
  - Son los estilos modificados del framewok utilizado (Bootstrap).

- Generic
  - Son los estilos que son propios de cada componente genérico.
  
# Estándares de codificación
## Es necesario instalar la extensión ESLint de VS Code, para que se marquen validaciones de estilos

https://marketplace.visualstudio.com/items?itemName=dbaeumer.vscode-eslint

## Para que VSCode marque errores del código con respecto al estándar, está esta configuración en el settings del workspace

"eslint.validate": [
    "javascript",
    "javascriptreact",
    {"language": "typescript", "autoFix": true},
    {"language": "typescriptreact", "autoFix": true}
]

## Limpiar el código según los estándares de codificación

`npm run clean-code`
