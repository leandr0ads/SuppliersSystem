using MediatR;
using Suppliers.Application.Abstractions;
using Suppliers.Application.Suppliers.DTOs;
using Suppliers.Domain.Suppliers;

namespace Suppliers.Application.Suppliers.Commands;

public sealed class CreateSupplierHandler : IRequestHandler<CreateSupplierCommand, SupplierDto>
{
    private readonly ISupplierRepository _supplierRepository;

    public CreateSupplierHandler(ISupplierRepository supplierRepository)
    {
        _supplierRepository = supplierRepository;
    }

    public async Task<SupplierDto> Handle(CreateSupplierCommand request, CancellationToken cancellationToken)
    {
        var supplier = Supplier.Create(request.Name, request.Cnpj, request.Email);
        await _supplierRepository.AddAsync(supplier, cancellationToken);

        return new SupplierDto
        {
            Id = supplier.Id,
            Name = supplier.Name,
            Cnpj = supplier.Cnpj,
            Email = supplier.Email,
            CreatedAt = supplier.CreatedAt
        };
    }
}
