# SNetWE

Proyecto de escritorio en C# (.NET Framework 4.8) — sistema de gestión (clientes, productos, arriendos, proveedores, usuarios).

## Descripción
Aplicación Windows Forms multi-capa organizada en proyectos: `Presentacion`, `Negocio`, `Datos`, `Entidad`.
Incluye reportes Crystal Reports y lógica para manejo de stock, clientes y generación de arriendos.

## Estructura
- `Presentacion/` - Interfaz Windows Forms.
- `Negocio/` - Lógica de aplicación.
- `Datos/` - Acceso a datos (procedimientos almacenados SQL Server).
- `Entidad/` - Clases DTO / entidades.

## Requisitos
- Visual Studio 2019 o 2022 (soporta .NET Framework 4.8).
- .NET Framework 4.8 (target del proyecto).
- SQL Server (local o remoto) con las tablas y procedimientos almacenados que usa la aplicación.
- Crystal Reports runtime (si desea generar/visualizar reportes desde la app).

```csharp
public static string Conex = "Data Source=.;Initial Catalog=SNet;Integrated Security=True";
```

```xml
<connectionStrings>
  <add name="SNet" connectionString="Data Source=.;Initial Catalog=SNet;Integrated Security=True" providerName="System.Data.SqlClient" />
</connectionStrings>
```

Y en código usar:

```csharp
using System.Configuration;
public static string Conex => ConfigurationManager.ConnectionStrings["SNet"].ConnectionString;
```

## Compilar y ejecutar
1. Abrir la solución en Visual Studio.
2. Restaurar paquetes NuGet si es necesario.
3. Seleccionar proyecto de inicio `Presentacion` y compilar (Build -> Rebuild Solution).
4. Configurar la cadena de conexión para apuntar a su servidor SQL y asegúrese de que los procedimientos almacenados / tablas existan.
5. Ejecutar la aplicación.
