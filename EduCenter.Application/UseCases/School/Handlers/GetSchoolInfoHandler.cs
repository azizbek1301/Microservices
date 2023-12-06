using EduCenter.Application.Abstarction;
using EduCenter.Application.UseCases.School.Queries;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace EduCenter.Application.UseCases.School.Handlers
{
    public class GetSchoolInfoHandler : IRequestHandler<GetSchoolInfoCommand, List<Domain.Entities.School>>
    {
        private readonly IApplicationDbContext _context;

        public GetSchoolInfoHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<Domain.Entities.School>> Handle(GetSchoolInfoCommand request, CancellationToken cancellationToken)
        {
            return await _context.School.Include(x=>x.Groups).Include(x=>x.Teachers).ToListAsync(cancellationToken);
        }
    }
}
