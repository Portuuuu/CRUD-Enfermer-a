# ?? Proyecto de Enfermer�a - CRUD ASP.NET Core MVC

Este es un sistema de gesti�n de personas para un entorno de enfermer�a, desarrollado en **ASP.NET Core MVC 8.0**, con integraci�n a **SQL Server**.
Permite crear, listar, editar, reactivar y buscar personas.


## ?? Caracter�sticas

- Crear, editar, eliminar y ver detalles de personas.
- Desactivaci�n l�gica en lugar de eliminaci�n f�sica (`Activo = false`).
- Listado separado de personas inactivas.
- Reactivaci�n de personas.
- Dise�o responsive con **Bootstrap**.
- CRUD completo con vistas Razor (`.cshtml`).
- Integraci�n con Entity Framework Core.



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




