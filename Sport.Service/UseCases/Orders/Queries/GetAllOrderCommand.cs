using MediatR;
using Sport.Domain.Entities;

namespace Sport.DataApplication.UseCases.Orders.Queries
{
    public class GetAllOrderCommand : IRequest<List<Order>>
    {
    }
}
