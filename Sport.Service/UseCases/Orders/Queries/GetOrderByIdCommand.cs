using MediatR;
using Sport.Domain.Entities;

namespace Sport.DataApplication.UseCases.Orders.Queries
{
    public class GetOrderByIdCommand : IRequest<Order>
    {
        public int Id {  get; set; }
    }
}
