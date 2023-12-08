using MediatR;
using Microsoft.EntityFrameworkCore;
using Sport.DataApplication.Abstraction;
using Sport.DataApplication.UseCases.Players.Commands;

namespace Sport.DataApplication.UseCases.Players.Handler
{
    public class DeletePlayerHandler : IRequestHandler<DeletePlayerCommand, bool>
    {
        private readonly IApplicationDbContext _context;

        public DeletePlayerHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<bool> Handle(DeletePlayerCommand request, CancellationToken cancellationToken)
        {
            var player = await _context.Players.FirstOrDefaultAsync(x => x.Id == request.Id);
            if (player == null)
            {
                return false;

            }
            else
            {
                _context.Players.Remove(player);
                await _context.SaveChangesAsync(cancellationToken);
                return true;

            }
        }
    }
}
