using MediatR;
using Microsoft.EntityFrameworkCore;
using Sport.DataApplication.Abstraction;
using Sport.DataApplication.UseCases.Coaches.Commands;

namespace Sport.DataApplication.UseCases.Coaches.Handler
{
    public class UpdateCoachHandler : IRequestHandler<UpdateCoachCommand, bool>
    {
        private readonly IApplicationDbContext _context;

        public UpdateCoachHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<bool> Handle(UpdateCoachCommand request, CancellationToken cancellationToken)
        {
            var coach = await _context.Coaches.FirstOrDefaultAsync(x => x.Id == request.Id);
            coach.Name = request.Name;
            coach.Salary = request.Salary;
            coach.TeamId = request.TeamId;

            _context.Coaches.Update(coach);
            var result = await _context.SaveChangesAsync(cancellationToken);
            return result > 0;
        }
    }
}
