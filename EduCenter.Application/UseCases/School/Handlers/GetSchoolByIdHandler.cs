using EduCenter.Application.Abstarction;
using EduCenter.Application.UseCases.School.Queries;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace EduCenter.Application.UseCases.School.Handlers
{
    public class GetSchoolByIdHandler : IRequestHandler<GetSchoolByIdCommand, Domain.Entities.School>
    {
        private readonly IApplicationDbContext _applicationDbContex;

        public GetSchoolByIdHandler(IApplicationDbContext applicationDbContex)
        {
            _applicationDbContex = applicationDbContex;
        }

        public async Task<Domain.Entities.School> Handle(GetSchoolByIdCommand request, CancellationToken cancellationToken)
        {
            var school = await _applicationDbContex.School.FirstOrDefaultAsync(x => x.Id == request.Id);
          
            return school;          
            
        }
    }
}
