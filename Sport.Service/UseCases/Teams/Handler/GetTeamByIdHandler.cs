using MediatR;
using Microsoft.EntityFrameworkCore;
using Sport.DataApplication.Abstraction;
using Sport.DataApplication.UseCases.Teams.Queries;
using Sport.Domain.Entities;

namespace Sport.DataApplication.UseCases.Teams.Handler
{
    public class GetTeamByIdHandler : IRequestHandler<GetTeamByIdCommand, Team>
    {
        private readonly IApplicationDbContext _context;

        public GetTeamByIdHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Team> Handle(GetTeamByIdCommand request, CancellationToken cancellationToken)
        {
            var order = await _context.Teamlar.FirstOrDefaultAsync(x => x.Id == request.Id);
            return order;
        }
    }
}
