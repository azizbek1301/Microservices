using MediatR;
using Microsoft.EntityFrameworkCore;
using Sport.DataApplication.Abstraction;
using Sport.DataApplication.UseCases.Orders.Queries;
using Sport.Domain.Entities;

namespace Sport.DataApplication.UseCases.Orders.Handler
{
    public class GetOrderByIdHandler : IRequestHandler<GetOrderByIdCommand, Order>
    {
        private readonly IApplicationDbContext _context;

        public GetOrderByIdHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Order> Handle(GetOrderByIdCommand request, CancellationToken cancellationToken)
        {
            var order = await _context.Orders.FirstOrDefaultAsync(x => x.Id == request.Id);
            return order;
        }
    }
}
