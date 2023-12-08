using MediatR;
using Sport.DataApplication.Abstraction;
using Sport.DataApplication.UseCases.Teams.Commands;
using Sport.Domain.Entities;

namespace Sport.DataApplication.UseCases.Teams.Handler
{
    public class CreateTeamHandler : AsyncRequestHandler<CreateTeamCommand>
    {
        private readonly IApplicationDbContext _context;

        public CreateTeamHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        protected override async Task Handle(CreateTeamCommand request, CancellationToken cancellationToken)
        {
            var team = new Team()
            {
                Name = request.Name,

            };

            await _context.Teamlar.AddAsync(team);
            await _context.SaveChangesAsync(cancellationToken);
        }
    }
}
