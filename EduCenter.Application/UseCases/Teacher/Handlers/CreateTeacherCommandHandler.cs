using EduCenter.Application.Abstarction;
using EduCenter.Application.UseCases.Teacher.Commands;
using MediatR;

namespace EduCenter.Application.UseCases.Teacher.Handlers
{
    public class CreateTeacherCommandHandler : AsyncRequestHandler<CreatTeacherCommand>
    {
        private readonly IApplicationDbContext _context;

        public CreateTeacherCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        protected override async Task Handle(CreatTeacherCommand request, CancellationToken cancellationToken)
        {
            var teacher = new Domain.Entities.Teacher()
            {
                Name = request.Name,
                LastName = request.LastName,
                Phone = request.Phone,
                SchoolId = request.SchoolId,
                Role = request.Role,

            };
            await _context.Teacher.AddAsync(teacher);
            await _context.SaveChangesAsync(cancellationToken);
        }
    }
}
