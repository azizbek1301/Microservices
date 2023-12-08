using MediatR;
using Microsoft.EntityFrameworkCore;
using Sport.DataApplication.Abstraction;
using Sport.DataApplication.UseCases.Players.Queries;
using Sport.Domain.Entities;

namespace Sport.DataApplication.UseCases.Players.Handler
{
    public class GetPlayerByIdHandler : IRequestHandler<GetPlayerByIdCommand, Player>
    {
        private readonly IApplicationDbContext _context;

        public GetPlayerByIdHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Player> Handle(GetPlayerByIdCommand request, CancellationToken cancellationToken)
        {
            var order = await _context.Players.FirstOrDefaultAsync(x => x.Id == request.Id);
            return order;
        }
    }
}
