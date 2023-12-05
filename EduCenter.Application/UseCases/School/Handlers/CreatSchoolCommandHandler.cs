using EduCenter.Application.Abstarction;
using EduCenter.Application.UseCases.School.Commands;
using MediatR;

namespace EduCenter.Application.UseCases.School.Handlers
{
    public class CreatSchoolCommandHandler : AsyncRequestHandler<CreateSchoolCommand>
    {
        private readonly IApplicationDbContext _applicationDbContex;

        public CreatSchoolCommandHandler(IApplicationDbContext applicationDbContex)
        {
            _applicationDbContex = applicationDbContex;
        }

        protected override async Task Handle(CreateSchoolCommand request, CancellationToken cancellationToken)
        {
       
            var school = new Domain.Entities.School()
            {
                Name = request.Name,
                Address = request.Address,
                PhoneNumber=request.PhoneNumber,
                Email=request.Email,
            };
            await _applicationDbContex.School.AddAsync(school);
            await _applicationDbContex.SaveChangesAsync(cancellationToken);
        }
    }
}
