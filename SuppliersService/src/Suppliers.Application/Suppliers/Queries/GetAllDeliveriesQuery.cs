using MediatR;
using Suppliers.Application.Deliveries.DTOs;

namespace Suppliers.Application.Deliveries.Queries;

public sealed record GetAllDeliveriesQuery() : IRequest<IEnumerable<DeliveryDto>>;
