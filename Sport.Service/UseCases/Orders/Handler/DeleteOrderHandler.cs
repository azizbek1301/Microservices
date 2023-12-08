using MediatR;
using Microsoft.EntityFrameworkCore;
using Sport.DataApplication.Abstraction;
using Sport.DataApplication.UseCases.Coaches.Commands;
using Sport.DataApplication.UseCases.Orders.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sport.DataApplication.UseCases.Orders.Handler
{
    public class DeleteOrderHandler : IRequestHandler<DeleteOrderCommand, bool>
    {
        private readonly IApplicationDbContext _context;

        public DeleteOrderHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<bool> Handle(DeleteOrderCommand request, CancellationToken cancellationToken)
        {
            var order = await _context.Orders.FirstOrDefaultAsync(x => x.Id == request.Id);
            if (order == null)
            {
                return false;

            }
            else
            {
                _context.Orders.Remove(order);
                await _context.SaveChangesAsync(cancellationToken);
                return true;

            }
        }
    }
}
