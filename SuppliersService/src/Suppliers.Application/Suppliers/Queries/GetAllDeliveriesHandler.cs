using MediatR;
using Suppliers.Application.Abstractions;
using Suppliers.Application.Deliveries.DTOs;

namespace Suppliers.Application.Deliveries.Queries;

public sealed class GetAllDeliveriesHandler : IRequestHandler<GetAllDeliveriesQuery, IEnumerable<DeliveryDto>>
{
    private readonly IDeliveryRepository _deliveryRepository;

    public GetAllDeliveriesHandler(IDeliveryRepository deliveryRepository)
    {
        _deliveryRepository = deliveryRepository;
    }

    public async Task<IEnumerable<DeliveryDto>> Handle(GetAllDeliveriesQuery request, CancellationToken cancellationToken)
    {
        var deliveries = await _deliveryRepository.GetAllAsync(cancellationToken);

        return deliveries.Select(d => new DeliveryDto
        {
            Id = d.Id,
            SupplierId = d.SupplierId,
            ProductId = d.ProductId,
            Quantity = d.Quantity,
            DeliveryDate = d.DeliveryDate
        });
    }
}
