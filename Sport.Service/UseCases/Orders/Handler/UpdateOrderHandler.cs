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
    public class UpdateOrderHandler : IRequestHandler<UpdateOrderCommand, bool>
    {
        private readonly IApplicationDbContext _context;

        public UpdateOrderHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<bool> Handle(UpdateOrderCommand request, CancellationToken cancellationToken)
        {
            var order = await _context.Orders.FirstOrDefaultAsync(x => x.Id == request.Id);
            order.Status = request.Status;
            order.PlayerId= request.PlayerId;
            
            _context.Orders.Update(order);
            var result = await _context.SaveChangesAsync(cancellationToken);
            return result > 0;
        }
    }
}
