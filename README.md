# ?? Proyecto de Enfermería - CRUD ASP.NET Core MVC

Este es un sistema de gestión de personas para un entorno de enfermería, desarrollado en **ASP.NET Core MVC 8.0**, con integración a **SQL Server**.
Permite crear, listar, editar, reactivar y buscar personas.


## ?? Características

- Crear, editar, eliminar y ver detalles de personas.
- Desactivación lógica en lugar de eliminación física (`Activo = false`).
- Listado separado de personas inactivas.
- Reactivación de personas.
- Diseño responsive con **Bootstrap**.
- CRUD completo con vistas Razor (`.cshtml`).
- Integración con Entity Framework Core.



## ?? Estructura del Proyecto

Enfermeria/
??? Controllers/
? ??? EnfPersonasController.cs
??? Models/
? ??? EnfPersona.cs
??? Views/
? ??? EnfPersonas/
? ??? Index.cshtml
? ??? Create.cshtml
? ??? Edit.cshtml
? ??? Delete.cshtml
? ??? Details.cshtml
? ??? Inactivos.cshtml
??? Data/
? ??? EnfermeriaContext.cs
??? README.md




## ??? Requisitos

- Visual Studio 2022
- .NET 8.0 SDK
- SQL Server (Management Studio 21 )
- Bootstrap 5 




