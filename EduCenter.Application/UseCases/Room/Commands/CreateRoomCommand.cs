using MediatR;

namespace EduCenter.Application.UseCases.Room.Commands
{
    public class CreateRoomCommand:IRequest
    {
        public int RoomNumber { get; set; }
        public int SeatCount { get; set; }
    }
}
