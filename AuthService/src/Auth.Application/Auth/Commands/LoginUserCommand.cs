using MediatR;
using Auth.Application.Auth.DTOs;

namespace Auth.Application.Auth.Commands;

public sealed record LoginUserCommand(string Email, string Password)
    : IRequest<AuthResult>;
