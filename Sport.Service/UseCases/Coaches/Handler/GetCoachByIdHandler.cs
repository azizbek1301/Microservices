using MediatR;
using Microsoft.EntityFrameworkCore;
using Sport.DataApplication.Abstraction;
using Sport.DataApplication.UseCases.Coaches.Queries;
using Sport.Domain.Entities;

namespace Sport.DataApplication.UseCases.Coaches.Handler
{
    public class GetCoachByIdHandler : IRequestHandler<GetCouchByIdCommand, Coach>
    {
        private readonly IApplicationDbContext _context;

        public GetCoachByIdHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Coach> Handle(GetCouchByIdCommand request, CancellationToken cancellationToken)
        {
            var coach = await _context.Coaches.FirstOrDefaultAsync(x => x.Id == request.Id);
            return coach;
        }
    }
}
