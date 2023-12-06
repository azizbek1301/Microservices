using EduCenter.Application.Abstarction;
using EduCenter.Application.UseCases.Room.Commands;
using MediatR;

namespace EduCenter.Application.UseCases.Room.Handlers
{
    internal class CreateRoomHandler : AsyncRequestHandler<CreateRoomCommand>
    {
        private readonly IApplicationDbContext _context;

        public CreateRoomHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        protected override async Task Handle(CreateRoomCommand request, CancellationToken cancellationToken)
        {
            var room = new Domain.Entities.Room()
            {
                RoomNumber = request.RoomNumber,
                SeatCount = request.SeatCount,
            };

            await _context.Room.AddAsync(room);
            await _context.SaveChangesAsync(cancellationToken);
        }
    }
}
