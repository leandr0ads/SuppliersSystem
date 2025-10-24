using System.Security.Claims;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.Server.ProtectedBrowserStorage;
using SuppliersPortal.Models;

namespace SuppliersPortal.Services;

public class JwtAuthStateProvider : AuthenticationStateProvider
{
    private readonly ProtectedSessionStorage _sessionStorage;

    public JwtAuthStateProvider(ProtectedSessionStorage sessionStorage)
    {
        _sessionStorage = sessionStorage;
    }

    public override async Task<AuthenticationState> GetAuthenticationStateAsync()
    {
        try
        {
            var result = await _sessionStorage.GetAsync<AuthResponse>("authUser");

            if (!result.Success || result.Value is null)
                return new AuthenticationState(new ClaimsPrincipal(new ClaimsIdentity()));

            var user = result.Value;

            var claims = new[]
            {
                new Claim(ClaimTypes.NameIdentifier, user.UserId.ToString()),
                new Claim(ClaimTypes.Name, user.Email),
                new Claim(ClaimTypes.Role, user.Role)
            };

            var identity = new ClaimsIdentity(claims, "jwt");
            var principal = new ClaimsPrincipal(identity);

            return new AuthenticationState(principal);
        }
        catch
        {
            return new AuthenticationState(new ClaimsPrincipal(new ClaimsIdentity()));
        }
    }

    public async Task SetUserAsync(AuthResponse? user)
    {
        if (user == null)
            await _sessionStorage.DeleteAsync("authUser");
        else
            await _sessionStorage.SetAsync("authUser", user);

        NotifyAuthenticationStateChanged(GetAuthenticationStateAsync());
    }
}
