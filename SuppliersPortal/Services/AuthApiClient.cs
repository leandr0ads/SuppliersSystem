using System.Net.Http.Json;
using SuppliersPortal.Models;

namespace SuppliersPortal.Services;

public class AuthApiClient
{
    private readonly HttpClient _http;

    public AuthApiClient(IConfiguration config)
    {
        var baseUrl = config["AuthApi:BaseUrl"] ?? throw new ArgumentNullException("AuthApi:BaseUrl");
        _http = new HttpClient { BaseAddress = new Uri(baseUrl) };
    }

    public async Task<AuthResponse?> LoginAsync(LoginRequest request)
    {
        var response = await _http.PostAsJsonAsync("auth/login", request);
        response.EnsureSuccessStatusCode();
        return await response.Content.ReadFromJsonAsync<AuthResponse>();
    }

    public async Task<AuthResponse?> RegisterAsync(RegisterRequest request)
    {
        var response = await _http.PostAsJsonAsync("auth/register", request);
        response.EnsureSuccessStatusCode();
        return await response.Content.ReadFromJsonAsync<AuthResponse>();
    }
}
