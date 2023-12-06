using MediatR;

namespace EduCenter.Application.UseCases.Room.Commands
{
    public class UpdateRoomCommand :IRequest<bool>
    {
        public int Id { get; set; }
        public int RoomNumber { get; set; }
        public int SeatCount { get; set; }
    }
}
