using MediatR;
using Microsoft.EntityFrameworkCore;
using Sport.DataApplication.Abstraction;
using Sport.DataApplication.UseCases.Coaches.Commands;

namespace Sport.DataApplication.UseCases.Coaches.Handler
{
    public class DeleteCoachHandler : IRequestHandler<DeleteCoachCommand, bool>
    {
        private readonly IApplicationDbContext _context;

        public DeleteCoachHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<bool> Handle(DeleteCoachCommand request, CancellationToken cancellationToken)
        {
            var coach = await _context.Coaches.FirstOrDefaultAsync(x => x.Id == request.Id);
            if (coach == null)
            {
                return false;

            }
            else
            {
                _context.Coaches.Remove(coach);
                await _context.SaveChangesAsync(cancellationToken);
                return true;

            }
        }
    }
}
