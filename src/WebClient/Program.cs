using Microsoft.AspNetCore.Authentication;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddOpenIdConnectAccessTokenManagement();
builder.Services.AddUserAccessTokenHttpClient("apiClient", configureClient: client =>
{
    client.BaseAddress = new Uri("https://localhost:6001/");
   // client.DefaultRequestHeaders.Add("Accept", "application/json");
});


builder.Services.AddAuthentication(options =>
{
    options.DefaultScheme = "Cookies";
    options.DefaultChallengeScheme = "oidc";
})
    .AddCookie("Cookies")
    .AddOpenIdConnect("oidc", options =>
    {
        options.Authority = "https://localhost:5001";

        options.ClientId = "web";
        options.ClientSecret = "secret";
        options.ResponseType = "code";

        options.Scope.Clear();
        options.Scope.Add("openid");
        options.Scope.Add("profile");
        options.Scope.Add("offline_access");
        options.Scope.Add("api1");
        options.Scope.Add("color");
        options.Scope.Add("company");
        options.Scope.Add("verification");

        options.ClaimActions.MapJsonKey("email_verified", "email_verified");
        options.GetClaimsFromUserInfoEndpoint = true; 
        options.ClaimActions.MapUniqueJsonKey("favorite_color", "favorite_color");
        options.ClaimActions.MapUniqueJsonKey("company", "company");

        options.MapInboundClaims = false; 

        options.SaveTokens = true;

        // Enable PKCE
        options.UsePkce = true;
    });


var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();

app.MapRazorPages().RequireAuthorization();

app.Run();
