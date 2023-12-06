using EduCenter.Application.Abstarction;
using EduCenter.Application.UseCases.School.Queries;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace EduCenter.Application.UseCases.School.Handlers
{

    public class GetSchoolCommandHandler : IRequestHandler<GetSchoolCommand, List<Domain.Entities.School>>
    {
        private readonly IApplicationDbContext _applicationDbContext;

        public GetSchoolCommandHandler(IApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }

        public async Task<List<Domain.Entities.School>> Handle(GetSchoolCommand request, CancellationToken cancellationToken)
        {
            return await _applicationDbContext.School.ToListAsync();
        }
    }
}
