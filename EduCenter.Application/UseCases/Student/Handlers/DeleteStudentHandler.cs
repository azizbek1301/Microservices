using EduCenter.Application.Abstarction;
using EduCenter.Application.UseCases.Student.Commands;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace EduCenter.Application.UseCases.Student.Handlers
{
    public class DeleteStudentHandler : IRequestHandler<DeleteStudentCommand, bool>
    {
        private readonly IApplicationDbContext _applicationDbContext;

        public DeleteStudentHandler(IApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }

        public async Task<bool> Handle(DeleteStudentCommand request, CancellationToken cancellationToken)
        {
            var student = await _applicationDbContext.Student.FirstOrDefaultAsync(x => x.StudentId == request.StudentId);
            if (student == null)
            {
                return false;
            }
            else
            {
                _applicationDbContext.Student.Remove(student);
                await _applicationDbContext.SaveChangesAsync(cancellationToken);
                return true;
            }
        }
    }
}
