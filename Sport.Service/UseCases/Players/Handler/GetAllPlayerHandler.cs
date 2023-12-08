using MediatR;
using Microsoft.EntityFrameworkCore;
using Sport.DataApplication.Abstraction;
using Sport.DataApplication.UseCases.Players.Queries;
using Sport.Domain.Entities;

namespace Sport.DataApplication.UseCases.Players.Handler
{
    public class GetAllPlayerHandler : IRequestHandler<GetAllPlayerCommand, List<Player>>
    {
        private readonly IApplicationDbContext _context;

        public GetAllPlayerHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<Player>> Handle(GetAllPlayerCommand request, CancellationToken cancellationToken)
        {
            return await _context.Players.ToListAsync();
        }
    }
}
