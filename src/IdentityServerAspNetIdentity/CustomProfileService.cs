using Duende.IdentityServer.AspNetIdentity;
using Duende.IdentityServer.Models;
using IdentityServerAspNetIdentity.Models;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;

namespace IdentityServerAspNetIdentity
{
    public class CustomProfileService : ProfileService<ApplicationUser>
    {
        public CustomProfileService(UserManager<ApplicationUser> userManager,
            IUserClaimsPrincipalFactory<ApplicationUser> claimsFactory) : 
            base(userManager, claimsFactory)
        {
        }

        protected override async Task GetProfileDataAsync(ProfileDataRequestContext context,
            ApplicationUser user)
        {
            var principal = await GetUserClaimsAsync(user);
            var id = principal.Identity as ClaimsIdentity;
            if (id != null && !string.IsNullOrEmpty(user.FavoriteColor) && !string.IsNullOrEmpty(user.Company))
            {
                id.AddClaim(new Claim("favorite_color", user.FavoriteColor));
                id.AddClaim(new Claim("company", user.Company));
            }

            context.AddRequestedClaims(principal.Claims);
        }
    }
}
