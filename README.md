# Aplicación con Frontend en Angular y Backend en .NET 9

## Descripción del Proyecto

Este proyecto consiste en una aplicación web que utiliza Angular para el frontend y C# con .NET 9 para el backend. La base de datos utilizada es PostgreSQL. La comunicación entre el frontend y el backend se realiza mediante API REST.

## Configuración de Variables de Entorno

Para asegurar una configuración flexible y segura, las conexiones a la base de datos y la clave de seguridad para los tokens de autenticación se manejan a través de variables de entorno.

### Variables de Entorno Requeridas:

- ``: MySecretKey : Clave de seguridad utilizada para la generación de tokens JWT.
  - Valor de prueba: `'mGtGpzGWLwKx1KBkye88xrSKOT5uetZVAybWEdUPvwg='`
- ``"DbConnection": Cadena de conexión a la base de datos PostgreSQL.
  - Ejemplo de conexión:
    ```plaintext
    DbConnection=Host=localhost;Port=5432;Database=mi_base;Username=usuario;Password=clave
    ```

## Configuración del Backend en .NET 9

1. Instalar las dependencias necesarias:
   ```sh
   dotnet add package Microsoft.EntityFrameworkCore
   dotnet add package Microsoft.EntityFrameworkCore.Design
   dotnet add package Microsoft.EntityFrameworkCore.Npgsql
   dotnet add package Microsoft.AspNetCore.Authentication.JwtBearer
   ```
4. Configurar la inyección de dependencias en `Program.cs`:
   ```csharp
   builder.Services.AddDbContext<ApplicationDbContext>(options =>
       options.UseNpgsql(Environment.GetEnvironmentVariable("DbConnection")));
   builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
       .AddJwtBearer(options =>
       {
           options.TokenValidationParameters = new TokenValidationParameters
           {
               ValidateIssuerSigningKey = true,
               IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Environment.GetEnvironmentVariable("MySecretKey"))),
               ValidateIssuer = false,
               ValidateAudience = false
           };
       });
   ```

## Configuración del Frontend en Angular

1. Instalar Angular CLI si no lo tienes:
   ```sh
   npm install -g @angular/cli
   ```
2. Crear un nuevo proyecto Angular:
   ```sh
   ng new mi-proyecto-angular
   ```
3. Configurar las variables de entorno en `environment.ts`:
   ```typescript
   export const environment = {
     production: false,
     apiUrl: 'http://localhost:5000/api'
   };
   ```
4. Instalar Axios o HttpClientModule para la comunicación con el backend.
   ```sh
   npm install axios
   ```

## Creación y Carga de la Base de Datos

Para generar la estructura de la base de datos y cargar datos iniciales:

1. Ejecutar el siguiente script SQL en PostgreSQL:
   ```sql
   -- Crear usuario admin por defecto
   INSERT INTO public.usuarios (username, password) VALUES ('admin', 'admin123');
   ```
2. Para cargar la estructura de la base de datos en otro equipo:
   ```sh
   psql -U usuario -d mi_base -f crear_base.sql
   ```

## Ejecución del Proyecto

1. Levantar el backend en .NET 9:
   ```sh
   dotnet run
   ```
2. Iniciar el frontend en Angular:
   ```sh
   ng serve --open
   ```

Ahora la aplicación estará lista para realizar pruebas de autenticación y manejo de productos mediante el usuario **admin** con clave **admin**.

