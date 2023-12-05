using EduCenter.Application.Abstarction;
using EduCenter.Application.UseCases.Teacher.Queries;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace EduCenter.Application.UseCases.Teacher.Handlers
{
    public class GetAllTeacherHandler : IRequestHandler<GetAllTeacherCommand, List<Domain.Entities.Teacher>>
    {
        private readonly IApplicationDbContext _context;

        public GetAllTeacherHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<Domain.Entities.Teacher>> Handle(GetAllTeacherCommand request, CancellationToken cancellationToken)
        {
            return await _context.Teacher.ToListAsync();
        }
    }
}
