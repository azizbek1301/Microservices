using EduCenter.Application.Abstarction;
using EduCenter.Application.UseCases.Room.Commands;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace EduCenter.Application.UseCases.Room.Handlers
{
    public class DeleteRoomHandler : IRequestHandler<DeleteRoomCommand, bool>
    {
        private readonly IApplicationDbContext _context;

        public DeleteRoomHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<bool> Handle(DeleteRoomCommand request, CancellationToken cancellationToken)
        {
            var room=await _context.Room.FirstOrDefaultAsync(x=>x.Id==request.Id);
            if (room==null)
            {
                return false;
            }
            else
            {
                _context.Room.Remove(room);
                await _context.SaveChangesAsync(cancellationToken);
                return true;
            }
        }
    }
}
