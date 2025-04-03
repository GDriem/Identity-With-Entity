# UI-Client-Login

Este proyecto es un ejemplo funcional de un cliente con interfaz de usuario (`UI Client`) utilizando **IdentityServer 7** para autenticación interactiva basada en OpenID Connect.  
Fue desarrollado por [GDriem](https://github.com/GDriem) siguiendo el Quickstart oficial de IdentityServer.

🔗 Quickstart de referencia:  
[https://docs.duendesoftware.com/identityserver/v7/quickstarts/2_interactive/](https://docs.duendesoftware.com/identityserver/v7/quickstarts/2_interactive/)

---

## 🛠 Tecnologías utilizadas

- .NET 8
- IdentityServer 7 (Duende Software)
- ASP.NET Core MVC
- Razor Pages
- OpenID Connect (OIDC)

---

## 🎯 Objetivo

Implementar un **cliente web MVC** que se autentica con un servidor de identidad (IdentityServer) mediante el flujo de autorización (Authorization Code Flow).  
El objetivo principal es comprender cómo realizar una integración segura y conforme a los estándares actuales de autenticación.

---

## 📦 Estructura del repositorio
UI-Client-Login/ ├── Controllers/ ├── Views/ ├── wwwroot/ ├── Program.cs ├── appsettings.json


---

## 🧪 ¿Qué incluye este ejemplo?

- Redirección al servidor de identidad para login.
- Autenticación interactiva usando OpenID Connect.
- Recuperación del token de acceso y del ID token.
- Logout remoto (finaliza la sesión también en IdentityServer).
- Uso de cookies para manejar la sesión local del usuario autenticado.

---

## 🔐 Requisitos previos

- Tener un servidor de **IdentityServer** corriendo localmente o remotamente (puedes usar el [Quickstart 1 - IdentityServer](https://docs.duendesoftware.com/identityserver/v7/quickstarts/1_client_credentials/)).
- El servidor debe tener registrado este cliente MVC en su configuración con los siguientes valores (ejemplo):

## csharp
new Client
{
    ClientId = "mvc",
    ClientSecrets = { new Secret("secret".Sha256()) },
    AllowedGrantTypes = GrantTypes.Code,
    RedirectUris = { "https://localhost:5002/signin-oidc" },
    PostLogoutRedirectUris = { "https://localhost:5002/signout-callback-oidc" },
    AllowedScopes = { "openid", "profile" }
}

## 🚀 Cómo ejecutar
Clona este repositorio:

## bash
Copy
Edit
git clone https://github.com/GDriem/UI-Client-Login.git
Configura el appsettings.json o Program.cs con los valores correctos de tu IdentityServer (authority, clientId, etc).

## Ejecuta el proyecto:

bash
Copy
Edit
dotnet run
Abre tu navegador en https://localhost:5002 y prueba el flujo de autenticación.

## 🧠 Créditos
Basado en el Quickstart oficial de Duende IdentityServer:
Interactive Login Quickstart


