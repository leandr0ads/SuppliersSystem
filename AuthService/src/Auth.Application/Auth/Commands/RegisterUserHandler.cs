using MediatR;
using Auth.Application.Abstractions;
using Auth.Application.Auth.DTOs;
using Auth.Domain.Users;

namespace Auth.Application.Auth.Commands;

public sealed class RegisterUserHandler : IRequestHandler<RegisterUserCommand, AuthResult>
{
    private readonly IUserRepository _userRepository;
    private readonly IPasswordHasher _passwordHasher;
    private readonly IJwtProvider _jwtProvider;

    public RegisterUserHandler(IUserRepository userRepository, IPasswordHasher passwordHasher, IJwtProvider jwtProvider)
    {
        _userRepository = userRepository;
        _passwordHasher = passwordHasher;
        _jwtProvider = jwtProvider;
    }

    public async Task<AuthResult> Handle(RegisterUserCommand request, CancellationToken cancellationToken)
    {
        var existing = await _userRepository.GetByEmailAsync(request.Email, cancellationToken);
        if (existing is not null)
            throw new InvalidOperationException("User already exists.");

        var email = Email.Create(request.Email);
        var hash = PasswordHash.From(_passwordHasher.Hash(request.Password));

        var role = Enum.TryParse<Role>(request.Role ?? nameof(Role.User), true, out var parsedRole)
            ? parsedRole
            : Role.User;

        var user = User.Create(email, hash, role);

        await _userRepository.AddAsync(user, cancellationToken);

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
