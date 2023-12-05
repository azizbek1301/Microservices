using EduCenter.Application.Abstarction;
using EduCenter.Application.UseCases.School.Commands;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EduCenter.Application.UseCases.School.Handlers
{
    public class DeleteSchoolHandler : IRequestHandler<DeleteSchoolCommand,bool>
    {
        private readonly IApplicationDbContext _applicationDbContex;

        public DeleteSchoolHandler(IApplicationDbContext applicationDbContex)
        {
            _applicationDbContex = applicationDbContex;
        }

        public  async Task<bool> Handle(DeleteSchoolCommand request, CancellationToken cancellationToken)
        {
            var school = await _applicationDbContex.School.FirstOrDefaultAsync(x => x.Id == request.Id);
            if (school == null)
            {
                return false;
            }
            else
            {
               _applicationDbContex.School.Remove(school);
                await _applicationDbContex.SaveChangesAsync(cancellationToken);
                return true;
            }
        }
    }
}
