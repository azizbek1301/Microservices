using EduCenter.Application.Abstarction;
using EduCenter.Application.UseCases.School.Commands;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace EduCenter.Application.UseCases.School.Handlers
{
    public class UpdateSchoolHandler : IRequestHandler<UpdateSchoolCommand, bool>
    {
        private readonly IApplicationDbContext _applicationDbContex;

        public UpdateSchoolHandler(IApplicationDbContext applicationDbContex)
        {
            _applicationDbContex = applicationDbContex;
        }

        public async Task<bool> Handle(UpdateSchoolCommand request, CancellationToken cancellationToken)
        {
            var school = await _applicationDbContex.School.FirstOrDefaultAsync(school=>school.Id==request.Id);

            school.Name=request.Name;
            school.PhoneNumber=request.PhoneNumber;
            school.Email=request.Email;
            school.Address = request.Address;
        
            _applicationDbContex.School.Update(school);
            var result = await _applicationDbContex.SaveChangesAsync(cancellationToken);
            return result>0;
        }
    }
}
