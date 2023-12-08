using MediatR;
using Sport.DataApplication.Abstraction;
using Sport.DataApplication.UseCases.Players.Commands;
using Sport.Domain.Entities;

namespace Sport.DataApplication.UseCases.Players.Handler
{
    public class CreatePlayerHandler : AsyncRequestHandler<CreatePlayerCommand>
    {
        private readonly IApplicationDbContext _context;

        public CreatePlayerHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        protected override async Task Handle(CreatePlayerCommand request, CancellationToken cancellationToken)
        {
            var player = new Player()
            {
                Name = request.Name,
                Age = request.Age,
                TeamId = request.TeamId,
            };

            await _context.Players.AddAsync(player);
            await _context.SaveChangesAsync(cancellationToken);
        }
    }
}
