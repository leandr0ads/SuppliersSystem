using Auth.Domain.Users;

namespace Auth.Application.Abstractions;

public interface IJwtProvider
{
    string GenerateToken(User user);
}
