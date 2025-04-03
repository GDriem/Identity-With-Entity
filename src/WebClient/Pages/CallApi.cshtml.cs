using Duende.IdentityModel.Client;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Net.Http.Headers;
using System.Text.Json;

public class CallApiModel(IHttpClientFactory httpClientFactory) : PageModel
{
    public string Json = string.Empty;

    public async Task OnGet()
    {
        var client = httpClientFactory.CreateClient("apiClient");
        var content = await client.GetStringAsync("https://localhost:6001/identity");

        var parsed = JsonDocument.Parse(content);
        var formatted = JsonSerializer.Serialize(parsed, 
            new JsonSerializerOptions { WriteIndented = true });

        Json = formatted;
    }
}
