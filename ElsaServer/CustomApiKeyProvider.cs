using System.Security.Claims;
using AspNetCore.Authentication.ApiKey;
using Elsa.Identity.Models;

public class CustomApiKeyProvider : IApiKeyProvider
{
    private readonly Dictionary<string, (string owner, string[] roles)> _apiKeys = new()
    {
        { "my-secret-api-key", ("Admin User", new[] { "Admin" }) },
        { "another-api-key", ("Read-Only User", new[] { "Reader" }) }
    };

    public Task<IApiKey?> ProvideAsync(string key)
    {
        // Check if the API key exists
        if (_apiKeys.TryGetValue(key, out var userInfo))
        {
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, userInfo.owner),
                new Claim(ClaimTypes.NameIdentifier, userInfo.owner)
            };
            
            // Add role claims
            foreach (var role in userInfo.roles)
            {
                claims.Add(new Claim(ClaimTypes.Role, role));
            }
            
            var apiKey = new ApiKey(key, userInfo.owner, claims);
            return Task.FromResult<IApiKey?>(apiKey);
        }

        return Task.FromResult<IApiKey?>(null);
    }
}