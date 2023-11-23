# usersCrudBackend
backend project for user management


Instrucciones Detalladas para Iniciar la Aplicación y la Base de Datos SQL Server con Docker Compose
Utilizando Visual Studio
Abrir la Solución en Visual Studio:

Inicia Visual Studio.
Abre la solución que contiene el proyecto.
Configurar el Proyecto de Docker-Compose como Proyecto de Inicio:

En el Explorador de Soluciones, busca el proyecto docker-compose.
Haz clic derecho sobre él y selecciona "Establecer como proyecto de inicio".
Ejecutar la Solución:

Presiona F5 o haz clic en el botón "Iniciar" para ejecutar la solución.
Esto iniciará todos los servicios definidos en tu archivo docker-compose.yml, incluyendo tu aplicación y la base de datos SQL Server.
Utilizando la Terminal
Si prefieres usar la terminal, sigue estos pasos:

Abrir la Terminal:

Abre una terminal o línea de comandos.
Navegar al Directorio del Proyecto:

Utiliza el comando cd para navegar al directorio raíz de tu proyecto.
cd ruta/a/tu/proyecto
Construir los Servicios con Docker Compose:

Ejecuta el siguiente comando para construir los servicios definidos en tu archivo docker-compose.yml.

docker-compose build

Iniciar los Servicios:

Una vez construidos, inicia los servicios con el siguiente comando.

docker-compose up

Este comando iniciará todos los servicios, incluyendo tu aplicación y la base de datos SQL Server.
Verificar el Estado de los Servicios:

Puedes verificar que los servicios estén funcionando correctamente observando la salida en la terminal.
Además, puedes utilizar herramientas como Docker Desktop para visualizar y administrar tus contenedores.
