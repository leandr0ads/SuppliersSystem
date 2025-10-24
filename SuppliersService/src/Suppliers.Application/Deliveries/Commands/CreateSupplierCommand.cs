using MediatR;
using Suppliers.Application.Suppliers.DTOs;

namespace Suppliers.Application.Suppliers.Commands;

public sealed record CreateSupplierCommand(string Name, string Cnpj, string Email)
    : IRequest<SupplierDto>;
