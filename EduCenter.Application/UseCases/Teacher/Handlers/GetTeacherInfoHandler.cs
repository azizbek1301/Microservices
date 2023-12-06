using EduCenter.Application.Abstarction;
using EduCenter.Application.UseCases.Teacher.Queries;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace EduCenter.Application.UseCases.Teacher.Handlers
{
    public class GetTeacherInfoHandler : IRequestHandler<GetTeacherInfoCommand, List<Domain.Entities.Teacher>>
    {
        private readonly IApplicationDbContext _context;

        public GetTeacherInfoHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<Domain.Entities.Teacher>> Handle(GetTeacherInfoCommand request, CancellationToken cancellationToken)
        {
            return await _context.Teacher.Include(x=>x.StudentTeachers).ThenInclude(x=>x.Student).ToListAsync(cancellationToken);
        }
    }
}
