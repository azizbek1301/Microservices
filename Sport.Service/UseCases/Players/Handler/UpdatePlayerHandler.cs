using MediatR;
using Microsoft.EntityFrameworkCore;
using Sport.DataApplication.Abstraction;
using Sport.DataApplication.UseCases.Players.Commands;

namespace Sport.DataApplication.UseCases.Players.Handler
{
    public class UpdatePlayerHandler : IRequestHandler<UpdatePlayerCommand, bool>
    {
        private readonly IApplicationDbContext _context;

        public UpdatePlayerHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<bool> Handle(UpdatePlayerCommand request, CancellationToken cancellationToken)
        {
            var order = await _context.Players.FirstOrDefaultAsync(x => x.Id == request.Id);
            order.Name = request.Name;
            order.Age = request.Age;
            order.TeamId = request.TeamId;

            _context.Players.Update(order);
            var result = await _context.SaveChangesAsync(cancellationToken);
            return result > 0;
        }
    }
}
