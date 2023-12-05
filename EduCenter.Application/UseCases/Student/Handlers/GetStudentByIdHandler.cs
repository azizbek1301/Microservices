using EduCenter.Application.Abstarction;
using EduCenter.Application.UseCases.Student.Queries;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace EduCenter.Application.UseCases.Student.Handlers
{
    public class GetStudentByIdHandler : IRequestHandler<GetStudentByIdCommand, Domain.Entities.Student>
    {
        private readonly IApplicationDbContext _context;

        public GetStudentByIdHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Domain.Entities.Student> Handle(GetStudentByIdCommand request, CancellationToken cancellationToken)
        {
            var student = await _context.Student.FirstOrDefaultAsync(x => x.StudentId == request.StudentId);
            return student;
        }
    }
}
