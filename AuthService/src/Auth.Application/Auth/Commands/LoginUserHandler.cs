using MediatR;
using Auth.Application.Abstractions;
using Auth.Application.Auth.DTOs;
using Auth.Domain.Users;

namespace Auth.Application.Auth.Commands;

public sealed class LoginUserHandler : IRequestHandler<LoginUserCommand, AuthResult>
{
    private readonly IUserRepository _userRepository;
    private readonly IPasswordHasher _passwordHasher;
    private readonly IJwtProvider _jwtProvider;

    public LoginUserHandler(IUserRepository userRepository, IPasswordHasher passwordHasher, IJwtProvider jwtProvider)
    {
        _userRepository = userRepository;
        _passwordHasher = passwordHasher;
        _jwtProvider = jwtProvider;
    }

    public async Task<AuthResult> Handle(LoginUserCommand request, CancellationToken cancellationToken)
    {
        var user = await _userRepository.GetByEmailAsync(request.Email, cancellationToken);
        if (user is null)
            throw new InvalidOperationException("Invalid credentials.");

        var isValid = _passwordHasher.Verify(request.Password, user.PasswordHash.Value);
        if (!isValid)
            throw new InvalidOperationException("Invalid credentials.");

        var token = _jwtProvider.GenerateToken(user);

        return new AuthResult
        {
            UserId = user.Id,
            Email = user.Email.Value,
            Role = user.Role.ToString(),
            Token = token
        };
    }
}
