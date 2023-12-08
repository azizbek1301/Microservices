using MediatR;
using Sport.DataApplication.Abstraction;
using Sport.DataApplication.UseCases.Coaches.Commands;
using Sport.Domain.Entities;

namespace Sport.DataApplication.UseCases.Coaches.Handler
{
    public class CreateCoachHandler : AsyncRequestHandler<CreateCoachCommand>
    {
        private readonly IApplicationDbContext _context;

        public CreateCoachHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        protected override async Task Handle(CreateCoachCommand request, CancellationToken cancellationToken)
        {
            var coach = new Coach()
            {
                Name = request.Name,
                Salary = request.Salary,
                TeamId = request.TeamId,
            };

            await _context.Coaches.AddAsync(coach);
            await _context.SaveChangesAsync(cancellationToken);
        }
    }
}
