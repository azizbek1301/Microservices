using EduCenter.Application.Abstarction;
using EduCenter.Application.UseCases.Group.Commands;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace EduCenter.Application.UseCases.Group.Handler
{
    public class UpdateGroupHandler : IRequestHandler<UpdateGroupCommand, bool>
    {
        private readonly IApplicationDbContext _context;

        public UpdateGroupHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<bool> Handle(UpdateGroupCommand request, CancellationToken cancellationToken)
        {
            var group = await _context.Group.FirstOrDefaultAsync(x => x.Id == request.Id);
            group.ClassNumber = request.ClassNumber;
            group.StudentCount = request.StudentCount;
            group.SchoolId = request.SchoolId;

            _context.Group.Update(group);
            var result = await _context.SaveChangesAsync(cancellationToken);
            return result > 0;
        }
    }
}
