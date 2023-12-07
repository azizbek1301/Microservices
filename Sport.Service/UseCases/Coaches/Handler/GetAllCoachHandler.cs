using MediatR;
using Microsoft.EntityFrameworkCore;
using Sport.DataApplication.Abstraction;
using Sport.DataApplication.UseCases.Coaches.Queries;
using Sport.Domain.Entities;

namespace Sport.DataApplication.UseCases.Coaches.Handler
{
    public class GetAllCoachHandler : IRequestHandler<GetAllCoachCommand, List<Coach>>
    {
        private readonly IApplicationDbContext _context;

        public GetAllCoachHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<Coach>> Handle(GetAllCoachCommand request, CancellationToken cancellationToken)
        {
            return await _context.Coaches.ToListAsync();
        }
    }
}
