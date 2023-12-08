using MediatR;
using Microsoft.EntityFrameworkCore;
using Sport.DataApplication.Abstraction;
using Sport.DataApplication.UseCases.Teams.Commands;

namespace Sport.DataApplication.UseCases.Teams.Handler
{
    public class UpdatePlayerHandler : IRequestHandler<UpdateTeamCommand, bool>
    {
        private readonly IApplicationDbContext _context;

        public UpdatePlayerHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<bool> Handle(UpdateTeamCommand request, CancellationToken cancellationToken)
        {
            var order = await _context.Teamlar.FirstOrDefaultAsync(x => x.Id == request.Id);
            order.Name = request.Name;


            _context.Teamlar.Update(order);
            var result = await _context.SaveChangesAsync(cancellationToken);
            return result > 0;
        }
    }
}
