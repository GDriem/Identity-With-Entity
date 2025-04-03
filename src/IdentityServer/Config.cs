using Duende.IdentityServer;
using Duende.IdentityServer.Models;

namespace IdentityServer;

public static class Config
{
    public static IEnumerable<IdentityResource> IdentityResources =>
        new IdentityResource[]
        {
            new IdentityResources.OpenId(),
            new IdentityResources.Profile(),
        };

 public static IEnumerable<ApiScope> ApiScopes =>
    new ApiScope[]
    {
        new ApiScope(name: "api1", displayName: "My API"),
        new ApiScope("verification", "Verification Scope") // Add this line
  
    };
    public static IEnumerable<Client> Clients =>
        new List<Client>
        {
        // machine to machine client (from quickstart 1)
        //new Client
        //{
        //    ClientId = "client",
        //    ClientSecrets = { new Secret("secret".Sha256()) },

        //    AllowedGrantTypes = GrantTypes.ClientCredentials,
        //    // scopes that client has access to
        //    AllowedScopes = { "api1" }
        //},
        // interactive ASP.NET Core Web App
        new Client
        {
            ClientId = "web",
            ClientSecrets = { new Secret("secret".Sha256()) },

            AllowedGrantTypes = GrantTypes.Code,
            RedirectUris = { "https://localhost:5002/signin-oidc" },
            PostLogoutRedirectUris = { "https://localhost:5002/signout-callback-oidc" },

            AccessTokenLifetime = 20,
            AllowOfflineAccess = true,

            AllowedScopes =
            {
                IdentityServerConstants.StandardScopes.OpenId,
                IdentityServerConstants.StandardScopes.Profile,
                     "verification",
                     "api1"
            }
        }
        };

}
