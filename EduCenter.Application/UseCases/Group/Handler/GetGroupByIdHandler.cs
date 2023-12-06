using EduCenter.Application.Abstarction;
using EduCenter.Application.UseCases.Group.Queries;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace EduCenter.Application.UseCases.Group.Handler
{
    public class GetGroupByIdHandler : IRequestHandler<GetGroupByIdCommand, Domain.Entities.Group>
    {
        private readonly IApplicationDbContext _context;

        public GetGroupByIdHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Domain.Entities.Group> Handle(GetGroupByIdCommand request, CancellationToken cancellationToken)
        {
            var group = await _context.Group.FirstOrDefaultAsync(x => x.Id == request.Id);
            return group;
        }
    }
}
