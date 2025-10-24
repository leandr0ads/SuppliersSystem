using MediatR;
using Suppliers.Application.Abstractions;
using Suppliers.Application.Deliveries.DTOs;
using Suppliers.Domain.Deliveries;

namespace Suppliers.Application.Deliveries.Commands;

public sealed class RegisterDeliveryHandler : IRequestHandler<RegisterDeliveryCommand, DeliveryDto>
{
    private readonly IDeliveryRepository _deliveryRepository;

    public RegisterDeliveryHandler(IDeliveryRepository deliveryRepository)
    {
        _deliveryRepository = deliveryRepository;
    }

    public async Task<DeliveryDto> Handle(RegisterDeliveryCommand request, CancellationToken cancellationToken)
    {
        var delivery = Delivery.Create(request.SupplierId, request.ProductId, request.Quantity, request.DeliveryDate);
        await _deliveryRepository.AddAsync(delivery, cancellationToken);

        return new DeliveryDto
        {
            Id = delivery.Id,
            SupplierId = delivery.SupplierId,
            ProductId = delivery.ProductId,
            Quantity = delivery.Quantity,
            DeliveryDate = delivery.DeliveryDate
        };
    }
}
