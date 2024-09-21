# Proyecto de Gestión de Libros

## Descripción

Este es un proyecto básico en .NET que implementa un sistema de gestión de libros, permitiendo realizar operaciones CRUD (Crear, Leer, Actualizar, Eliminar) para tres entidades principales: **Categorías**, **Autores** y **Libros**.

## Funcionalidades

- **Categorías**: Gestiona las categorías de los libros. Permite crear, leer, actualizar y eliminar categorías.
- **Autores**: Maneja la información de los autores. También permite realizar operaciones CRUD.
- **Libros**: Permite gestionar los libros, incluyendo el título, la descripción, la categoría y el autor. Se pueden crear, leer, actualizar y eliminar libros.


### Implementación de Clean Code

El código sigue los principios de **Clean Code**, lo que significa que:

- **Legibilidad**: El código está escrito de manera clara y concisa, utilizando nombres descriptivos para funciones y variables, lo que facilita la comprensión.
- **Modularidad**: El código se divide en funciones y clases pequeñas que realizan una única tarea, lo que permite una mejor mantenibilidad.
- **Comentarios**: Se utilizan comentarios adecuados para explicar el propósito de secciones de código más complejas, sin abusar de ellos.


## Tecnologías Usadas

- **.NET (última versión)**: Framework para desarrollar aplicaciones.
- **C#**: Lenguaje de programación utilizado en el desarrollo.
- **Entity Framework Core**: ORM utilizado para interactuar con la base de datos.
- **SQL Server**: Sistema de gestión de bases de datos utilizado para almacenar la información.
- **ASP.NET Core**: Utilizado para construir la API RESTful que gestiona las operaciones CRUD.

## Instalación

Sigue estos pasos para configurar el proyecto en tu entorno local:

1. **Clona el repositorio**:
   - Abre una terminal y ejecuta el siguiente comando:
     ```bash
     git clone https://github.com/Jacom3dev/LibraryManager.git
     ```

2. **Navega a la carpeta del proyecto**:
   - Cambia al directorio del proyecto:
     ```bash
     cd LibraryManager
     ```

3. **Configura la conexión a la base de datos**:
   - Abre el archivo `appsettings.json` y localiza la propiedad `DbConexion`. Aquí debes poner la URL de tu base de datos local o del servidor.

4. **Restaura las dependencias**:
   - Ejecuta el siguiente comando para restaurar las dependencias:
     ```bash
     dotnet restore
     ```

5. **Crea la base de datos y aplica las migraciones**:
   - Ejecuta el siguiente comando para crear la base de datos y aplicar las migraciones:
     ```bash
     dotnet ef database update
     ```

6. **Ejecuta la aplicación**:
   - Inicia la aplicación con el siguiente comando:
     ```bash
     dotnet run
     ```

7. **Accede a la API**:
   - Abre tu navegador y dirígete a `http://localhost:5000` (o el puerto que esté configurado).
