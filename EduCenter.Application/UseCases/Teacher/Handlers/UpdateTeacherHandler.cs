using EduCenter.Application.Abstarction;
using EduCenter.Application.UseCases.Teacher.Commands;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EduCenter.Application.UseCases.Teacher.Handlers
{
    public class UpdateTeacherHandler : IRequestHandler<UpdateTeacherCommand, bool>
    {
        private readonly IApplicationDbContext _applicationDbContext;

        public UpdateTeacherHandler(IApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }

        public async Task<bool> Handle(UpdateTeacherCommand request, CancellationToken cancellationToken)
        {
            var teacher = await _applicationDbContext.Teacher.FirstOrDefaultAsync(x => x.TeacherId == request.TeacherId);

            teacher.Name = request.Name;
            teacher.LastName = request.LastName;
            teacher.Phone = request.Phone;
            teacher.Role= request.Role;
            teacher.SchoolId= request.SchoolId;

            _applicationDbContext.Teacher.Update(teacher);
            var result = await _applicationDbContext.SaveChangesAsync(cancellationToken);
            return result > 0;
        }

    }
}
