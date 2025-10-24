using MediatR;
using Suppliers.Application.Deliveries.DTOs;

namespace Suppliers.Application.Deliveries.Commands;

public sealed record RegisterDeliveryCommand(Guid SupplierId, Guid ProductId, int Quantity, DateTime DeliveryDate)
    : IRequest<DeliveryDto>;
