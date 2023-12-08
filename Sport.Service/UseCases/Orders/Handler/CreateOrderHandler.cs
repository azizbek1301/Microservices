using MediatR;
using Sport.DataApplication.Abstraction;
using Sport.DataApplication.UseCases.Orders.Commands;
using Sport.Domain.Entities;

namespace Sport.DataApplication.UseCases.Orders.Handler
{
    public class CreateOrderHandler : AsyncRequestHandler<CreatOrderCommand>
    {
        private readonly IApplicationDbContext _context;

        public CreateOrderHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        protected override async Task Handle(CreatOrderCommand request, CancellationToken cancellationToken)
        {
            var order = new Order()
            {
                Status = request.Status,                
                PlayerId = request.PlayerId,
            };

            await _context.Orders.AddAsync(order);
            await _context.SaveChangesAsync(cancellationToken);
        }

       
    }
}
