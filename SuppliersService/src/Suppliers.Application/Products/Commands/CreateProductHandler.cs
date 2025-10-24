using MediatR;
using Suppliers.Application.Abstractions;
using Suppliers.Application.Products.DTOs;
using Suppliers.Domain.Products;

namespace Suppliers.Application.Products.Commands;

public sealed class CreateProductHandler : IRequestHandler<CreateProductCommand, ProductDto>
{
    private readonly IProductRepository _productRepository;

    public CreateProductHandler(IProductRepository productRepository)
    {
        _productRepository = productRepository;
    }

    public async Task<ProductDto> Handle(CreateProductCommand request, CancellationToken cancellationToken)
    {
        var product = Product.Create(request.Name, request.Description, request.Price);
        await _productRepository.AddAsync(product, cancellationToken);

        return new ProductDto
        {
            Id = product.Id,
            Name = product.Name,
            Description = product.Description,
            UnitPrice = product.UnitPrice,
            CreatedAt = product.CreatedAt
        };
    }
}
