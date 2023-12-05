using EduCenter.Application.Abstarction;
using EduCenter.Application.UseCases.Student.Commands;
using MediatR;

namespace EduCenter.Application.UseCases.Student.Handlers
{
    public class CreateStudentHandler : AsyncRequestHandler<CreateStudentCommand>
    {
        private readonly IApplicationDbContext _applicationDbContext;

        public CreateStudentHandler(IApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }

        protected override  async Task Handle(CreateStudentCommand request, CancellationToken cancellationToken)
        {
            var student = new Domain.Entities.Student()
            {
                FirstName = request.FirstName,
                LastName = request.LastName,
                PhoneNumber = request.PhoneNumber,
                Email = request.Email,
                Address = request.Address,
                Role = request.Role,
                Gender = request.Gender,
                

            };
            await _applicationDbContext.Student.AddAsync(student);
            await _applicationDbContext.SaveChangesAsync(cancellationToken);
        }
    }
}
