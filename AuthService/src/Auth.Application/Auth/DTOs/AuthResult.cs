namespace Auth.Application.Auth.DTOs;

public sealed class AuthResult
{
    public Guid UserId { get; init; }
    public string Email { get; init; } = string.Empty;
    public string Role { get; init; } = string.Empty;
    public string Token { get; init; } = string.Empty;
}
