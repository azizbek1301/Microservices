using MediatR;
using Microsoft.EntityFrameworkCore;
using Sport.DataApplication.Abstraction;
using Sport.DataApplication.UseCases.Teams.Queries;
using Sport.Domain.Entities;

namespace Sport.DataApplication.UseCases.Teams.Handler
{
    public class GetAllTeamHandler : IRequestHandler<GetAllTeamCommand, List<Team>>
    {
        private readonly IApplicationDbContext _context;

        public GetAllTeamHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<Team>> Handle(GetAllTeamCommand request, CancellationToken cancellationToken)
        {
            return await _context.Teamlar.ToListAsync();
        }
    }
}
