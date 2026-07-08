# Prueba_AHVA

Prueba Laboral

Aplicación ASP.NET Core (.NET 10) con Entity Framework Core y SQL Server. Incluye login con bloqueo por intentos fallidos, expiración de sesión y un perfil de usuario editable.

## Requisitos

- [.NET SDK 10](https://dotnet.microsoft.com/download)
- SQL Server (Express, Developer o LocalDB) corriendo en `localhost`
- Herramienta `dotnet-ef` instalada globalmente:

```bash
dotnet tool install --global dotnet-ef
```

## Cómo montar el proyecto

1. Clonar el repositorio y ubicarse en la carpeta del proyecto.
2. Restaurar los paquetes NuGet:

   ```bash
   dotnet restore
   ```

3. Revisar la cadena de conexión en `appsettings.json` (por defecto apunta a una instancia local de SQL Server llamada `PruebaAHVADb`):

   ```json
   "ConnectionStrings": {
     "DefaultConnection": "Server=localhost;Database=PruebaAHVADb;Trusted_Connection=True;MultipleActiveResultSets=true;TrustServerCertificate=True"
   }
   ```

   Ajusta `Server` si tu instancia de SQL Server tiene otro nombre (por ejemplo `localhost\SQLEXPRESS`).

4. Aplicar las migraciones para crear la base de datos y las tablas (`Usuarios`, `Roles`):

   ```bash
   dotnet ef database update
   ```

5. Ejecutar la aplicación:

   ```bash
   dotnet run
   ```

6. Abrir el navegador en la URL que muestre la consola (por ejemplo `http://localhost:5299`).

## Usuarios disponibles para iniciar sesión

El login se hace con **Usuario** (número de documento) y **Contraseña**, no con correo electrónico.

| Usuario | Contraseña | Rol      |
|---------|------------|----------|
| 28344112 | 28344112  | Operador |
| 123456   | 123456    | Operador |

> Nota de seguridad: tras 5 intentos fallidos consecutivos con el mismo usuario, la cuenta se bloquea automáticamente durante 15 minutos.

## Comandos útiles de migraciones

- Crear una nueva migración después de modificar un modelo:

  ```bash
  dotnet ef migrations add NombreDeLaMigracion
  ```

- Aplicar las migraciones pendientes a la base de datos:

  ```bash
  dotnet ef database update
  ```

- Revertir la base de datos a una migración anterior:

  ```bash
  dotnet ef database update NombreDeLaMigracionAnterior
  ```
