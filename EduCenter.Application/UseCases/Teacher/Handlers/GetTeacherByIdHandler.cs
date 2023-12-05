using EduCenter.Application.Abstarction;
using EduCenter.Application.UseCases.Teacher.Queries;
using EduCenter.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace EduCenter.Application.UseCases.Teacher.Handlers
{
    public class GetTeacherByIdHandler : IRequestHandler<GetTeacherByIdCommand, Domain.Entities.Teacher>
    {
        private readonly IApplicationDbContext _applicationDbContext;

        public GetTeacherByIdHandler(IApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }

        public async Task<Domain.Entities.Teacher> Handle(GetTeacherByIdCommand request, CancellationToken cancellationToken)
        {
            var teacher =await _applicationDbContext.Teacher.FirstOrDefaultAsync(x=>x.TeacherId == request.TeacherId);
            return teacher;
        }
    }
}
