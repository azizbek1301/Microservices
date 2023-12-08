using MediatR;
using Microsoft.EntityFrameworkCore;
using Sport.DataApplication.Abstraction;
using Sport.DataApplication.UseCases.Teams.Commands;

namespace Sport.DataApplication.UseCases.Teams.Handler
{
    public class DeleteTeamHandler : IRequestHandler<DeleteTeamCommand, bool>
    {
        private readonly IApplicationDbContext _context;

        public DeleteTeamHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<bool> Handle(DeleteTeamCommand request, CancellationToken cancellationToken)
        {
            var team = await _context.Teamlar.FirstOrDefaultAsync(x => x.Id == request.Id);
            if (team == null)
            {
                return false;

            }
            else
            {
                _context.Teamlar.Remove(team);
                await _context.SaveChangesAsync(cancellationToken);
                return true;

            }
        }
    }
}
