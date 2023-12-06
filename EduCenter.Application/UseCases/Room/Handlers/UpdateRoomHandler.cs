using EduCenter.Application.Abstarction;
using EduCenter.Application.UseCases.Room.Commands;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace EduCenter.Application.UseCases.Room.Handlers
{
    public class UpdateRoomHandler : IRequestHandler<UpdateRoomCommand, bool>
    {
        private readonly IApplicationDbContext _context;

        public UpdateRoomHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<bool> Handle(UpdateRoomCommand request, CancellationToken cancellationToken)
        {
            var room = await _context.Room.FirstOrDefaultAsync(x => x.Id == request.Id);
            room.RoomNumber = request.RoomNumber;
            room.SeatCount = request.SeatCount;

            _context.Room.Update(room);
            var result = await _context.SaveChangesAsync(cancellationToken);
            return result>0;
        }
    }
}
