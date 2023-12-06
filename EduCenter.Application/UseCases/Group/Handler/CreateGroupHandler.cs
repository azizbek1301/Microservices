using EduCenter.Application.Abstarction;
using EduCenter.Application.UseCases.Group.Commands;
using MediatR;

namespace EduCenter.Application.UseCases.Group.Handler
{
    public class CreateGroupHandler : AsyncRequestHandler<CreateGroupCommand>
    {
        private readonly IApplicationDbContext _context;

        public CreateGroupHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        protected override async Task Handle(CreateGroupCommand request, CancellationToken cancellationToken)
        {
            var group = new Domain.Entities.Group()
            {
                ClassNumber = request.ClassNumber,
                StudentCount = request.StudentCount,
                SchoolId = request.SchoolId,
            };

            await _context.Group.AddAsync(group);
            await _context.SaveChangesAsync(cancellationToken);
        }
    }
}
