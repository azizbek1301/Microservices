using EduCenter.Application.Abstarction;
using EduCenter.Application.UseCases.Student.Commands;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace EduCenter.Application.UseCases.Student.Handlers
{
    public class UpdateStudentHandler : IRequestHandler<UpdateStudentCommand, bool>
    {
        private readonly IApplicationDbContext _context;

        public UpdateStudentHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<bool> Handle(UpdateStudentCommand request, CancellationToken cancellationToken)
        {
            var student = await _context.Student.FirstOrDefaultAsync(x => x.StudentId == request.StudentId);

            student.FirstName=request.FirstName;
            student.LastName=request.LastName;
            student.Email=request.Email;
            student.Address=request.Address;
            student.PhoneNumber=request.PhoneNumber;
            student.Gender=request.Gender;
            student.Role=request.Role;
            

            _context.Student.Update(student);
            var result = await _context.SaveChangesAsync(cancellationToken);
            return result > 0;
        }
    }
}
