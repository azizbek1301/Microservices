using MediatR;
using Microsoft.EntityFrameworkCore;
using Sport.DataApplication.Abstraction;
using Sport.DataApplication.UseCases.Orders.Queries;
using Sport.Domain.Entities;

namespace Sport.DataApplication.UseCases.Orders.Handler
{
    public class GetAllOrderHandler : IRequestHandler<GetAllOrderCommand, List<Order>>
    {
        private readonly IApplicationDbContext _context;

        public GetAllOrderHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<Order>> Handle(GetAllOrderCommand request, CancellationToken cancellationToken)
        {
            return await _context.Orders.ToListAsync();
        }
    }
}
