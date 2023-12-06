using EduCenter.Application.Abstarction;
using EduCenter.Application.UseCases.Group.Queries;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace EduCenter.Application.UseCases.Group.Handler
{
    public class GetAllGroupHandler : IRequestHandler<GetAllGroupCommand, List<Domain.Entities.Group>>
    {
        private readonly IApplicationDbContext _context;

        public GetAllGroupHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<Domain.Entities.Group>> Handle(GetAllGroupCommand request, CancellationToken cancellationToken)
        {
            return await _context.Group.ToListAsync();
        }
    }
}
