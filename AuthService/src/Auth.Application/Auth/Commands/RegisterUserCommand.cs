using MediatR;
using Auth.Application.Auth.DTOs;

namespace Auth.Application.Auth.Commands;

public sealed record RegisterUserCommand(string Email, string Password, string? Role = null)
    : IRequest<AuthResult>;
