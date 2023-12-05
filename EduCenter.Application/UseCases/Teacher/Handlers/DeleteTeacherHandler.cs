using EduCenter.Application.Abstarction;
using EduCenter.Application.UseCases.Teacher.Commands;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace EduCenter.Application.UseCases.Teacher.Handlers
{
    public class DeleteTeacherHandler : IRequestHandler<DeleteTeacherComman, bool>
    {
        private readonly IApplicationDbContext _context;

        public DeleteTeacherHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<bool> Handle(DeleteTeacherComman request, CancellationToken cancellationToken)
        {
            var teacher = await _context.Teacher.FirstOrDefaultAsync(x => x.TeacherId == request.TeacherId);
            if (teacher == null)
            {
                return false;
            }
            else
            {
                _context.Teacher.Remove(teacher);
                await _context.SaveChangesAsync(cancellationToken);
                return true;
            }
        }
    }
}
