using MediatR;
using Suppliers.Application.Products.DTOs;

namespace Suppliers.Application.Products.Commands;

public sealed record CreateProductCommand(string Name, string Description, decimal Price)
    : IRequest<ProductDto>;
