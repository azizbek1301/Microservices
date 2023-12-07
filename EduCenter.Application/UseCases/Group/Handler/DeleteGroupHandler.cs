using EduCenter.Application.Abstarction;
using EduCenter.Application.UseCases.Group.Commands;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace EduCenter.Application.UseCases.Group.Handler
{
    public class DeleteGroupHandler : IRequestHandler<DeleteGroupCommand, bool>
    {
        private readonly IApplicationDbContext _context;

        public DeleteGroupHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<bool> Handle(DeleteGroupCommand request, CancellationToken cancellationToken)
        {
            var group = await _context.Group.FirstOrDefaultAsync(x => x.Id == request.Id);
            if (group == null)
            {
                return false;

            }
            else
            {
                _context.Group.Remove(group);
                await _context.SaveChangesAsync(cancellationToken);
                return true;

            }
        }
    }
}
